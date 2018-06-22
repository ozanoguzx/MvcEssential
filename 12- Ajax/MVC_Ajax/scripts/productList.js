$("document").ready(function () {
    var loading = function () {
        $("#loading").fadeIn(1000);
    }

    var unloading = function () {
        $("#loading").fadeOut(1000);
    }

    loading();

    var getProductData = function () {
        $.ajax({
            type: "get",
            url: "GetProductsList",
            success: function (data) {
                $("#resultHtml").html(data);
                unloading();
            },
            error: function (msg) {
                // alert(msg);
                console.log(msg);
                unloading();
            }
        });
    }

    setTimeout(function () {
        getProductData();
    }, 5000);

    //$("#getDataButton").on("click", function () {
    //    event.preventDefault();
    //    getProductData();
    //});
});