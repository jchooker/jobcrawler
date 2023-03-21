$(document).ready(function () {
    GetAjax("platforms").done(function (d) {
        var ct = 0;
        $.each(d, function (i, o) {
            $('<option /> ').text(d[i]).val(ct.toString()).appendTo('#job-platform');
            ct++;
        });
    });
    OtherToggle();
});

function GetAjax(whichSrc) {
    var settings = {
        "url": "../data/" + whichSrc + ".json",
        "method": "GET"
    }
    return $.ajax(settings);
}

function OtherToggle() {
    $('#job-platform').on('change', function () {
        console.log("changed");
        var optionSel = $('option:selected', this);
        if (optionSel.val() === "4") { //"Other" row works on both pages --- v1 just needs to append
            //what's entered here to "Notes"
            $('#alt-row').attr("hidden", false);
        }
        else if ((optionSel.val() !== "4") && ($('#alt-row').is(':visible'))) {
            $('#alt-row').attr("hidden", true);
        }
    });
}
