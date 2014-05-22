
// Round/Create functions
//~/js/Round.js

function ToggleCourse() {
    var chkHBH = $("#Number_Of_Holes");
    var ddlcourse2 = $("#ddlCourse2");
    if (chkHBH.is(":checked")) {
        ddlcourse2.show();
    } else {
        ddlcourse2.hide();
    }
}

$(function () {
    $("#Date").datepicker();
    $("#Number_Of_Holes").change(ToggleCourse);
    ToggleCourse();
});