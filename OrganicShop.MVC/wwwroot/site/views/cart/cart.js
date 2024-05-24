let ProductItemCount = 0;
let ProductItemCountInput;
let EditProductitemForm = document.getElementById('edit-productitem-form')
let EditProductitemIdInput = document.getElementById('edit-productitem-count-input');
let EditProductitemCountInput = document.getElementById('edit-productitem-id-input')
async function IncreaseProductItemCount(productItemId) {
    ProductItemCountInput = document.getElementById(`productItem-${productItemId}-count`);
    ProductItemCount = Number(ProductItemCountInput.value) + 1;
    if (productCartCount && productCartCount <= ProductItemCountInput.max) {
        EditProductitemIdInput.value = productItemId;
        EditProductitemCountInput.value = ProductItemCount;
        await FetchRequestForm(EditProductitemForm);
    }
}
async function DecreaseProductItemCount(productItemId) {
    ProductItemCountInput = document.getElementById(`productItem-${productItemId}-count`);
    ProductItemCount = Number(ProductItemCountInput.value) - 1;
    if (Number(productCartCount)) {
        if (productCartCount >= 1) {
            EditProductitemIdInput.value = productItemId;
            EditProductitemCountInput.value = ProductItemCount;
            var result = await FetchRequestForm(EditProductitemForm);
            if (result) {
                ProductItemCountInput.value = ProductItemCount;
            }
        }
        else {
            await RemoveProductItem(productItemId);
        }   
    }
}



// remove productItem in cart

let RemoveProductItemForm = document.getElementById('remove-productitem-form');
let RemoveProductItemFormIdInput = document.getElementById('remove-productitem-form-id-input');
async function RemoveProductItem(productItemId) {
    if (Number(productItemId) && productItemId > 0) {
        RemoveProductItemFormIdInput.value = productItemId;
        await FetchRequestForm(RemoveProductItemForm);
    }
}

