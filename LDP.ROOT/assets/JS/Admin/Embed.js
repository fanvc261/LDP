var curId = 2;
$(document).ready(function () {
    loadEmbed(1);
    loadEmbed(2);

    $(document).on("click", "#embed-box .nav-pills li a", function () {
        curId = $(this).attr('data-value');
        $('.nav-pills .active').removeClass('active');
        $(this).parent().addClass('active');
        loadEmbed(curId);

    });

    $(document).on("click", "#btnSave", function () {
        let id = curId;
        name = $('#txtName').val(),
        content = htmlEncode($('#txtEmbed').val());
        $("#btnSave").prop('disabled', true);
        saveEmbed(1, name);
        saveEmbed(id, content);
    });
})

var loadEmbed = function (id) {
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Setting_GetEmberById", p, loadEmbedCallback);
}

var saveEmbed = function (id, content) {
    let p = new methodParams();
    p.addParam("id", id);
    p.addParam("content", content);
    callMethod_1("Setting_UpdateEmbed", p, saveEmbedCallback);
}


function loadEmbedCallback(result) {
    loadForm(result.data)
}

function saveEmbedCallback(result) {
    $("#btnSave").prop('disabled', false);
    alert(result);
}


function loadForm(data) {
    if (data.Name == "Site.Title")
        $('#txtName').val(data.Content);
    else
        $('#txtEmbed').val(htmlDecode(data.Content));
    $('#embed-box .label-floating').removeClass("is-empty");
}