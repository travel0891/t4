define(function () {

    var modal = {};

    modal.asyncTime = 1000, modal.showClose = true, modal.asyncRequest, modal.viewMask, modal.viewMian;

    modal.load = function () {
        $("body").append("load ");
    }, modal.open = function () {
        $("body").append("open ");
    }, modal.close = function () {
        $("body").append("close ");
    };

    return {
        load: modal.load,
        open: modal.open,
        close: modal.close
    };
});