$(function () {
    $('#Location').hide()
    $(document).on('change', '#AdditionalId', function (e) {
        return ToggleAddressFields();
    });
    ;

    ToggleAddressFields = function () {
        var s = "Shuttle";
        var address = $('#AdditionalId').val();
        if (address === "Shuttle Stop") {
            $("#Location").show();
        }
        else {
            $('#Location').hide();
        }
    };
   


    
});
