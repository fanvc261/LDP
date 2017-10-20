var grdObject, dataObject, grdSettings, grdTable, activeRender, blockRender,hgrd=400;
$(document).ready(function () {
    
    activeMenu('mn_ul');
    grdObject = document.querySelector('#grdUser');
    activeRender = function (instance, td, row, col, prop, value, cellProperties) {
        while (td.firstChild) {
            td.removeChild(td.firstChild);
        }
        var strchecked = '';
        if ((value & 1) > 0)
            strchecked = 'checked= "checked"';
        var cellElement = $('<div class="togglebutton"><label><input type="checkbox" class="cbActive" ' + strchecked + ' /><span class="toggle"></span></label></div>');
        $(td).addClass(cellProperties.className);
        $(td).append(cellElement);
    };

    blockRender = function (instance, td, row, col, prop, value, cellProperties) {
        console.log(cellProperties);
        while (td.firstChild) {
            td.removeChild(td.firstChild);
        }
        var strchecked = '';
        if ((value & 2) > 0)
            strchecked = 'checked= "checked"';
        var cellElement = $('<div class="togglebutton"><label><input type="checkbox" class="cbBlock" ' + strchecked + ' /><span class="toggle"></span></label></div>');
        $(td).addClass(cellProperties.className);
        $(td).append(cellElement);
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
                data: 'UserName',
                type: 'text',
                readOnly: true
            },
            {
                data: 'FullName',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Email',
                type: 'text',
                readOnly: true
            },
            {
                data: 'Status',
                renderer: activeRender,
                readOnly: true,
                className: "htCenter"
            },
            {
                data: 'Status',
                renderer: blockRender,
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
            'UserName',
            'FullName',
            'Email',
            'Active',
            'Block'
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
        contextMenu: false, // ['row_above', 'row_below', 'hsep1', 'col_left', 'col_right', 'hsep2', 'remove_row', 'remove_col', 'hsep3', 'undo', 'redo', 'make_read_only', 'alignment', 'borders', 'commentsAddEdit','commentsRemove'],
        filters: true,
        dropdownMenu: true,
        afterSelection: function (a, b, c, d) {
            //console.log('a: ' + a + ', b:' + b + ', c:' + c + ', d:' + d);
            if (b == 0 && d == 5)
            {
                var userId = grdTable.getDataAtCell(a, 0);
                location.href = "/LDPAdmin/UserEdit.aspx?userid=" + userId;
            }
        }
    };

    loadList();

    //$(document).on("click", "#grdUser tr td:nth-child(1)", function () {
    //    var userId = $(this).parent().find('td:nth-child(0)').html();
    //    location.href = "/LDPAdmin/UserEdit.aspx?userid=" + userId;

    //});

    $(document).on("click", "#btnAddNew", function () {
        location.href = "/LDPAdmin/UserEdit.aspx";
    });

    $(document).on("click", "#btnSave", function () {
        let id = curId,
            name = $('#txtName').val(),
            pageId = $('#cbAllPage').is(':checked') ? 0 : curPageId,
            rank = $('#txtRank').val(),
            status = $('#cbHide').is(':checked') ? 0 : 1,
            option = 0,
            classBody = $('#txtBodyClass').val(),
            containerGuid = $('#ddlContainer').val(),
            content = htmlEncode(editor.value());
        $("#btnSave").prop('disabled', true);
        saveWiget(id, name, pageId, rank, status, option, classBody, containerGuid, content);
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
    callMethod_1("User_GetList", p, loadListCallback);
}

var deleteWiget = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Wiget_DeleteById", p, deleteWigetCallback);
}

function loadListCallback(result) {
   
    
    grdSettings.data = result.data;
    grdTable = new Handsontable(grdObject, grdSettings);
}


function deleteWigetCallback(result) {
    $("#btnDelete").prop('disabled', false);
    //alert(result);

    SuccessNotication("Xóa thông tin người dùng", "Xóa thông tin người dùng thành công.");
}
