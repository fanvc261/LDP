var grdObject, dataObject, grdSettings, grdTable;
$(document).ready(function () {
    
    activeMenu('mn_ul');
    grdObject = document.querySelector('#grdUser');
    grdSettings = {
        data: [],
        columns: [
            {
                data: 'Id',
                type: 'numeric',
                width: 40,
                readOnly: true
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
                type: 'numeric',
                readOnly: true
            }
        ],
        stretchH: 'all',
        autoWrapRow: true,
        height: 487,
        maxRows: 22,
        rowHeaders: true,
        colHeaders: [
            'ID',
            'UserName',
            'FullName',
            'Email',
            'Status'
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
        contextMenu: ['row_above', 'row_below', 'hsep1', 'col_left', 'col_right', 'hsep2', 'remove_row', 'remove_col', 'hsep3', 'undo', 'redo', 'make_read_only', 'alignment', 'borders', 'commentsAddEdit','commentsRemove'],
        filters: true,
        dropdownMenu: true
    };

    loadList();

    $(document).on("click", ".nav-wiget li a", function () {
        curId = $(this).attr('data_id');
        $('.nav-wiget .active').removeClass('active');
        $(this).parent().addClass('active');
        loadWiget(curId);

    });

    $(document).on("click", "#btnAddNew", function () {
        curId = 0;
        resetForm();
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

    $(document).on("click", "#btnDelete", function () {
        if (confirm("Bạn có chắt muốn xóa dữ liệu ?")) {
            let id = curId;
            $("#btnDelete").prop('disabled', true);
            deleteWiget(id);
        }
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
    alert(result);
}
