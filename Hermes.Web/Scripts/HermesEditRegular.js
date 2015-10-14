$(function () {
    if ($('#KiawahLocation').val() == "Other") {
        $('#OtherAddress').show();
    }
    else {
        $('#OtherAddress').hide();
    }
    ToggleAddressFields = function () {
        var address = $('#KiawahLocation').val();
        if (address == "Other") {
            $("#OtherAddress").show();
        }
        else {
            $('#OtherAddress').hide();
        }
    };
    $(document).on('change', '#KiawahLocation', function (e) {
        return ToggleAddressFields();
    });

    $('#Members').selectpicker();
});