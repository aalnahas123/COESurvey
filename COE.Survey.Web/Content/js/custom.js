$(window).scroll(function () {
    // fixed menu
    if ($(this).scrollTop() > 0) {
        $('.topbar').addClass('fixed');
    } else {
        $('.topbar').removeClass('fixed');
    }
});

$(document).ready(function () {
    // menu
    $('#menu').slicknav({
        label: '',
        duplicate: true
    });
    // tooltip
    $(".tooltip span").click(function () {
        $(this).parent().toggleClass('sropen srclose');
    });

    // smooth scroll
    $('a[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });

    // hide menu on click outside
    $(document).mouseup(function (e) {
        var container = $(".tooltip");

        if ($('.tooltip .m_close img').is(e.target)) {
            container.removeClass('sropen').addClass('srclose');
            return;
        }

        if (!container.is(e.target) && container.has(e.target).length === 0
			&& container.hasClass('sropen')) { // if the target of the click isn't the container...        					
            container.removeClass('sropen').addClass('srclose');
        }


    });

 


    $(function () {

        var pagePositon = 0,
            sectionsSeclector = 'section',
            $scrollItems = $(sectionsSeclector),
            offsetTolorence = 30,
            pageMaxPosition = $scrollItems.length - 1;

        //Map the sections:
        $scrollItems.each(function (index, ele) { $(ele).attr("debog", index).data("pos", index); });

        // Bind to scroll
        $(window).bind('scroll', upPos);

        //Move on click:
        $('#arrow a').click(function (e) {
            if ($(this).hasClass('next') && pagePositon + 1 <= pageMaxPosition) {
                pagePositon++;
                $('html, body').stop().animate({
                    scrollTop: $scrollItems.eq(pagePositon).offset().top
                }, 300);
            }
            if ($(this).hasClass('previous') && pagePositon - 1 >= 0) {
                pagePositon--;
                $('html, body').stop().animate({
                    scrollTop: $scrollItems.eq(pagePositon).offset().top
                }, 300);
                return false;
            }
        });

        //Update position func:
        function upPos() {
            var fromTop = $(this).scrollTop();
            var $cur = null;
            $scrollItems.each(function (index, ele) {
                if ($(ele).offset().top < fromTop + offsetTolorence) $cur = $(ele);
            });
            if ($cur != null && pagePositon != $cur.data('pos')) {
                pagePositon = $cur.data('pos');
            }
        }

    });
    $('#arrows a.previous').click(function () {
        $.scrollTo($(this).closest('section').prev(), 800);
    });

    $('#arrows a.next').click(function () {
        $.scrollTo($(this).closest('section').next(), 800);
    });

    //UPLOAD TERMS
    $('.upload-terms-icn').hover(function () {
        $('.upload-terms').fadeToggle(100);
    });

});
