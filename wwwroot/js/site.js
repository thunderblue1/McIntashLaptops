$(document).ready(function () {
    var url = "/Laptop/Toggle";
    var present = $("#mydiv").attr("data-present");

    $("#ToggleButton").on("click", (e) => {
        e.preventDefault();
        getResults(url);
    })
    if (present != null) {
        getResults("/Laptop/getResults");
    }
});

function getResults(myUrl) {
    $.ajax({
        type: 'POST',
        url: myUrl,
        contentType: 'application/json; charset=utf-8',
        cache: false,
        success: function (data) {
            $("#mydiv").html(data);
        },
        error: function () {

            $("#mydiv").html('Failed to load more content');
        }

    });
}