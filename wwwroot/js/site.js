$(document).ready(function () {
    var url = "/Laptop/Toggle";
    var present = $("#mydiv").attr("data-present");

    //Toggle between list and card display
    $("#ToggleButton").on("click", (e) => {
        e.preventDefault();
        getResults(url);
    })
    if (present != null) {
        getResults("/Laptop/getResults");
    }

    //Save the data in Edit form with save button
    $(document).on("click", '.save-button', (e) => {
        var url = '';
        var listPresent = $("#listed").attr("data-present");
        var cardPresent = $("#carded").attr("data-present");
        if (cardPresent == "present") {
            url = '/Laptop/SaveEditReturnNewCard';
        }
        if (listPresent == "present") {
            url = '/Laptop/SaveEditReturnNewRow';
        }
        console.log(url);
        // Get the values of the input fields and make a laptop JSON object.
        var Laptop = {
            "Id": $("#modal-input-id").val(),
            "Photo": $("#modal-input-photo").val(),
            "Name": $("#modal-input-name").val(),
            "Description": $("#modal-input-description").val(),
            "Price": $("#modal-input-price").val(),
            "Processor": $("#modal-input-processor").val(),
            "Ram": $("#modal-input-ram").val(),
            "driveSize": $("#modal-input-drivesize").val(),
            "graphicsCard": $("#modal-input-graphicscard").val(),
            "Weight": $("#modal-input-weight").val(),
            "operatingSystem": $("#modal-input-operatingsystem").val()
        }
        console.log("Saved:");
        console.log(Laptop);
        $.ajax({
            type: 'json',
            data: Laptop,
            url: url,
            success: function (data) {
                //Show the partial update for testing purposes.
                console.log(data);
                if (cardPresent == "present") {
                    console.log("YOU HAVE JUST BEEN CARDED.");
                    //Replace the proper card with the new data.
                    $("#card-number-" + Laptop.Id).replaceWith(data);
                    $("#card-number-" + Laptop.Id).hide().fadeIn(2000);

                }
                if (listPresent == "present") {
                    console.log("YOU HAVE JUST BEEN LISTED.");
                    $("#row-number-" + Laptop.Id).replaceWith(data);
                    $("#row-number-" + Laptop.Id).hide().fadeIn(2000);
                }
            }
        })
    });
    //Fill the Edit Form with data from chosen laptop
    $(document).on("click", ".edit-laptop-button", function () {
        console.log("You just clicked button number " + $(this).val());
        var laptopId = $(this).val();
        $.ajax({
            type: 'json',
            data: {
                "Id": laptopId
            },
            url: "/Laptop/ShowOneLaptopJSON",
            success: function (data) {
                console.log(data);

                //fill the input fields in the modal
                $("#modal-input-id").val(data.id);
                $("#modal-input-photo").val(data.photo);
                $("#modal-input-name").val(data.name);
                $("#modal-input-description").val(data.description);
                $("#modal-input-price").val(data.price);
                $("#modal-input-processor").val(data.processor);
                $("#modal-input-ram").val(data.ram);
                $("#modal-input-drivesize").val(data.driveSize);
                $("#modal-input-graphicscard").val(data.graphicsCard);
                $("#modal-input-weight").val(data.weight);
                $("#modal-input-operatingsystem").val(data.operatingSystem);
            }
        })
    });

    //Remove Card or TD Cell from row after delete
    $(document).on("click", ".delete-button", function (e) {
        e.preventDefault();
        var test = '';
        var listPresent = $("#listed").attr("data-present");
        var cardPresent = $("#carded").attr("data-present");
        if (cardPresent == "present") {
            test='Card';
        }
        if (listPresent == "present") {
            test='List';
        }
        console.log("The following was used:"+test);

        var Laptop = {"Id":$(this).val()}

        $.ajax({
            type: 'json',
            data: Laptop,
            url: 'Laptop/Delete',
            success: function (data) {
                //Show the partial update for testing purposes.
                console.log(data);
                if (cardPresent == "present") {
                    console.log("The card has been deleted.");
                    $("#card-number-" + Laptop.Id).hide().fadeOut(2000);
                    $("#card-number-" + Laptop.Id).remove();

                }
                if (listPresent == "present") {
                    console.log("The row has been deleted.");
                    $("#row-number-" + Laptop.Id).animate({ 'line-height':0}, 1000).hide(1);
                    $("#row-number-" + Laptop.Id).remove();
                }
            }
        })
    });
});

//Return List or Display partial view
//Based on session variable "list"
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