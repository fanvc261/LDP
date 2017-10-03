var editor, curId = 0;
$(document).ready(function () {
    InitEditor("#txtContent");
    editor = $("#txtContent").data("kendoEditor");

    curId = getUrlVars()["id"];
    if (curId != null && curId != '' && curId != '0') {
    }
    else {
        curId = '0';
    }
    

    $(document).on("click", "#btnCancel", function () {
        window.parent.closeAdminPopup();
    });

    $(document).on("click", "#btnSave", function () {
        let id = curId,
            content = htmlEncode(editor.value());
        $("#btnSave").prop('disabled', true);
        saveWiget(id, content);
    });

})

var saveWiget = function (id, content) {
    let p = new methodParams();
    p.addParam("id", id);
    p.addParam("content", content);
    callMethod_1("Wiget_UpdateContent", p, saveWigetCallback);
}

function saveWigetCallback(result) {
    $("#btnSave").prop('disabled', false);
    window.parent.location.reload(true);
}

