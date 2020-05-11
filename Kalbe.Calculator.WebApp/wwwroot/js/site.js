$('#btnCalculate').click(function () {
    var val1 = $('#firstNumber').val();
    var val2 = $('#secondNumber').val();

    $.ajax({
        type: "POST",
        url: "Calculate",
        data: {
            mode: formMode,
            val1: val1,
            val2: val2
        },
        success: function (result) {
            if (result.message === "") {
                $('#lblResult').html("The result of " + val1 + " " + formMode + " " + val2 + " is <b>" + result.result + "</b>");
            } else {
                $('#lblResult').html(result.message);
            }
        }
    });
});

$('#btnReset').click(function () {
    $('#firstNumber').val('');
    $('#secondNumber').val('');
    $('#lblResult').html('');
});