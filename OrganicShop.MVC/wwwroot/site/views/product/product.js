
let ProductVarientRadios = Array.from(document.getElementsByClassName('product-varient-radio'));

let ProductPriceContainer = document.getElementById('product-price-container');
let ProductDiscountDiv = document.getElementById('product-discount-div');
let ProductHasDiscount = false;
let DiscountIsFix = false;
let DiscountFixValue = 0;
let DiscountPercent = 0;
if (ProductDiscountDiv) {
    ProductHasDiscount = true;
    DiscountIsFix = ProductDiscountDiv.querySelector('#product-discount-isFix').value.toLowerCase() == 'ture';
    DiscountFixValue = Number(ProductDiscountDiv.querySelector('#product-discount-fixVaue').value);
    DiscountPercent = Number(ProductDiscountDiv.querySelector('#product-discount-percent').value);
}

let MainPrice = Number(document.getElementById('product-main-price').value);
let DiscountedPrice = 0;
let PreviousPrice = 0;
let DiscountedPriceStr = '';


let productVarientPrice = 0;
let productVarientStock = 0;

ProductVarientRadios.forEach(varientRadio => {
    varientRadio.addEventListener('change', a => {
        productVarientPrice = Number(a.getAttribute(' data-product-varient-price').value);
        productVarientStock = Number(a.getAttribute(' data-product-varient-stock').value);
        if (productVarientPrice) {
            ChangeProductPriceByVarient(productVarientPrice);
        }
        if (productVarientStock) {

        }
    })
})


function ChangeProductPriceByVarient(price) {
        var priceStr = price.formatMoney(',');
    if (ProductHasDiscount) {
        if (DiscountIsFix) {
            DiscountedPriceStr = Math.floor(price - DiscountFixValue).formatMoney(',');
        }
        else {
            DiscountedPriceStr = Math.floor(price - (price * DiscountPercent)).formatMoney(',');
        }

        ProductPriceContainer.innerHTML =
            `تومان ${DiscountedPriceStr}
            <del class="text-content">${priceStr}</del>
            <span class="offer theme-color">
                (${DiscountIsFix ? DiscountFixValue.formatMoney(',') : `${DiscountPercent}%`} تخفیف)
            </span>`;
    }
    else {

        ProductPriceContainer.innerHTML = `تومان ${priceStr}`;
    }
}


function CalcDiscountedPrice() {

}