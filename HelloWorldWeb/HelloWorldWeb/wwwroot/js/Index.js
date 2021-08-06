$(document).ready(function () {
    // see https://api.jquery.com/click/

    //clearButton
    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $("#teamList").on("click", ".edit", function () {

        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal("show");

    })

    //disable createButton
    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });


    //create
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                var ind = result;
                //console.log(result);
                $("#teamList").append(
                    `<li class="member">
                        <span class="name">${newcomerName}</span>
                        <span class="edit fa fa-pencil"></span>
                        <span class="delete fa fa-remove" onClick="deleteMember(${ind})"></span>
                    </li>`
                );
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
            },
            error: function (err) {
                console.log(err);
            }
        })


    });
    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        var id = 5;
        var name = "6";
        $.ajax({
            url: "/Home/RenameMember",
            method: "POST",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                console.log(`succesful renamed ${id}`);
            }
        })
    })



    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })



});

function deleteMember(index) {

    $.ajax({
        url: "/Home/DeleteTeamMember",
        method: "DELETE",
        data: {
            "index": index
        },
        success: function (result) {
            console.log("deleete:" + index);
            location.reload();
        }
    })
};

