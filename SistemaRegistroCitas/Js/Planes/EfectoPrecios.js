$(document).ready(function(){
    
	var contacto = $('#contacto').offset().top,
		arriba = $('#arriba').offset().top;

$('#btn-contacto').on('click', function(e){
		
		e.preventDefault();
		$('html, body').animate({
			scrollTop: contacto
		}, 500);
});


	$('#btn-precio').on('click', function (e) {

		e.preventDefault();
		$('html, body').animate({
			scrollTop: arriba
		}, 500);
	});

	$(window).scroll(function () {
		if ($(this).scrollTop() > 0) {
			$('.ir-arriba').slideDown(300);
		} else {
			$('.ir-arriba').slideUp(300);
        }

	});
    
});