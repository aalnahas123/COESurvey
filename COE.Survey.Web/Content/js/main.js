


function showLoading() {
    var loadingOverlay = document.getElementById("loadingOverlay");
    loadingOverlay.classList.remove("d-none");
}

function hideLoading() {
    var loadingOverlay = document.getElementById("loadingOverlay");
    loadingOverlay.classList.add("d-none");
}

function getLanguage(isar) {

    var isar = '@CultureHelper.IsArabic';

    if (isar == 'True') {
        return 'ar';
    }

    return 'en';
};




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