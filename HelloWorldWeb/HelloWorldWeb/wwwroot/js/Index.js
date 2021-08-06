$(document).ready(function () {
    // see https://api.jquery.com/click/

    //disable createButton when the field is empty
    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });

    //clearButton
    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });


    //add team member button
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                var ind = result;

                $("#teamList").append(
                    `<li class="member">
                        <span class="name">${newcomerName}</span>
                        <span class="edit fa fa-pencil"></span >
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

    //open the Modal View
    $("#teamList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');

        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();

        $('#editTeamMember').attr("data-member-id", id);
        $('#memberName').val(currentName);
        $('#editTeamMember').modal('show');

    })

    //edit team member by pressing submit button in modal view
    $("#editTeamMember").on("click", "#submit", function () {

        var id = $("#editTeamMember").attr('data-member-id');
        var newName = $("#memberName").val();
        console.log('submit changes to server');

        $.ajax({
            url: "/Home/EditTeamMember",
            method: "POST",
            data: {
                "id": id,
                "name": newName
            },
            success: function (result) {
                console.log(`edit: ${id}`);
                location.reload();
            }
        })
    })

    //cancel the edit member
    $("#editTeamMember").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

});

//delete button member
function deleteMember(id) {

    $.ajax({
        url: "/Home/DeleteTeamMember",
        method: "DELETE",
        data: {
            "id": id
        },
        success: function (result) {
            console.log("deleete:" + id);
            location.reload();
        }
    })
};