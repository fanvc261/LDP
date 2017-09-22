var curId = 0;
$(document).ready(function () {
    activeMenu('mn_seo');
    loadCategory();
    $(document).on("change", "#ddlCategory", function () {
        loadCategory();
    });

    $(document).on("click", "#btnSave", function () {
        let id = $('#ddlCategory').val();
            name = $('#txtName').val(),
            seName = $('#txtSeName').val(),
            metaTitle = $('#txtMetaTitle').val(),
            metaKeywords = $('#txtMetaKeywords').val(),
            metaDescription = $('#txtMetaDescription').val();
        $("#btnSave").prop('disabled', true);
        saveCategory(id, name, seName, metaTitle, metaKeywords, metaDescription);
    });

    $(document).on("keyup", "#txtName", function () {
        $('#txtSeName').val(getSeName($(this).val()));
        $('#txtSeName').parent().removeClass("is-empty");
    });
})

var loadCategory = function () {
    let id = $('#ddlCategory').val();
    let p = new methodParams();
    p.addParam("id", id);
    callMethod_1("Category_GetById", p, loadCategoryCallback);
}

var saveCategory = function (id, name, seName, metaTitle, metaKeywords, metaDescription) {
    let p = new methodParams();
    p.addParam("id", id);
    p.addParam("name", name);
    p.addParam("seName", seName);
    p.addParam("metaTitle", metaTitle);
    p.addParam("metaKeywords", metaKeywords);
    p.addParam("metaDescription", metaDescription);
    callMethod_1("Category_Update", p, saveCategoryCallback);
}


function loadCategoryCallback(result) {
    loadForm(result.data)
}

function saveCategoryCallback(result) {
    $("#btnSave").prop('disabled', false);
    alert(result);
}


function loadForm(data) {
    $('#txtName').val(data.Name);
    $('#txtSeName').val(data.SeName);
    $('#txtMetaTitle').val(data.MetaTitle);
    $('#txtMetaKeywords').val(data.MetaKeywords);
    $('#txtMetaDescription').val(data.MetaDescription);
    $('#seo-box .label-floating').removeClass("is-empty");
}