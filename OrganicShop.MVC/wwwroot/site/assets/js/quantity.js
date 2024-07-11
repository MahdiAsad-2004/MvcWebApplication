/**=====================
    Quantity js
==========================**/
$('.qty-right-plus').click(function () {
    var maxQuantity = +$(this).next().attr('max') + 1;
    if (maxQuantity) {
        if ($(this).next().val() + 1 <= maxQuantity) {
            $(this).prev().val(+$(this).prev().val() + 1);
        }
    }
    else {
            $(this).prev().val(+$(this).prev().val() + 1);
    }
});
$('.qty-left-minus').click(function () {
    if ($(this).next().val() > 1) {
        if ($(this).next().val() > 1)
            $(this).next().val(+$(this).next().val() - 1);
    }
});