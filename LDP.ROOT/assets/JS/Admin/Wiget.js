var editor, curId = 0, curPageId;
$(document).ready(function () {
    InitEditor("#txtContent");
    editor = $("#txtContent").data("kendoEditor");

    curPageId = getUrlVars()["pageid"];
    if (curPageId != null && curPageId != '' && curPageId != '0') {
    }
    else {
        curPageId = '0';
    }
    resetForm();

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
})

var loadWiget = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Wiget_GetById", p, loadWigetCallback);
}

var saveWiget = function (id, name, pageId, rank, status, option, classBody, containerGuid, content) {
    let p = new methodParams();
    p.addParam("id", id);
    p.addParam("name", name);
    p.addParam("pageId", pageId);
    p.addParam("rank", rank);
    p.addParam("status", status);
    p.addParam("option", option);
    p.addParam("classBody", classBody);
    p.addParam("containerGuid", containerGuid);
    p.addParam("content", content);
    callMethod_1("Wiget_Update", p, saveWigetCallback);
}


function loadWigetCallback(result) {
    loadForm(result.data)
}

function saveWigetCallback(result) {
    $("#btnSave").prop('disabled', false);
    alert(result);
}

function resetForm() {
    $('#wiget-box .label-floating').addClass("is-empty");
    $('#txtName').val('');
    $('#txtRank').val('');
    $('#cbHide').prop('checked', false);
    $('#cbAllPage').prop('checked', false);
    $('#txtBodyClass').val('');
    $('#ddlContainer').val('');
    $('#editTitle').html('Thêm mới');
    $("#btnSave").html('Thêm mới');
    $("#btnDelete").hide();
    editor.value('');

}

function loadForm(data) {
    $('#wiget-box .label-floating').removeClass("is-empty");
    $('#txtName').val(data.Name);
    $('#txtRank').val(data.Rank);
    $('#cbHide').prop('checked', (data.Status & 1) > 0 ? false : true);
    $('#cbAllPage').prop('checked', (data.PageId > 0) ? false : true);
    $('#txtBodyClass').val(data.ClassBody);
    $('#ddlContainer').val(data.ContainerGuid);
    $('#editTitle').html('Chi tiết');
    $("#btnSave").html('Cập nhật');
    $("#btnDelete").show();
    editor.value(htmlDecode(data.Content));
}