//Local Resources
var localResources = {
    ar: {
        CharactersRemaining: "أحرف متبقية",
        DeleteConfirm: "هل أنت متأكد انك تريد الحذف؟",
        ChangeLangDescription: "حول إلى اللغة العربية",
        Arabic: "العربية",
        English: "الإنجليزية",
        LoadingText: "جاري التحميــل ...",
        Ok: "موافق",
        Cancel: "إلغاء"
    },
    en: {
        CharactersRemaining: "characters remaining",
        DeleteConfirm: "Are you sure you want to delete?",
        ChangeLangDescription: "Switch to English language",
        Arabic: "Arabic",
        English: "English",
        LoadingText: "Loading ...",
        Ok: "Ok",
        Cancel: "Cancel"
    }
};




$(document).ready(function () {


    $('ul.tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');

        $('ul.tabs li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    });
});

String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.replace(new RegExp(search, 'g'), replacement);
};

var $util = $util || {};

$util.setCookie = function (name, value, days) {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
};

$util.readCookie = function (name) {
    var nameEq = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length, c.length);
    }
    return null;
};

$util.eraseCookie = function (name) {
    $util.setCookie(name, "", -1);
}


$util.getCurrentLang = function () {
    var currentLang = 'ar';
    var lcidFromCookie = $util.readCookie("LCID");
    var langFromHtmlTag = $('html').attr('lang');

    if (lcidFromCookie !== undefined && lcidFromCookie !== "") {
        currentLang = (lcidFromCookie === '1025') ? 'ar' : 'en';
    } else if (langFromHtmlTag !== undefined && langFromHtmlTag !== "") {
        currentLang = langFromHtmlTag;
    }

    return currentLang;
};



$util.currentLang = $util.getCurrentLang();
$util.isArabic = $util.getCurrentLang() === 'ar';
$util.isRtl = $util.isArabic;
$util.LangUrl = $util.isArabic ? "" : "/en";

$util.getLocalString = function (key) {
    return localResources[$util.currentLang][key];
};

$util.deleteConfirm = function () {
    return window.confirm($util.getLocalString("DeleteConfirm"));
};

$util.applyAutoPostBackAttribute = function () {
    $('[autopostback=true]').change(function () {

        $(this).closest('form').submit();
    });
};

// get the url from URL Fields which their value format is [URL], [Description]
$util.getUrlFromSPUrlField = function (url) {
    url = (url) ? $.trim(url.split(',')[0]) : url;
    return url;
}

$util.getSPCurrentSiteUrl = function () {
    var href = document.location.href.toLocaleLowerCase();
    return href.substring(href.indexOf('/' + $util.currentLang), href.lastIndexOf('/')).replace('Pages', '').replace('pages', '');
}


$util.initLangSwitcher = function (elementId) {

    elementId = elementId ? elementId : "lang-switcher";
    var langSwitcherAnchor = $("#" + elementId);

    langSwitcherAnchor.attr("title", $util.isArabic
        ? localResources.en.ChangeLangDescription
        : localResources.ar.ChangeLangDescription);

    langSwitcherAnchor.text($util.isArabic
        ? localResources.en.English
        : localResources.ar.Arabic);

    langSwitcherAnchor.click(function (e) {
        if ($util.isArabic) {
            $util.setCookie("LCID", "1033");
        } else {
            $util.setCookie("LCID", "1025");
        }

        window.location = window.location.href;
        e.preventDefault();
    });
};



//allpy max length automatically from mvc vaidation attribute string
$util.applyMaxLengthAttributes = function () {
    $("input[data-val-length-max], textarea[data-val-length-max]").each(function () {
        var element = $(this);
        element.attr("maxlength", element.data().valLengthMax);
    });
};

//character countdown in textarea
$util.textAreasCharCountDown = function () {
    //$('textarea').bind('input propertychange', function () {       
    //});

    $('textarea').keyup(function () {
        var textArea = $(this);

        var maxLength = textArea.attr('maxlength');
        if (!maxLength) {
            return;
        }

        //JavaScript is treating a newline as one character rather than two so when I try to insert a "max length" string into the database I get an error.
        //Detect how many newlines are in the textarea, then be sure to count them twice as part of the length of the input.
        var newlines = (textArea.val().match(/\n/g) || []).length;
        if (textArea.val().length + newlines > maxLength) {
            textArea.val(textArea.val().substring(0, maxLength - newlines));
        }

        var length = textArea.val().length;
        length = maxLength - length - newlines;

        if (!textArea.next('.textarea-countdown').length) {
            $('<span class="textarea-countdown help-block" style="direction:' + ($util.isRtl ? 'rtl' : 'ltr') + ';"><span>').insertAfter(textArea);
        }

        textArea.next('.textarea-countdown').text(length + ' ' + $util.getLocalString('CharactersRemaining'));
    });
};

