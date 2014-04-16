

function FillFacilities() {
    $.ajax({
        url: '/BusinessLayer/GetFacilities',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var ddlFacilities = $("#ddlFacilities");
            ddlFacilities.empty();
            $.each(data, function (i, facility) {
                ddlFacilities.append('<option value="' + facility.FacilityId + '">' + facility.Name + '</option>');
            });
        },
        rror: function () {
            alert('Failed to retrieve facilites.');
        }
    });
}

$(function () {
    FillFacilities();
});