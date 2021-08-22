var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.on("NewTeamMemberAdded", function (name, id) {
    console.log(`New team member added: ${name}, ${id}`);
    createNewcomer(name, id);
});

connection.start().then(function () {
    console.log("SignalR connection started");
}).catch(function (err) {
    return console.error(err.toString());
});


$(document).ready(function () {
    // see https://api.jquery.com/click/

    deleteMember();

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

                $("#teamList").append(
                    `<li class="member" data-member-id="${result}">
                        <span class="memberName">${newcomerName}</span>
                        <span class="edit fa fa-pencil" onclick="editMember()"></span>
                        <span class="delete fa fa-remove"></span ></>
                    </li>`
                );
                
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
                deleteMember();
                editMember();
            }
        })
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
                console.log(`edited the member: ${id}`);
                location.reload();
            }
        })
    })

    //cancel the edit member
    $("#editTeamMember").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

});

function editMember() {
    //open the Modal View
    $("#teamList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();

        $('#editTeamMember').attr("data-member-id", id);
        $('#memberName').val(currentName);
        $('#editTeamMember').modal('show');

    })
}


//delete button member
function deleteMember() {
    $(".delete").off("click").click(function () {
        var id = $(this).parent().attr("data-member-id");
        $.ajax({
            url: "/Home/DeleteTeamMember",
            method: "DELETE",
            data: {
                "id": id
            },
            success: function (result) {
                console.log("deleted member:" + id);
                $(this).parent().remove();
                location.reload();
            }
        })
    })
}

function createNewcomer(name, id) {
    // Remember string interpolation
    $("#teamMembers").append(`
            <li class="member" data-member-id="${id}">
                <span class="memberName" >${name}</span>
                <span class="edit fa fa-pencil" onclick="editMember()"></span>
                <span class="delete fa fa-remove"></span>
            </li>`
    );
}
$("#clear").click(function () {
    $("#newcomer").val("");
})