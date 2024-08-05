
async function LoadAddresses() {
    return new Promise(async (resolve, reject) => {
        await FetchRequestFormWithId('load-checkout-addresses-form');
        resolve();
    })

}

async function AddAddressSubmit() {
    if (await FetchRequestFormWithId('add-address-form')) {
        document.getElementById('add-address-modal-from-close-button').click();
        await LoadAddresses()
    }
}


async function ShippingMethodChange(input) {
    console.log(input.value);
    var shippingMethodId = +input.value;
    if (shippingMethodId) {
        var form = document.getElementById('load-checkout-form');
        form.querySelector(`input[name='shippingMethodId']`).value = shippingMethodId;
        await FetchRequestForm(form);
    }
}