$util.htmlDecode = function (encodedString) {
    var textArea = document.createElement('textarea');
    textArea.innerHTML = encodedString;
    return textArea.value;
};

$util.getParameterByName = function (name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
};

$util.htmlEncode = function (value) {
    //create a in-memory div, set it's inner text(which jQuery automatically encodes)
    //then grab the encoded contents back out.  The div never exists on the page.
    return $('<div/>').text(value).html();
};

$util.htmlDecode = function (value) {
    return $('<div/>').html(value).text();
};

$util.truncateString = function truncate(string, count, suffix) {
    if (string === undefined || string === null)
        return "";
    if (string.length > count)
        return string.substring(0, string.substring(0, count).lastIndexOf(" ")) + suffix;
    else
        return string;
};

$util.stringHasScriptTag = function (string) {
    var patt = new RegExp("<(.|\n)*?>");
    return patt.test(string);
};

$util.getTimeSuffix = function (time) {

    if ($util.currentLang === "ar")
        return time.replace(/am/g, " ص ").replace(/pm/g, " م ");
    else
        return time;
};

$util.showOverlay = function (loadingText) {

    var loadingText = $util.isArabic ? localResources['ar']['LoadingText'] : localResources['en']['LoadingText'];

    if ($("#divOverlay") && $("#divOverlay").length) {
        $("#divOverlay").show();
        return;
    }

    var divOverlay = '<div id="divOverlay" class="loader-overlay" style="display:none ">'
       + '<img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzgiIGhlaWdodD0iMzgiIHZpZXdCb3g9IjAgMCAzOCAzOCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4gICAgPGRlZnM+ICAgICAgICA8bGluZWFyR3JhZGllbnQgeDE9IjguMDQyJSIgeTE9IjAlIiB4Mj0iNjUuNjgyJSIgeTI9IjIzLjg2NSUiIGlkPSJhIj4gICAgICAgICAgICA8c3RvcCBzdG9wLWNvbG9yPSIjZmZmIiBzdG9wLW9wYWNpdHk9IjAiIG9mZnNldD0iMCUiLz4gICAgICAgICAgICA8c3RvcCBzdG9wLWNvbG9yPSIjZmZmIiBzdG9wLW9wYWNpdHk9Ii42MzEiIG9mZnNldD0iNjMuMTQ2JSIvPiAgICAgICAgICAgIDxzdG9wIHN0b3AtY29sb3I9IiNmZmYiIG9mZnNldD0iMTAwJSIvPiAgICAgICAgPC9saW5lYXJHcmFkaWVudD4gICAgPC9kZWZzPiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPiAgICAgICAgPGcgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMSAxKSI+ICAgICAgICAgICAgPHBhdGggZD0iTTM2IDE4YzAtOS45NC04LjA2LTE4LTE4LTE4IiBpZD0iT3ZhbC0yIiBzdHJva2U9InVybCgjYSkiIHN0cm9rZS13aWR0aD0iMiI+ICAgICAgICAgICAgICAgIDxhbmltYXRlVHJhbnNmb3JtICAgICAgICAgICAgICAgICAgICBhdHRyaWJ1dGVOYW1lPSJ0cmFuc2Zvcm0iICAgICAgICAgICAgICAgICAgICB0eXBlPSJyb3RhdGUiICAgICAgICAgICAgICAgICAgICBmcm9tPSIwIDE4IDE4IiAgICAgICAgICAgICAgICAgICAgdG89IjM2MCAxOCAxOCIgICAgICAgICAgICAgICAgICAgIGR1cj0iMC45cyIgICAgICAgICAgICAgICAgICAgIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiAvPiAgICAgICAgICAgIDwvcGF0aD4gICAgICAgICAgICA8Y2lyY2xlIGZpbGw9IiNmZmYiIGN4PSIzNiIgY3k9IjE4IiByPSIxIj4gICAgICAgICAgICAgICAgPGFuaW1hdGVUcmFuc2Zvcm0gICAgICAgICAgICAgICAgICAgIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgICAgICAgICAgICAgICAgICAgIHR5cGU9InJvdGF0ZSIgICAgICAgICAgICAgICAgICAgIGZyb209IjAgMTggMTgiICAgICAgICAgICAgICAgICAgICB0bz0iMzYwIDE4IDE4IiAgICAgICAgICAgICAgICAgICAgZHVyPSIwLjlzIiAgICAgICAgICAgICAgICAgICAgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIC8+ICAgICAgICAgICAgPC9jaXJjbGU+ICAgICAgICA8L2c+ICAgIDwvZz48L3N2Zz4=" />'
       + '<div class="loader-overlay-text" id="dvOverLayText">' + loadingText + '</div>'
       + '</div>';

    $('body').after(divOverlay);
    $("#divOverlay").show();
};

