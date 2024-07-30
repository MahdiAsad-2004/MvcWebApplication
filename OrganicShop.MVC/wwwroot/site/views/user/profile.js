

EditProductWishListForm = document.getElementById('edit-product-wishlist-form');

function RemoveProductFromWishList(productId) {
    productId = +productId;
    if (productId > 0) {
        EditProductWishListForm.querySelector("input[name = 'productId']").value = productId;
        EditProductWishListForm.querySelector("input[name = 'isDelete']").value = true;
        var result = await FetchRequestForm(EditProductWishListForm);
        if (result == true) {
            document.getElementById(`product-wish-${productId}`).remove();
        }
    }
}

//const add-address - modal - close - Button

async function AddAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        document.getElementById('add-address-modal-close-button').click();
        await LoadAddressTab();
    }
}


async function LoadAddressTab() {
    await FetchRequestFormWithId('load-address-tab-form');
}


function OpenEditAddressModal(id, title ,name, phoneNumber, postCode, province, text) {

    document.getElementById('edit-address-id-input').value = id;
    document.getElementById('edit-address-title-input').value = title;
    document.getElementById('edit-address-name-input').value = name;
    document.getElementById('edit-address-phoneNumber-input').value = phoneNumber;
    document.getElementById('edit-address-postCode-input').value = postCode;

    $("#edit-address-province-select").val(province).change();
    //document.getElementById('edit-address-province-select').value = province;

    document.getElementById('edit-address-postCode-textArea').innerHTML = text;

    const editAddressModal = new bootstrap.Modal('#edit-address-modal');
    editAddressModal.show();
}

async function EditAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        const editAddressModal = new bootstrap.Modal('#edit-address-modal');
        editAddressModal.hide();
        await LoadAddressTab();
    }
}


function OpenRemoveAddressModal(id ,title)
{
    document.getElementById('remove-address-id-input').value = id;

    document.getElementById('remove-address-modal-addressTitle').innerHTML = title;

    const removeAddressModal = new bootstrap.Modal('#remove-address-modal');
    removeAddressModal.show();
}


function DeleteAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        const removeAddressModal = new bootstrap.Modal('#remove-address-modal');
        removeAddressModal.hide();
        await LoadAddressTab();
    }
}


