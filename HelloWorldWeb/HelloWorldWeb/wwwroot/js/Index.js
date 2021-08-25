$(document).ready(function () {
    // see https://api.jquery.com/click/
    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    setDelete();
    setEdit();

    connection.on("NewTeamMemberAdded", createNewLine);
    connection.on("DeleteTeamMember", deleteMember);
    connection.on("EditTeamMember", editMember);

    connection.start().then(function () {
    }).catch(function (err) {
        return console.error(err.toString());
    });

    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });

    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({

            method: "GET",
            url: "/Home/GetCount",

            success: (resultGet) => {
                $.ajax({
                    method: "POST",
                    url: "/Home/AddTeamMember",
                    data: {
                        "name": newcomerName
                    },
                    success: (resultPost) => {
                        $("#nameField").val("");
                        $('#createButton').prop('disabled', true);
                    }
                })
            }
        });
    })

    $("#editTeamMember").on("click", "#submit", function () {

        var id = $('#editTeamMember').attr("data-member-id");
        var name = $('#memberName').val();

        $.ajax({
            url: "/Home/EditTeamMember",
            method: "POST",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
            }
        })
    })


    $("#editTeamMember").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
});

function setDelete() {
    $(".delete").off("click").click(function () {
        var id = $(this).parent().attr("data-member-id");
        $.ajax({
            method: "DELETE",
            url: "/Home/DeleteTeamMember",
            data: {
                "id": id
            },
            success: (result) => {
                console.log("delete:" + id);
            }
        })
    }
    );
}

function setEdit() {
    $("#teamList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editTeamMember').attr("data-member-id", id);
        $('#memberName').val(currentName);
        $('#editTeamMember').modal('show');
    })
}

var createNewLine = (name, id) => {
    $("#teamList").append(`<li class="member" data-member-id="${id}">
                        <span class="memberName">${name}</span>
                        <span class="edit fa fa-pencil"></span>
                        <span class="delete fa fa-remove" id="deleteMember"></span>
                      </li>`);
    setDelete();
    setEdit();
}

var deleteMember = (id) => {
    $(`li[data-member-id=${id}]`).remove();
}

var editMember = (name, id) => {
    $(`li[data-member-id=${id}]`).find(".memberName").text(name);
}