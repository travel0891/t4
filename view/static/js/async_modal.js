define(function () {

    var modal = {};

    modal.asyncTime = 1000, modal.showClose = true, modal.asyncRequest, modal.viewMask, modal.viewMian;

    modal.load = function () { }, modal.open = function () { }, modal.close = function () { };

    return {
        load: modal.load,
        open: modal.open,
        close: modal.close
    };
});