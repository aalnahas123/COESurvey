﻿


function showLoading() {
    var loadingOverlay = document.getElementById("loadingOverlay");
    loadingOverlay.classList.remove("d-none");
}

function hideLoading() {
    var loadingOverlay = document.getElementById("loadingOverlay");
    loadingOverlay.classList.add("d-none");
}






$(document).ready(function () {

    //$('.langing__more-btn').click(function () {

    //    $(this).next('.landing__survey-menu').toggle();
    //});

    var selectedLang = getLanguage();
    $('#ddLangs').val(selectedLang);

    $('#english').click(function () {
        changeLanguage('en');
    });

    $('#arabic').click(function () {
        changeLanguage('ar');
    });

});

function changeLanguage(lang) {


    $.ajax({
        type: "POST",
        url: "/Surveys/SetLanguage",
        data: { "value": lang },
        success: function (r) {


            window.location.reload();

        }
    });
};


function formatDateToDDMMYYYY(dateStr) {
    var date = new Date(dateStr);
    var day = ("0" + date.getDate()).slice(-2); // format day with leading zero
    var month = ("0" + (date.getMonth() + 1)).slice(-2); // format month with leading zero
    var year = date.getFullYear();
    return day + "/" + month + "/" + year;
}