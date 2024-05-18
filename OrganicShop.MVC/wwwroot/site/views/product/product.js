
let ProductVarientRadios = Array.from(document.getElementsByClassName('product-varient-radio'));

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




const ProductItemVarientIdInput = document.getElementById('createProductItem.ProductVarientId');
const ProductItemCountInput = document.getElementsByName('createproductItem.Count')[0];
const ProductCartCountPlus = document.getElementById('product-cart-count-plus');
const ProductCartCountMinus = document.getElementById('product-cart-count-minus');

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


const AddToCartForm = document.getElementById('add-to-cart-form');
const AddToCartButton = document.getElementById('add-to-cart-button');


AddToCartButton.addEventListener('click', (e) => {
    if (ProductItemCountInput.value > 0 && ProductItemCountInput.value < ProductItemCountInput.max) {
        SubmitFormWithButton(AddToCartForm);
    }
    else {
        Toast('خطا !' , 'تعداد محصول انتخاب شده معتبر نیست' , 1 , 2000);
    }
})






