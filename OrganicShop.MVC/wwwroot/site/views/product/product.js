
let ProductVarientRadios = Array.from(document.getElementsByClassName('product-varient-radio'));
const AddProductToCartForm = document.getElementById('add-product-to-cart-form');
const AddProductToCartButton = document.getElementById('add-to-cart-button');
const ProductItemVarientIdInput = AddProductToCartForm.querySelector("[name = 'createProductItem.ProductVarientId'");
const ProductItemCountInput = AddProductToCartForm.querySelector("[name = 'createproductItem.Count']");
const ProductCartCountMinus = AddProductToCartForm.querySelector('#product-cart-count-minus');
const ProductCartCountPlus = AddProductToCartForm.querySelector('#product-cart-count-plus');


let productVarientStock = 0;
let productVarientId = 0;

ProductVarientRadios.forEach(varientRadio => {
    varientRadio.addEventListener('change', a => {
        productVarientStock = Number(a.getAttribute('data-product-varient-stock').value);
        productVarientId = Number(a.getAttribute('data-product-varient-id').value);
        if (productVarientStock) {
            ProductItemCountInput.max = productVarientStock;
            if (ProductItemCountInput.value > ProductItemCountInput.max) {
                ProductItemCountInput.value = ProductItemCountInput.max;
            }
        }
        ProductItemVarientIdInput.value = productVarientId;
    })
})

var productCartCount = 0;

ProductCartCountMinus.addEventListener('click', () => {
    productCartCount = Number(ProductItemCountInput.value) - 1;
    if (productCartCount >= 0) {
        ProductItemCountInput.value = productCartCount;
    }
});

ProductCartCountPlus.addEventListener('click', () => {
    productCartCount = Number(ProductItemCountInput.value) + 1;
    if (productCartCount <= ProductItemCountInput.max) {
        ProductItemCountInput.value = productCartCount;
    }
});

AddProductToCartButton.addEventListener('click', (e) => {
    if (ProductItemCountInput.value > 0 && ProductItemCountInput.value < ProductItemCountInput.max) {
        SubmitFormWithButton(AddProductToCartForm);
    }
    else {
        Toast('خطا !', 'تعداد محصول انتخاب شده معتبر نیست', 1, 2000);
    }
})

//--------------------------------------------------------------------------------------------------------------



let ProductVarientSelect = document.getElementById('product-varient-select');
const StickAddProductToCartForm = document.getElementById('add-product-to-cart-form');
const StickAddProductToCartButton = document.getElementById('add-to-cart-button');
var option;
const StickProductItemVarientIdInput = StickAddProductToCartForm.querySelector("[name = 'createProductItem.ProductVarientId'");
const StickProductItemCountInput = StickAddProductToCartForm.querySelector("[name = 'createproductItem.Count']");
const StickProductCartCountMinus = AddProductToCartForm.querySelector('#stick-product-cart-count-minus');
const StickProductCartCountPlus = AddProductToCartForm.querySelector('#stick-product-cart-count-plus');

ProductVarientSelect.addEventListener('change', a => {

    option = ProductVarientSelect.options[ProductVarientSelect.selectedIndex];

    productVarientStock = Number(option.getAttribute('data-product-varient-stock').value);
    productVarientId = Number(option.value);
    if (productVarientStock) {
        ProductItemCountInput.max = productVarientStock;
        if (ProductItemCountInput.value > ProductItemCountInput.max) {
            ProductItemCountInput.value = ProductItemCountInput.max;
        }
    }
    ProductItemVarientIdInput.value = productVarientId;
})

StickProductCartCountMinus.addEventListener('click', () => {
    productCartCount = Number(StickProductItemCountInput.value) - 1;
    if (productCartCount >= 0) {
        StickProductItemCountInput.value = productCartCount;
    }
});

StickProductCartCountPlus.addEventListener('click', () => {
    productCartCount = Number(StickProductItemCountInput.value) + 1;
    if (productCartCount <= StickProductItemCountInput.max) {
        ProductItemCountInput.value = productCartCount;
    }
});


StickAddProductToCartButton.addEventListener('click', (e) => {
    if (ProductItemCountInput.value > 0 && StickProductItemCountInput.value < StickProductItemCountInput.max) {
        SubmitFormWithButton(StickAddProductToCartForm);
    }
    else {
        Toast('خطا !', 'تعداد محصول انتخاب شده معتبر نیست', 1, 2000);
    }
})



let ProductCommentForm = document.getElementById('product-comment-form');
let ProductCommentButton = document.getElementById('product-comment-button');
ProductCommentButton.onclick = (e) => {
    SubmitFormWithButton(ProductCommentForm);
}













