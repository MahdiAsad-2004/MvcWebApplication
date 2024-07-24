let ProductItemCount = 0;
let ProductItemCountInput;
let EditProductitemForm = document.getElementById('edit-productitem-form')
let EditProductitemIdInput = document.getElementById('edit-productitem-id-input');
let EditProductitemCountInput = document.getElementById('edit-productitem-count-input')
async function IncreaseProductItemCount(productItemId) {
    ProductItemCountInput = document.getElementById(`productItem-${productItemId}-count`);
    ProductItemCount = +ProductItemCountInput.value + 1;
    if (ProductItemCount && ProductItemCount <= ProductItemCountInput.max) {
        EditProductitemIdInput.value = +productItemId;
        EditProductitemCountInput.value = ProductItemCount;
        if (await FetchRequestForm(EditProductitemForm)) {
            await LoadCartSummary();
        }
    }
}
async function DecreaseProductItemCount(productItemId) {
    ProductItemCountInput = document.getElementById(`productItem-${productItemId}-count`);
    ProductItemCount = +ProductItemCountInput.value - 1;
    if (ProductItemCount >= 1) {
        EditProductitemIdInput.value = +productItemId;
        EditProductitemCountInput.value = ProductItemCount;
        if (await FetchRequestForm(EditProductitemForm)) {
            await LoadCartSummary();
        }
    }
    //if (ProductItemCount <= 0) {
    //    if (await RemoveProductItem(productItemId)) {
    //        await LoadCartSummary();
    //    }
    //}
}



// remove productItem in cart

let RemoveProductItemForm = document.getElementById('remove-productitem-form');
let RemoveProductItemFormIdInput = document.getElementById('remove-productitem-form-id-input');
async function RemoveProductItem(productItemId) {
    productItemId = +productItemId;
    if (productItemId > 0) {
        RemoveProductItemFormIdInput.value = productItemId;
        if (await FetchRequestForm(RemoveProductItemForm)) {
            await LoadCartSummary();
        }
        
    }
}

