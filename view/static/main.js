require.config({
    baseUrl: "/",
    paths: {
        "jquery": "lib/jquery/2.2.3/jquery.min",
        "async_modal": "static/js/async_modal"
    }
});

require(["jquery", "async_modal"], function($, modal) {

    $("html").click(function() {
        modal.load();
        modal.open();
        modal.close();
    });
});