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