var modalty = {};

modalty.tempId = Math.floor(Math.random() * 1000);

modalty.asyncTime = 1000;
modalty.request;

modalty.maskId = "mask" + modalty.tempId
, modalty.modalId = "modal" + modalty.tempId
, modalty.draggableId = "draggable" + modalty.tempId
, modalty.closeId = "close" + modalty.tempId
, modalty.savaId = "sava" + modalty.tempId
, modalty.cancelId = "cancel" + modalty.tempId
, modalty.asyncId = "async" + modalty.tempId + "From";

modalty.modal = function (mWidth, mTitle, mClose, mEvent, mAsyncUrl) {
    var html = "<div id=\"" + modalty.maskId + "\" class=\"modalty_mask\"></div>";
    html += "<div id=\"" + modalty.modalId + "\" class=\"modalty_main\" style=\"width:" + mWidth + "px;left:" + ($(window).width() - mWidth) / 2 + "px\">";
    html += "<div id=\"" + modalty.draggableId + "\" class=\"modalty_title\">";
    html += "<span>" + mTitle + "</span>";
    mClose ? (html += "<a id=\"" + modalty.closeId + "\" class=\"close modalty_close\" title=\"\u5173\u95ed\" href=\"javascript:modalty.close();\">&times;</a>") : "";
    html += "</div>";
    html += "<form id=\"" + mEvent + "From\">";
    html += "<div id=\"" + modalty.asyncId + "\" class=\"modalty_form\">";
    html += "</div>";
    html += "<div class=\"modalty_button_group\">";
    html += "<button id=\"" + modalty.savaId + "\" class=\"btn btn-primary btn-sm modalty_sava\" type=\"submit\">\u4fdd\u5b58</button>";
    mClose ? (html += "<a id=\"" + modalty.cancelId + "\" class=\"btn btn-default btn-sm\" href=\"javascript:modalty.close();\">\u53d6\u6d88</a>") : "";
    html += "</div>";
    html += "</form>";
    $("body").prepend(html);
    modalty.load(mEvent, mAsyncUrl);
}, modalty.load = function (mEvent, mAsyncUrl) {
    modalty.request = $.ajax({
        url: "/action/" + mAsyncUrl + ".ashx?action=" + mEvent + "&districtCharId=e6c2853e-5d5c-46a6-988b-85853483f676",
        cache: true,
        timeout: modalty.asyncTime,
        dataType: "html",
        beforeSend: function () {
            $("#" + modalty.asyncId).html("\u8868\u5355\u52a0\u8f7d\u4e2d...");
            $("#" + modalty.savaId).attr("disabled", "disabled");
        },
        success: function (data) {
            $("#" + modalty.asyncId).html(data);
            $("#" + modalty.savaId).removeAttr("disabled");
            $("#" + modalty.modalId).draggable({
                handle: "#" + modalty.draggableId,
                containment: "#" + modalty.maskId,
                scroll: false
            });
            $("#" + modalty.draggableId).hover(function () {
                $(this).css("cursor", "move");
            });
        },
        error: function () {
            $("#" + modalty.asyncId).html("\u8868\u5355\u52a0\u8f7d\u5931\u8d25 <a href=\"javascript:modalty.load('" + mEvent + "','" + mAsyncUrl + "');\">[\u91cd\u8bd5]</a>");
            $("#" + modalty.savaId).attr("disabled", "disabled");
        }
    });
}, modalty.close = function () {
    $("#" + modalty.maskId).remove();
    $("#" + modalty.modalId).remove();
    modalty.request.abort();
};