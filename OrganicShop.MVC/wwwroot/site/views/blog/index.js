
let FilterArticlesForm = document.getElementById('filter-articles-form');

function SubmitFormWithDelay(form, delay) {
    setTimeout(() => {
        form.submit();
    }, delay)
};


function ChangeTagIds(tagId) {
    document.getElementById(`tagId-${tagId}-input`).disabled = false;
    FilterArticlesForm.submit();
} 