$util.hideOverlay = function () {
    if ($("#divOverlay") && $("#divOverlay").length) {
        $("#divOverlay").hide();
    }
};

$util.isFunction = function (functionToCheck) {
    var getType = {};
    return functionToCheck && getType.toString.call(functionToCheck) === '[object Function]';
};

$util.showAlert = function (title, text, callback) {
    $util.hideModal();
    var html =
       '<div id="divAlertModalMessage" class="modal fade">' +
        '<div class="modal-dialog">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">' + title + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                    text +
                '</div>' +
                '<div class="modal-footer">' +
                    '<div class="text-left"><button type="button" class="btn btn-ok btn-default btn-nor-primary">' + $util.getLocalString("Ok") + '</button></div>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>';

    $('body').after(html);

    $("#divAlertModalMessage button.btn").click(function (e) {
        $("#divAlertModalMessage").modal('hide');
        if ($util.isFunction(callback)) {
            callback();
        }
    });

    $("#divAlertModalMessage").on("hide", function () {
        $("#divAlertModalMessage").remove();
    });

    $("#divAlertModalMessage").modal('show');
};

$util.confirm = function (title, text, callback) {
    $util.hideModal();
    var html =
       '<div id="divConfirmMessage" class="modal fade">' +
        '<div class="modal-dialog">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">' + title + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                    text +
                '</div>' +
                '<div class="modal-footer">' +
                    '<div class="text-left"><button type="button" class="btn btn-ok btn-nor-primary">' + $util.getLocalString("Ok") + '</button><button type="button" class="btn btn-cancel btn-default btn-nor-primary">' + $util.getLocalString("Cancel") + '</button></div>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>';

    $('body').after(html);

    $("#divConfirmMessage").modal('show');

    $("#divConfirmMessage button.btn-ok").on("click", function (e) {
        $("#divConfirmMessage").modal('hide');
        if ($util.isFunction(callback)) {
            callback();
        }
    });

    $("#divConfirmMessage button.btn-cancel").on("click", function (e) {
        $("#divConfirmMessage").modal('hide');
    });

    $("#divConfirmMessage").on("hide", function () {
        $("#divConfirmMessage").remove();
    });

};

$util.showModal = function (title, text, okButtonText, cancelButtonText, autoHideAfterOk, callback) {
    $util.hideModal();
    var cancelButtonHtml = cancelButtonText && $.trim(cancelButtonText) !== '' ?
        '<button type="button" class="btn btn-default btn-nor-primary btn-primary btn-cancel">' + cancelButtonText : '';
    var html =
       '<div id="divModalContainer" class="modal fade">' +
        '<div class="modal-dialog">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">' + title + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                    text +
                '</div>' +
                '<div class="modal-footer">' +
                    '<div class="text-left"><button type="button" class="btn-ok btn btn-nor-primary">' + okButtonText + '</button>' + cancelButtonHtml + '</div>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>';

    $('body').after(html);

    $("#divModalContainer").modal('show');

    $util.applyMaxLengthAttributes();
    $util.textAreasCharCountDown();
    //$.validator.unobtrusive.parseElement($('#DeactivateReason').get(0));

    //Remove current form validation information
    //$("#frmDeActivateUserContent")
    //    .removeData("validator")
    //    .removeData("unobtrusiveValidation");

    //Parse the form again
    //$.validator
    //    .unobtrusive
    //    .parse("#frmDeActivateUserContent");



    $("#divModalContainer button.btn-ok").on("click", function (e) {
        if (autoHideAfterOk === true) {
            $("#divModalContainer").modal('hide');
        }

        if ($util.isFunction(callback)) {
            callback();
        }
    });

    $("#divModalContainer button.btn-cancel").on("click", function (e) {
        $("#divModalContainer").modal('hide');
    });

    $("#divModalContainer").on("hide", function () {
        $("#divModalContainer").remove();
    });

};

$util.hideModal = function () {
    $("#divModalContainer").modal('hide');
    $(".modal-backdrop").remove();
    $("#divModalContainer").on("hide", function () {
        $("#divModalContainer").remove();
    });
};

$util.showModalWithPartial = function (title, url) {
    $util.hideModal();
    var html =
       '<div id="divModalContainer" class="modal fade">' +
        '<div class="modal-dialog">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">' + title + '</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>';

    $('body').after(html);

    $(".modal-body").load(url, function () {
        $("#divModalContainer").modal('show');
        $util.refreshFormValidation();
        $util.initRequiredFieldsMark();
    });

    $(document).on('submit', '#divModalContainer form', function (e) {
        $.ajaxSetup({ cache: false });
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#divModalContainer').modal('hide');
                    $util.showAlert(title,
                        result.successMessage,
                        function () {
                            $util.showOverlay();
                            location.reload();
                        });
                } else {
                    $('.modal-body').html(result);
                    e.preventDefault();
                }
            }
        });
        return false;
    });

    $(document).on('click', '.btnCancel', function (e) {
        $("#divModalContainer").modal('hide');
    });

    $("#divModalContainer a.btn-cancel").on("click", function (e) {
        $("#divModalContainer").modal('hide');
    });

    $("#divModalContainer").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
        $("#divModalContainer").remove();
    });

};

