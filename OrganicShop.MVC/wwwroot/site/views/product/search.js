
let SearchBoxForm = document.getElementById('search-box-form');
let SearchBoxFormInput = document.getElementById('search-box-form-input');
let SearchBoxFormButton = document.getElementById('search-box-form-button');
let CurrentSearchTextSpan = document.getElementById('searchText-span');

SearchBoxFormButton.onclick = () => {
    window.location.href.replace(`/search/${CurrentSearchTextSpan.innerText}`, `/search/${SearchBoxFormInput.value}`);
    CurrentSearchTextSpan.innerText = SearchBoxFormInput.value;
    var result = await FetchRequestForm(SearchBoxForm);
    if (result) {
    }
    else {
        window.location.reload();
    }
}





