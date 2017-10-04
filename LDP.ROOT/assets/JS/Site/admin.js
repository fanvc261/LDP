var editor, curId = 0, curPageId;
$(document).ready(function () {
    
    $(document).on("click", ".wiget-md-edit .wiget-content-edit-inline", function () {
        initEdit(this);
    });

    $(document).on("click", ".wiget-md-edit .wiget-content-cancel-inline", function () {
        var id = $(this).parent().parent().attr('data-id');
        cancelEdit(this);        
        loadWiget(id);
    });

    $(document).on("click", ".wiget-md-edit .wiget-content-save-inline", function () {
        saveEdit(this);     
    });

    $(document).on("click", ".wiget-md-edit .wiget-content-edit", function () {
        var id = $(this).parent().parent().attr('data-id');
        showAdminPopup('/LDPAdmin/Popup/pupWiget.aspx?id=' + id);
    });

    $(document).on("change", "#chkAdminMode", function () {
        updateMode($(this).is(':checked')?1:0);
    });
    
    $(document).on("click", ".icon-logout", function () {
        logout();
    });
})

var loadWiget = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Wiget_GetById", p, loadWigetCallback);
}

var saveWiget = function (id, content) {
    let p = new methodParams();
    p.addParam("id", id);
    p.addParam("content", content);
    callMethod_1("Wiget_UpdateContent", p, saveWigetCallback);
}

var updateMode = function (mode) {
    let p = new methodParams();
    p.addParam("mode", mode);
    callMethod_1("User_UpdateMode", p, updateModeCallback);
}

var logout = function (mode) {
    let p = new methodParams();
    callMethod_1("User_Logout", p, updateModeCallback);
}

function loadWigetCallback(result) {
    $('.wiget-control[data-id="' + result.data.Id + '"] > .wiget-content-body').html(htmlDecode(result.data.Content));
}

function saveWigetCallback(result) {
}

function updateModeCallback(result) {
    window.location.reload(false);
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

function saveEdit(ctr) {
    let objParent = $(ctr).parent().parent();
    let objContent = $(objParent).find('> .wiget-content-body')   
    var id = $(objParent).attr('data-id');
    var content = htmlEncode(objContent.data("kendoEditor").value());
    saveWiget(id, content);

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
    $(ctr).parent().append('<i class="material-icons wiget-content-button wiget-content-cancel-inline icons-inline">clear</i>');
    $(ctr).parent().append('<i class="material-icons wiget-content-button wiget-content-save-inline icons-inline">done</i>');
    objContent.kendoEditor({
        tools: [
        ]
    })
}