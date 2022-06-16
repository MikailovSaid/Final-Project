function openBarsNav() {
    document.getElementById("barsSidenav").style.width = "350px";
}

function closeBarsNav() {
    document.getElementById("barsSidenav").style.width = "0";
}

function openSearchNav() {
    document.getElementById("searchSidenav").style.width = "350px";
}

function closeSearchNav() {
    document.getElementById("searchSidenav").style.width = "0";
}

$(document).ready(function () {

    $("#owl-demo").owlCarousel({

        autoPlay: 3000, //Set AutoPlay to 3 seconds

        items: 4,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3]

    });

});

$(document).ready(function () {
    $("#product-size").find('.size').click(function () {
        if (!$(this).hasClass("active")) {
            $(this).addClass("active");
            $("#add-to-cart-btn").removeAttr("disabled")
            $("#add-to-cart-btn").addClass("active-btn")
        }
        else {
            $(this).removeClass("active");
            $("#add-to-cart-btn").prop('disabled', true);
            $("#add-to-cart-btn").removeClass("active-btn");
        }
    });

    var count = 0;
    $("#up-count").click(function () {
        if (count + 1 < 6) {
            count = parseInt($(this).parent().find('#count').val());
            count = count + 1;
            $(this).parent().find('#count').val(count);
        }
    })
    $("#down-count").click(function () {
        if (count - 1 > 0) {
            count = parseInt($(this).parent().find('#count').val());
            count = count - 1;
            $(this).parent().find('#count').val(count);
        }
    })

    window.onscroll = function() {scrollFunction()};
    function scrollFunction() {
        if (document.body.scrollTop > 690 || document.documentElement.scrollTop > 690){
            $('#go-top').addClass('show-scroll');
        }else {
            $('#go-top').removeClass('show-scroll');
        }
    }

    $('#go-top').click(function(){
        $("html, body").animate({scrollTop: 0}, 1000);
    })


    var openBtn = $('#product_filter').find('.product-filter').find('.head').find('.open-btn');

    openBtn.click(function(){
        if ($(this).parent().parent().find('.filter-control').hasClass("active")) {
            $(this).parent().parent().find('.filter-control').removeClass("active")
            $(this).parent().parent().find('.filter-control').slideUp();
            $(this).html("<i class='fas fa-angle-right'></i>");
        }else{
            $(this).parent().parent().find('.filter-control').addClass("active");
            $(this).parent().parent().find('.filter-control').slideDown();
            $(this).html("<i class='fas fa-angle-down'></i>");
        }
    })


    $('.show-password').on('mousedown',function(){
        $(this).prev().attr('type','text');
        
    }).on('mouseup mouseleave', function(){
        $(this).prev().attr('type','password');
    });


    
});