$util.refreshFormValidation = function () {
    var form = $('form')
        .removeData("validator") /* added by the raw jquery.validate plugin */
        .removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin*/
    $.validator.unobtrusive.parse(form);
};

$util.confirmDialogueWithAjaxPost = function (title,
                                                confirmMsg,
                                                deleteSuccessMsg,
                                                deleteErrorMsg,
                                                url,
                                                dataObject) {
    $util.confirm(title, confirmMsg, function () {
        $util.showOverlay(title);
        $.post(url, dataObject, function (data) {
            $util.hideOverlay();
            if (data) {
                if (data.success) {
                    $util.showAlert(title, deleteSuccessMsg, function () {
                        $util.showOverlay();
                        location.reload();
                    });
                } else {
                    switch (data.errorMessage) {
                        default:
                            $util.showAlert(title, data.errorMessage?data.errorMessage:deleteErrorMsg);
                            break;
                    }
                }
            }
        });
    });
}

$util.printPdf = function (pdfFileUrl) {

    if ($("#frmPrint").length) {
        $("#frmPrint").remove();
    }

    if (!pdfFileUrl) {
        return false;
    }

    var html =
        '<iframe id="frmPrint" width="0" height="0" frameborder="0" name="frmPrint" src="' + pdfFileUrl + '"></iframe>';

    $('body').after(html);

    var iframe = document.frames
        ? window.frames.frames['frmPrint']
        : document.getElementById('frmPrint');

    var ifWin = iframe.contentWindow || iframe;

    try {
        ifWin.focus();
        ifWin.print();
    } catch (e) {
        window.print(false);
        //or when you get Invalid calling object error for IE9 and above
        //set the browser into IE8 compatibility mode will work
    }

    return false;
};

$util.initSubmitButtonOverlay = function () {
    $(':submit').click(function (evt) {

        if ($(this).hasClass("disable-overlay")) {
            return;
        }

        var form = $(this).parents('form:first');

        if (form && form.length) {
            $util.showOverlay(' ');
        } else {
            $util.hideOverlay();
        }
    });

    $('a.enable-overlay').click(function (evt) {
        $util.showOverlay(' ');
    });

};

$util.initRequiredFieldsMark = function () {
    $('[data-val-required]')
        .each(function () {
            $('label[for="' + $(this).attr('name').replace(".", "_") + '"]:not(:has(>span))')
                .append('<span class="text-danger">*</span>');
        });

    $('[data-val-requiredif]')
        .each(function () {
            $('label[for="' + $(this).attr('name').replace(".", "_") + '"]:not(:has(>span))')
                .append('<span class="text-danger">*</span>');
        });
};

$util.getUserTasksCount = function () {
    var userTasksCountSpan = $('.UserTasksCount');
    if (userTasksCountSpan && userTasksCountSpan.length > 0) {
        $.get('/Request/IncomeRequest/GetUserTasksCount',
                             function (data) {
                                 if (data) {
                                     if (data > 0)
                                         $('.UserTasksCount').html(data).addClass('HighlightCount');
                                     else
                                         $('.UserTasksCount').html('').removeClass('HighlightCount');
                                 }


                                 // end if
                             });  //ajax end
    }
}

$util.disableInputs = function () {
    $('input[data-val-required],input[data-val-requiredif],select[data-val-required],select[data-val-requiredif]').removeAttr('data-val-required');
    $('.text-danger').hide();
    $(".container :input,textarea,select").not(".btn-default").not('.btn-primary').attr("disabled", "disabled");
}

// ---------------------------------- Validation Attributes for custom validations ------------------------------------------- //

//enable validaitions on hidden fields too!
//$.validator.setDefaults({ ignore: null });

//must be true attribute client validation
if (jQuery.validator && jQuery.validator.unobtrusive) {
    //must be true attribute
    jQuery.validator.unobtrusive.adapters.addBool("mustbetrue");

    jQuery.validator.addMethod('mustbetrue', function (value, element, params) {
        return element.checked;
    }, '');
}


$(function () {
    $util.applyMaxLengthAttributes();
    $util.textAreasCharCountDown();
    $util.applyAutoPostBackAttribute();
    $util.initLangSwitcher();
    $util.initRequiredFieldsMark();
    $util.initSubmitButtonOverlay();
    $util.getUserTasksCount();

});