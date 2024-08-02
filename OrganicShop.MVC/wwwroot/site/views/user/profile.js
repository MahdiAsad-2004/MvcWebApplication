

//EditProductWishListForm = document.getElementById('edit-product-wishlist-form');

async function RemoveProductFromWishList(productId) {
    productId = +productId;
    if (productId > 0) {
        EditProductWishListForm.querySelector("input[name = 'productId']").value = productId;
        EditProductWishListForm.querySelector("input[name = 'isDelete']").value = 'true';

        console.log(EditProductWishListForm);

        var result = await FetchRequestForm(EditProductWishListForm);
        if (result == true) {
            document.getElementById(`product-wish-${productId}`).remove();
        }
    }
}

//const add-address - modal - close - Button



async function LoadAddressTab() {
    await FetchRequestFormWithId('load-address-tab-form');
}
async function AddAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        document.getElementById('add-address-modal-close-button').click();
        await LoadAddressTab();
    }
}
async function EditAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        document.getElementById('edit-address-modal-close-button').click();
        await LoadAddressTab();
    }
}
async function DeleteAddressSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const removeAddressModal = new bootstrap.Modal('#delete-address-modal');
        //removeAddressModal.hide();
        document.getElementById('delete-address-modal-close-button').click();
        await LoadAddressTab();
    }
}
async function OpenEditAddressModal(id) {
    id = +id;
    if (id > 0) {
        const form = document.getElementById('load-address-edit-modal-form');
        form.setAttribute('action', `/profile/address/${id}`);
        if (await FetchRequestForm(form)) {
            const editAddressModal = new bootstrap.Modal('#edit-address-modal');
            editAddressModal.show();
        }
    }
}
function OpenDeleteAddressModal(id, title) {
    id = +id;
    if (id > 0) {
        document.getElementById('delete-address-id-input').value = id;
        document.getElementById('delete-address-modal-addressTitle').innerHTML = title;
        const removeAddressModal = new bootstrap.Modal('#delete-address-modal');
        removeAddressModal.show();
    }
}




for (var input of document.querySelectorAll(".bankCard-number-input")) {

    input.oninput = (event) => {
        console.log(event.target);
        console.log(this);
    }

}




async function LoadBankCardTab() {
    await FetchRequestFormWithId('load-bankCard-tab-form');
}
async function AddBankCardSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const removeAddressModal = new bootstrap.Modal('#add-bankCard-modal');
        //removeAddressModal.hide();
        document.getElementById('add-bankCard-modal-close-button').click();
        await LoadBankCardTab();
    }
}
async function EditBankCardSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const removeAddressModal = new bootstrap.Modal('#edit-bankCard-modal');
        //removeAddressModal.hide();
        document.getElementById('edit-bankCard-modal-close-button').click();
        await LoadBankCardTab();
    }
}
async function DeleteBankCardSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const removeBankCardModal = new bootstrap.Modal('#delete-bankCard-modal');
        //removeBankCardModal.hide();
        document.getElementById('delete-bankCard-modal-close-button').click();
        await LoadAddressTab();
    }
}
async function OpenDeleteBankCardModal(id) {
    id = +id;
    if (id > 0) {
        document.getElementById('delete-bankCard-id-input').value = id;
        const removeBankCardModal = new bootstrap.Modal('#delete-bankCard-modal');
        removeBankCardModal.show();
    }
}
async function OpenEditBankCardModal(id) {
    id = +id;
    if (id > 0) {
        const form = document.getElementById('load-bankCard-edit-modal-form');
        form.setAttribute('action', `/profile/bankCard/${id}`);
        if (await FetchRequestForm(form)) {
            const editBankCardModal = new bootstrap.Modal('#edit-bankCard-modal');
            editBankCardModal.show();
        }
    }
}



async function LoadUserInfo() {
    await FetchRequestFormWithId('load-user-info-tab-form');
}
async function EditUserInfoSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const editUserInoModal = new bootstrap.Modal('#edit-user-info-modal');
        //editUserInoModal.hide();
        document.getElementById('edit-user-info-modal-close-button').click();
        await LoadUserInfo();
        UserInfoUpdated();
    }
}






async function ChangeUserPasswordSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const changeUserPasswordModal = new bootstrap.Modal('#change-user-password-modal');
        //changeUserPasswordModal.hide();
        document.getElementById('change-user-password-modal-close-button').click();
    }
}
async function DeleteAccountSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const deleteAccountodal = new bootstrap.Modal('#delete-account-modal');
        //deleteAccountodal.hide();
        document.getElementById('delete-account-modal-close-button').click();
    }
}




function UserInfoUpdated() {
    const userName = document.getElementById('profile-user-updated-name').innerText;
    const userEmail = document.getElementById('profile-user-updated-email').innerText;    

    console.log(`profile-user-updated-name: ${userName}`);
    console.log(`profile-user-updated-email: ${userEmail}`);

    for (var userNameElem of document.querySelectorAll('.profile-user-name')) {
        userNameElem.innerText = userName;
    }
    for (var userEmailElem of document.querySelectorAll('.profile-user-email')) {
        userEmailElem.innerText = userEmail;
    }
}






async function SubscribeUserNewsLetterSubmit(formId) {
    var result = await FetchRequestForm(document.getElementById(formId));
    if (result) {
        //const subscribeUserNewsLetterModal = new bootstrap.Modal('#subscribe-user-newsLetter-modal');
        //subscribeUserNewsLetterModal.hide();
        document.getElementById('subscribe-user-newsLetter-modal-close-button').click();

    }
}