var pContainerHeight = $('.bird-box').height();

$(window).scroll(function(){

  var wScroll = $(this).scrollTop();

  if (wScroll <= pContainerHeight) {

    $('.logo').css({
      'transform' : 'translate(0px, '+ wScroll /0.7 +'%)'
    });
  }
});


$(document).ready(function () {

    /**
     * This object controls the nav bar. Implement the add and remove
     * action over the elements of the nav bar that we want to change.
     *
     * @type {{flagAdd: boolean, elements: string[], add: Function, remove: Function}}
    
    /**/
    $(function () {

        "use strict";

        var $bgobj = $(".ha-bg-parallax"); // assigning the object

        $(window).on("scroll", function () {

            var yPos = -($(window).scrollTop() / $bgobj.data('speed'));

            // Put together our final background position

            var coords = '100% ' + yPos + 'px';

            // Move the background

            $bgobj.css({ backgroundPosition: coords });

        });
        $('div.product-chooser').not('.disabled').find('div.product-chooser-item').on('click', function () {
            $(this).parent().parent().find('div.product-chooser-item').removeClass('selected');
            $(this).addClass('selected');
            $(this).find('input[type="radio"]').prop("checked", true);

        });

    });
});