
function validateString(input) {

    var path = "api/Validator/" + input;
    $.get(path, function (result) {
        var history = result.history;
        $('#history').find('tbody').append(
            "<tr><td>" + history.TimeStamp +
            "</td><td>" + history.Input +
            "</td><td>" + history.Output +
            "</td><td>" + history.Valid +
            "</td></tr>");

    });
}

function allLetter(input, message) {
    var letters = /^[a-z]+$/;
    if (input.match(letters)) {
        return true;
    }
    else {
        alert(message);
        return false;
    }
}
$(document).ready(function ()
{
    $("#submit").click(function () {
        var input = $("#input").val().trim();

        if (input.length > 0) {
            if (allLetter(input, 'Ingrese solo Letras minúsculas'))
            {
                validateString(input);
                $("#input").val('');
            }
        }
    });

});

