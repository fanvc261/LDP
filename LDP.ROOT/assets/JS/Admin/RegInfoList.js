var grdObject, dataObject, grdSettings, datetimeRender, grdTable, hgrd = 400;
var lstId = [];
$(document).ready(function () {

    activeMenu('mn_rg');
    grdObject = document.querySelector('#grdInfo');

    datetimeRender = function (instance, td, row, col, prop, value, cellProperties) {
        while (td.firstChild) {
            td.removeChild(td.firstChild);
        }
        var datetimeval = (new Date(parseInt(value.replace('/Date(', ''))).toJSON().slice(0, 10));
        $(td).addClass(cellProperties.className);
        $(td).html(datetimeval);
    };

    hgrd = window.innerHeight - $(grdObject).offset().top - 35;
    if (hgrd < 400)
        hgrd = 400;
    grdSettings = {
        data: [],
        columns: [
            {
                data: 'Id',
                type: 'numeric',
                width: 40,
                readOnly: true,
                className: "htCenter"
            },
            {
                data: 'Field1',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Field2',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Field3',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Field4',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Field5',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Field6',
                type: 'text',
                readOnly: true
            },
            {
                data: 'StringDate',
                //renderer: datetimeRender,
                dateFormat: 'MM/DD/YYYY',
                readOnly: true,
                className: "htCenter"
            }
        ],
        stretchH: 'all',
        autoWrapRow: true,
        height: hgrd,
        rowHeaders: true,
        colHeaders: [
            'ID',
            'Field1',
            'Field2',
            'Field3',
            'Field4',
            'Field5',
            'Field6',
            'CreatedOn'
        ],
        columnSorting: true,
        sortIndicator: true,
        autoColumnSize: {
            samplingRatio: 23
        },
        manualRowResize: true,
        manualColumnResize: true,
        manualRowMove: true,
        manualColumnMove: true,
        contextMenu: true, // ['row_above', 'row_below', 'hsep1', 'col_left', 'col_right', 'hsep2', 'remove_row', 'remove_col', 'hsep3', 'undo', 'redo', 'make_read_only', 'alignment', 'borders', 'commentsAddEdit','commentsRemove'],
        filters: true,
        outsideClickDeselects: false,
        dropdownMenu: true,
        //afterSelection: function (a, b, c, d) {
        //    //console.log('a: ' + a + ', b:' + b + ', c:' + c + ', d:' + d);
        //    lstId = [];
        //    if (b == 0 && d == 7) {
        //        var minval = (a > c ? c : a);
        //        var maxval = (a > c ? a : c);
        //        for (var i = minval; i <= maxval; i++) {
        //            var userId = grdTable.getDataAtCell(i, 0);
        //            lstId.push(userId);
        //        }

        //    }
        //},
        beforeRemoveRow: function (a, b) {
            if (confirm("Bạn có chắt muốn xóa dữ liệu ?")) {
                for (var i = a; i < a + b; i++) {
                    var userId = grdTable.getDataAtCell(i, 0);
                    deleteRegInfo(userId);
                    //lstId.push(userId);
                }
                //alert(lstId);
                return true;
            }
            else
                return false;
        },
        afterRemoveRow: function (a, b, c, d) {
            SuccessNotication("Xóa thông tin đăng ký", "Xóa thông tin đăng ký thành công.");
        }
    };

    loadList();

    //$(document).on("click", "#grdUser tr td:nth-child(1)", function () {
    //    var userId = $(this).parent().find('td:nth-child(0)').html();
    //    location.href = "/LDPAdmin/UserEdit.aspx?userid=" + userId;

    //});

    $(document).one("click", "#btnDelete", function () {
        var selection = grdTable.getSelected();
        //console.log(selection);
        if (selection[1] == 0 && selection[3] == 7) {
            var minval = (selection[0] > selection[2] ? selection[2] : selection[0]);
            var maxval = (selection[0] > selection[2] ? selection[0] : selection[2]);
            grdTable.alter('remove_row', selection[0], maxval - minval + 1);

        }

        

        //if (confirm("Bạn có chắt muốn xóa dữ liệu ?")) {
        //    let id = curId;
        //    $("#btnDelete").prop('disabled', true);
        //    deleteWiget(id);
        //}
        //alert(lstId);
    });
    $(document).on("click", "#btnExport", function () {
        var exportPlugin = grdTable.getPlugin('exportFile');
        exportPlugin.downloadFile('csv', {
            exportHiddenRows: true,     // default false, exports the hidden rows
            exportHiddenColumns: true,  // default false, exports the hidden columns
            columnHeaders: true,        // default false, exports the column headers
            rowHeaders: false,           // default false, exports the row headers
            columnDelimiter: ',',       // default ',', the data delimiter
            filename: 'MyFile'
        });
    });
})

var loadList = function () {
    let p = new methodParams();
    callMethod_1("RegInfo_GetList", p, loadListCallback);
}

var deleteRegInfo = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("RegInfo_DeleteById", p, deleteRegInfoCallback);
}

function loadListCallback(result) {


    grdSettings.data = result.data;
    grdTable = new Handsontable(grdObject, grdSettings);
}


function deleteRegInfoCallback(result) {
    //$("#btnDelete").prop('disabled', false);
    //alert(result);
}
