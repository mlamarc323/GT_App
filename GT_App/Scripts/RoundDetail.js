//RoundDetail/Create functions

        function ParSave() {

            var score = $("#Score");
            var par = $("#Par");
            var putts = $("#Putts");
            var parSaveValue = $("#ParSave");

            if (score.val() <= par.val()) {
                if ((par.val() - putts.val()) <= 1) {
                    console.log("Here");
                    // golfer saved par after missing GIR
                    parSaveValue.val = true;
                    parSaveValue.text = true;

                }

                // golfer hit GIR
                parSaveValue.val = null;
                parSaveValue.text = null;

            }

            // golfer failed to save par after missing GIR
            parSaveValue.val = false;
            parSaveValue.text = false;

        }

$(function () {
    $("#Date").datepicker();
});



$(document).ready(function () {
    ParSave().onkeyup;


})

