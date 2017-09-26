var editor, curId = 0, curPageId;
$(document).ready(function () {
    
    $(document).on("click", ".wiget-md-edit .wiget-content-edit-inline", function () {
        initEdit(this);
    });

    $(document).on("click", ".wiget-md-edit .icons-inline", function () {
        var id = $(this).parent().parent().attr('data-id');
        cancelEdit(this);        
        loadWiget(id);
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

var deleteWiget = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Wiget_DeleteById", p, deleteWigetCallback);
}

function loadWigetCallback(result) {
    $('.wiget-control[data-id="' + result.data.Id + '"] > .wiget-content-body').html(htmlDecode(result.data.Content));
}

function saveWigetCallback(result) {
    $("#btnSave").prop('disabled', false);
    alert(result);
}

function deleteWigetCallback(result) {
    $("#btnDelete").prop('disabled', false);
    alert(result);
}

function cancelEdit(ctr) {
    let objParent = $(ctr).parent().parent();
    let objContent = $(objParent).find('> .wiget-content-body')
    $(ctr).parent().removeClass('actions-editting');
    $(ctr).parent().find('.icons-inline').remove();
    objContent.removeAttr('data-role');
    objContent.removeAttr('contenteditable');
    objContent.removeClass('k-widget k-editor k-editor-inline');
    objContent.data("kendoEditor").destroy();

}

function initEdit(ctr) {
    let objParent = $(ctr).parent().parent();
    let objContent = $(objParent).find('> .wiget-content-body');
    $(ctr).parent().addClass('actions-editting');
    $(ctr).parent().append('<i class="material-icons wiget-content-button wiget-content-cancel-inline icons-inline">filter_center_focus</i>');
    $(ctr).parent().append('<i class="material-icons wiget-content-button wiget-content-save-inline icons-inline">filter_center_focus</i>');
    objContent.kendoEditor({
        tools: [
        ]
    })
}