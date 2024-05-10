let FilterProductsForm = document.getElementById('filter-products-form');


let MinPriceRange = document.getElementsByName('filter.MinPrice')[0];
let MaxPriceRange = document.getElementsByName('filter.MaxPrice')[0];
let MinPriceSpan = document.getElementById('minPrice-value');
let MaxPriceSpan = document.getElementById('maxPrice-value');


MinPriceRange.oninput = (e) => {
    MinPriceSpan.innerHTML = Number(e.target.value).formatMoney(',');
};

MaxPriceRange.oninput = (e) => {
    MaxPriceSpan.innerHTML = Number(e.target.value).formatMoney(',');
};

MinPriceRange.onchange = (e) => {
    SubmitFormWithDelay(FilterProductsForm, 1500);
};

MaxPriceRange.onchange = (e) => {
    SubmitFormWithDelay(FilterProductsForm, 1500);
};




let RateCheckboxes = Array.from(document.getElementsByName('filter.Rate'));

function ChangeRateCheckbox(e) {
    RateCheckboxes.forEach(a => {
        a.checked = false;
    });
    e.target.checked = true;
    SubmitFormWithDelay(FilterProductsForm, 500);
}


function ChangeCategoryCheckbox(e) {
    SubmitFormWithDelay(FilterProductsForm, 500);
};


let SortBySelect = document.getElementsByName('filter.SortBy')[0];
function ChangeSortSelect(e) {
    SortBySelect.value = e.target.value;
    SubmitFormWithDelay(FilterProductsForm, 500);
}

function SubmitFormWithDelay(form,delay) {
    setTimeout(() => {
        form.submit();
    }, delay)
}



function RemoveMinPriceFilter() {
    MinPriceRange.value = 0;
    FilterProductsForm.submit();
}
function RemoveMaxPriceFilter() {
    MaxPriceRange.value = MaxPriceRange.max;
    FilterProductsForm.submit();
}
function RemoveRateFilter() {
    RateCheckboxes.forEach(a => a.checked = false);
    FilterProductsForm.submit();
}

function RemoveCategoryFilter(categoryId) {
    document.getElementById(`category-id-${categoryId}`).checked = false;
    FilterProductsForm.submit();
}
