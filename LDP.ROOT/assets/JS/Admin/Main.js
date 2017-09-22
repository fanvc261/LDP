$(document).ready(function () {
    $(document).on("click", '.sidebar .nav > li > a[data-toggle="collapse"]', function () {
        var ariaexpanded = $(this).attr('aria-expanded');
        if (ariaexpanded=='true')
        {
            $(this).attr('aria-expanded', false);
            $(this).next().removeClass('in');
            //var li_distance = $(this).parent().position().top - 10;
            //$(this).next().css({
            //    'transform':'translate3d(0px,' + li_distance + 'px, 0)'
            //});
        }
        else
        {
            $(this).attr('aria-expanded', true);
            $(this).next().addClass('in');
            //var li_distance = $(this).parent().position().top - 10;
            //$(this).next().css({
            //    'transform': 'translate3d(0px,' + li_distance + 'px, 0)'
            //});
        }
    });
});

function activeMenu(key) {
    $('.sidebar .active').removeClass('active');
    var activetab = $('.sidebar .nav  li  a[data-key="' + key + '"]');
    activetab.parent().addClass('active');
    if (activetab.parents('.collapse').length >0)
    {
        activetab.parents('.collapse').attr('aria-expanded', true);
        activetab.parents('.collapse').addClass('in');
        activetab.parents('.collapse').parent().addClass('active');
    }
}