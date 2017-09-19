
$(document).ready(function () {
    $.material.init();
});

////////////////////////////////   DATA   /////////////////////////////////

var success = 'success', error = 'error';
var funcComplete = null, funcError = null;

function callMethod_1(n, p, c) {
    if (p == null) p = new methodParams();

    funcComplete = c;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: p.toString(),
        timeout: 30000,
        url: "/AdminService.asmx/" + n + "?date=" + new Date().getTime().toString(),
        success: function (r) {
            funcComplete(r.d);
        },
        error: function (x, z) {
        }
    });
};


function callMethod_2(n, p, c) {
    if (p == null) p = new methodParams();

    funcComplete = c;
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: p.toString(),
        timeout: 30000,
        url: "/DataService.asmx/" + n + "?date=" + new Date().getTime().toString(),
        success: function (r) {
            funcComplete(r.d);
        },
        error: function (x, z) {
        }
    });
};


function callMethod_3(n, p, c) {
    if (p == null) p = new methodParams();

    funcComplete = c;

    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: p.toString(),
        timeout: 30000,
        url: "/_TradeProposal/DataService.asmx/" + n + "?date=" + new Date().getTime().toString()
    }).done(function (data, status, xhr) {
        funcComplete(data.d);
    }).fail(function (jqXHR, textStatus) {

    });
};

function methodParams(i) {
    var pns = new Array();
    var pvs = new Array();

    this.addParam = function (n, v) {
        pns.push(n); pvs.push(v);
    };

    this.toString = function () {
        if (pns.length == 0) return "{}";

        var r = "{";
        for (var i = 0; i < pns.length; i++) r += pns[i] + ":'" + pvs[i] + "',";
        r = r.substr(0, r.length - 1);
        return r + "}";
    };
};

////////////////////////////////////////////////  EDITOR   //////////////////////////////

function InitEditor(editorid) {
    $(editorid).kendoEditor({
        tools: [
            "bold",
            "italic",
            "underline",
            "strikethrough",
            "justifyLeft",
            "justifyCenter",
            "justifyRight",
            "justifyFull",
            "insertUnorderedList",
            "insertOrderedList",
            "indent",
            "outdent",
            "createLink",
            "unlink",
            "insertImage",
            "insertFile",
            "subscript",
            "superscript",
            "tableWizard",
            "createTable",
            "addRowAbove",
            "addRowBelow",
            "addColumnLeft",
            "addColumnRight",
            "deleteRow",
            "deleteColumn",
            "viewHtml",
            "formatting",
            "cleanFormatting",
            "fontName",
            "fontSize",
            "foreColor",
            "backColor",
            "print"
        ],
        imageBrowser: {
            messages: {
                dropFilesHere: "Drop files here"
            },
            transport: {
                read: {
                    dataType: "json",
                    data: { path: '' },
                    url: "/ImageService.asmx/Read",
                    type: "POST"
                },
                destroy: {
                    dataType: "json",
                    url: "/ImageService.asmx/Destroy",
                    type: "POST"
                },
                create: {
                    dataType: "json",
                    url: "/ImageService.asmx/Create",
                    type: "POST"
                },
                thumbnailUrl: "/ImageService.asmx/Thumbnail",
                uploadUrl: "/Upload.ashx",
                imageUrl: "/ImageService.asmx/Image?path={0}"
            }
        },
        fileBrowser: {
            messages: {
                dropFilesHere: "Drop files here"
            },
            transport: {
                read: {
                    dataType: "json",
                    data: { path: '' },
                    url: "/FileService.asmx/Read",
                    type: "POST"
                },
                destroy: {
                    dataType: "json",
                    url: "/FileService.asmx/Destroy",
                    type: "POST"
                },
                create: {
                    dataType: "json",
                    url: "/FileService.asmx/Create",
                    type: "POST"
                },
                uploadUrl: "/Upload.ashx",
                fileUrl: "/FileService.asmx/File?fileName={0}"
            }
        }
    });
}


/////////////////////////   HTML ///////////////////////////////

function htmlEncode(value) {
    return $('<div/>').text(value).html();
}

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}


function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
