$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();

        // Remember string interpolation

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: { "name": newcomerName },
            success: function (result) {
                $("#team-list").append(`<li>${newcomerName}</li>`),
                    $("#nameField").val("")
            }
        })

        $("#nameField").val("");
    })
});