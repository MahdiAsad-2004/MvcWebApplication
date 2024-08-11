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




async function AddProductItemToNextCart(productItemId) {
    productItemId = +productItemId;
    if (productItemId) {
        const form = document.getElementById('add-productItem-to-next-cart-form');
        form.querySelector(`input[name='productItemId']`).value = productItemId;
        await FetchRequestForm(form);
    }
}



const ApplyCouponButtonId = 'apply-coupon-button';
const RemoveCouponButtonId = 'remove-coupon-button';
async function ApplyCouponSubmit() {
    if (await FetchRequestFormWithId('apply-coupon-form')) {
        document.getElementById(ApplyCouponButtonId).hidden = true;
        document.getElementById(RemoveCouponButtonId).hidden = false;
        SetApplyCouponInputDisable(true);
    }
}


async function RemoveCoupon() {
    if (await LoadBill()) {
        document.getElementById(RemoveCouponButtonId).hidden = true;
        document.getElementById(ApplyCouponButtonId).hidden = false;
        SetApplyCouponInputDisable(false);
    }
}


async function LoadBill() {
    return new Promise(async (resolve, reject) => {
        var result = await FetchRequestFormWithId('load-bill-form');
        resolve(result);
    });
}


function SetApplyCouponInputDisable(flag) {
    document.getElementById('apply-coupon-form').querySelector(`input[name=Code]`).disabled = Boolean(flag);
}