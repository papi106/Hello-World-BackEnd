// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    setDelete();

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
                        "teamMember": newcomerName
                    },
                    success: (resultPost) => {
                        $("#teamList").append(
                            `<li class="member" id="${resultGet}">
                        <span class="memberName">${newcomerName}</span>
                        <span class="edit fa fa-pencil"></span>
                        <span class="delete fa fa-remove" id="deleteMember"></span>
                        
                             </li>`);
                        $("#nameField").val("");
                        $('#createButton').prop('disabled', true);
                        setDelete();
                    }
                })
            }
        });
    })

});
function setDelete() {
    $(".delete").off("click").click(function () {
        var index = $("#deleteMember").parent().attr("id");

        $.ajax({
            method: "DELETE",
            url: "/Home/DeleteTeamMember",
            data: {
                "index": index
            },
            success: (result) => {
                $(this).parent().remove();
            }
        })
    }
    );
}