
$(document).ready(function () {
    
  

    $(document).on("click", "#js-contact-btn", function () {
        var field1 = '', field2 = '', field3 = '', field4 = '', field5 = '', field6 = '', field7 = '';
        field1 = $('txtFullName').val();
        field2 = $('txtEmail').val();
        field3 = $('txtPhone').val();
        field4 = $("#ddlCouse option:selected").text();
        saveInfo(field1, field2, field3, field4, field5, field6, field7);
    });

})


var saveInfo = function (field1, field2, field3, field4, field5, field6, field7) {
    let p = new methodParams();
    p.addParam("field1", field1);
    p.addParam("field2", field2);
    p.addParam("field3", field3);
    p.addParam("field4", field4);
    p.addParam("field5", field5);
    p.addParam("field6", field6);
    p.addParam("field7", field7);
    callMethod_2("RegInfo_Save", p, saveInfoCallback);
}

function saveInfoCallback(result) {
    $('#js-contact-result').show();
}

