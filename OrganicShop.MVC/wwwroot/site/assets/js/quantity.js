/**=====================
    Quantity js
==========================**/
$('.qty-right-plus').click(function () {
    var maxQuantity = +$(this).prev().attr('max');
    //console.log(maxQuantity);
    //console.log(+$(this).prev().val() + 1);
    if (maxQuantity >= 0) {
        if (+$(this).prev().val() + 1 <= maxQuantity) {
            $(this).prev().val(+$(this).prev().val() + 1);
            //console.log('plus 1')
        }
    }
    else {
        $(this).prev().val(+$(this).prev().val() + 1);
    }
});
$('.qty-left-minus').click(function () {
    if (+$(this).next().val() - 1 >= 0) {
        $(this).next().val(+$(this).next().val() - 1);
    }
});