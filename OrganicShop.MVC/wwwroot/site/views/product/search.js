
let SearchBoxForm = document.getElementById('search-box-form');
let SearchBoxFormInput = document.getElementById('search-box-form-input');
let SearchBoxFormButton = document.getElementById('search-box-form-button');
//let CurrentSearchTextSpan = document.getElementById('searchText-span');

SearchBoxFormButton.onclick = async () => {
    location.replace(`/products/search/${SearchBoxFormInput.value}`);
    //SearchBoxForm.action = `/products/search/${SearchBoxFormInput.value}`;
    //await FetchRequestForm(SearchBoxForm);
}

SearchBoxForm.onsubmit = (e) => {
    e.preventDefault();
    location.replace(`/products/search/${SearchBoxFormInput.value}`);
    //SearchBoxForm.action = `/products/search/${SearchBoxFormInput.value}`;
    //await FetchRequestForm(e.target);
}




