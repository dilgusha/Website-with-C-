$(document).ready(function () {
	var a = ' ';
	$('button').click(function () {
		alert();
		//$('.menuone').hide()
		//a = $(this).attr("data-filter")
		//console.log(a)
	/*	$('.' + $(this).text()).show()*/
	})

})

//$(".filter").on("click", "button.button", function (b) {
//    b.preventDefault();
//    var c = $(this).attr("data-filter");
//    $grid.isotope({
//        filter: c
//    });
//    $(".filter button").removeClass("button-active");
//    $(this).addClass("button-active");
//});
//        }

$('#iconnav i').click(function () {
	$('#navigation').toggleClass('show');
})




//$('.navbar-toggler').click(function () {
//	$('#navbarResponsive').toggleClass('show');
//})

//$(window).scroll(function () {
//	var scroll = $(window).scrollTop();
//	var box = $('.header-text').height();
//	var header = $('header').height();

//	if ($(window).scrollTop() + $(window).height() > $(document).height() - 4000) {
//		$("header").addClass("background-header");
//	} else {
//		$("header").removeClass("background-header");
//	}
//});