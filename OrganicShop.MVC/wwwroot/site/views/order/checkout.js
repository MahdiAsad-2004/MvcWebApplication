$(`.p-date-picker`).persianDatepicker({
    formatDate: "YYYY/MM/DD",
    cellWidth: 35,
    cellHeight: 30,
    fontSize: 15,
    onSelect: function () {
        for (var input of document.getElementsByClassName('p-date-picker')) {
            console.log(`${input.getAttribute('name')}: ${$(input).valid()}`);
        }
    },
    onRender: function () {
        console.log('render');
    }
});



async function LoadAddresses() {
    return new Promise(async (resolve, reject) => {
        var result = await FetchRequestFormWithId('load-checkout-addresses-form');
        resolve(result);
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