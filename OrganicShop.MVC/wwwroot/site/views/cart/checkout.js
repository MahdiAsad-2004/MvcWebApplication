


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


let AddAddressModalFrom = document.getElementById('add-address-modal-from');
let AddAddressModalFromSubmitButton = document.getElementById('add-address-modal-from-submit-button');
let AddAddressModalFromCloseButton = document.getElementById('add-address-modal-from-close-button');

const myModalAlternative = new bootstrap.Modal('#add-address-modal-from');

AddAddressModalFromButton.onclick = () => {
    var result = await FetchRequestForm(AddAddressModalFrom);
    if (result) {
        //AddAddressModalFromCloseButton.click();
        //myModalAlternative.hide();
        setTimeout(() => {
            window.location.reload();
        }, 2000);
    }
}