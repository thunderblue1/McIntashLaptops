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
        if (listPresent != "present" && cardPresent!="present") {
            url ='/Laptop/SaveEditReturnDetails'
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
                $("#editForm").modal('toggle');
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
                if (listPresent != "present" && cardPresent != "present") {
                    console.log("LaptopModel saved.  Nothing returned.");
                    $("#details").html(data);
                    $("#details").hide().fadeIn(2000);
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

    //Clear Create Laptop Form
    $(document).on("click", ".clear-form-button", function () {
        //Fill the input fields in the modal
        $("#modal-create-id").val("");
        $("#modal-create-photo").val("");
        $("#modal-create-name").val("");
        $("#modal-create-description").val("");
        $("#modal-create-price").val("");
        $("#modal-create-processor").val("");
        $("#modal-create-ram").val("");
        $("#modal-create-drivesize").val("");
        $("#modal-create-graphicscard").val("");
        $("#modal-create-weight").val("");
        $("#modal-create-operatingsystem").val("");
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
            url: '/Laptop/Delete',
            success: function (data) {
                //Show the partial update for testing purposes.
                console.log(data);
                if (cardPresent == "present") {
                    console.log("The card has been deleted.");
                    $("#card-number-" + Laptop.Id).fadeOut(1000);
                    setTimeout(function () {
                        $("#card-number-" + Laptop.Id).remove();
                    },1000)

                }
                if (listPresent == "present") {
                    console.log("The row has been deleted.");
                    $("#row-number-" + Laptop.Id).fadeOut(1000);
                    setTimeout(function () {
                        $("#row-number-" + Laptop.Id).remove();
                    }, 1000)
                }
            }
        })
    });

    //Create button in modal clicked

    $(document).on("click", ".create-button", function (e) {
        e.preventDefault
        var test = '';
        var listPresent = $("#listed").attr("data-present");
        var cardPresent = $("#carded").attr("data-present");
        if (cardPresent == "present") {
            test = 'Card';
        }
        if (listPresent == "present") {
            test = 'List';
        }
        console.log("The following was used:" + test);

        var Laptop = {
            "Id":1,
            "Photo": $("#modal-create-photo").val(),
            "Name": $("#modal-create-name").val(),
            "Description": $("#modal-create-description").val(),
            "Price": $("#modal-create-price").val(),
            "Processor": $("#modal-create-processor").val(),
            "Ram": $("#modal-create-ram").val(),
            "driveSize": $("#modal-create-drivesize").val(),
            "graphicsCard": $("#modal-create-graphicscard").val(),
            "Weight": $("#modal-create-weight").val(),
            "operatingSystem": $("#modal-create-operatingsystem").val()
        }
        console.log(Laptop);

        var bad = false;
        $.each(Laptop, function (i, n) {
            if (n == "" || (n.length>255&&i!="Description")) {
                bad = true;
                //alert(" The following property does not conform to requirements, Name: " + i + ", Value: " + n+", Length: "+n.length);
            }
        });

        if (bad==true) {
            $("#createValidation").html("All inputs need to have at least 1 character and no more than 255 characters.");
        } else {

            $.ajax({
                type: 'json',
                data: Laptop,
                url: '/Laptop/CreateLaptop',
                success: function (data) {
                    $("#createForm").modal('toggle');
                    //Show the partial update for testing purposes.
                    console.log(data);

                    if (cardPresent == "present") {
                        console.log("Adding new card to container.");
                        $("#carded").append(data);
                        $("#carded>div.card:last").hide().fadeIn(2000);
                    }
                    if (listPresent == "present") {
                        console.log("Adding new row to list.");
                        $('#prettyTable>tbody:last').append(data);
                        $('#prettyTable>tbody>tr:last').hide().fadeIn(2000);
                    }
                }
            })
        }
    });

    $(document).on("click", ".remove-from-cart-button", function (e) {
        e.preventDefault();
        var myId = $(this).val();
        myUrl = '/Shop/RemoveFromCart';
        $.ajax({
            type: 'POST',
            data: { 'id': myId },
            url: myUrl,
            success: function (data) {
                if (!$.trim(data)) {
                    $("#row-number-" + myId).fadeOut(1000);
                    setTimeout(function () {
                        $("#row-number-" + myId).remove()
                    },1000)
                    updateTotal();
                } else {
                    $("#row-number-" + myId).replaceWith(data);
                    $("#row-number-" + myId).hide().fadeIn(1000);
                    updateTotal();
                }
            }
        });
    });

    $(document).on("click", ".add-one-to-cart-button", function (e) {
        e.preventDefault();
        var myId = $(this).val();
        myUrl = '/Shop/AddOneToCart';
        $.ajax({
            type: 'POST',
            data: { 'id': myId },
            url: myUrl,
            success: function (data) {
                $("#row-number-" + myId).replaceWith(data);
                $("#row-number-" + myId).hide().fadeIn(1000);
                updateTotal();
            }
        });
    });

    $(document).on("click", ".add-to-cart-button", function (e) {
        e.preventDefault();
        var myId = $(this).val();
        myUrl = '/Shop/AddToCart';
        $.ajax({
            type: 'POST',
            data: { 'id': myId },
            url: myUrl,
            success: function (data) {
                console.log(data);
                $("#cart-message").html("The following item was added to your cart: Name:" + data.name + ", Id: " + data.id+", Quantity: "+data.quantity);                
            }
        });
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

function updateTotal() {
    myUrl = '/Shop/getTotalJson';
    $.ajax({
        type: 'POST',
        url: myUrl,
        success: function (data) {
            console.log(data);
            $("#calculate-total").html("$" + data);
        }
    });
}