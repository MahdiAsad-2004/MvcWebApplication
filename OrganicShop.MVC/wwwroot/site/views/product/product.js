
let ProductCommentForm = document.getElementById('product-comment-form');
let ProductCommentButton = document.getElementById('product-comment-button');
ProductCommentButton.onclick = (e) => {
    SubmitFormWithButton(ProductCommentForm);
}



const commentStarFillHtml = '<i data-feather="star" class="fill"></i>';   
const commentStarEmptyHtml = '<i data-feather="star"></i>';   
function ChangeCommentRateStars(select) {
    console.log(select.value);
    const commentRateStarsContainer = document.getElementById('comment-rate-stars');
    let rate = +select.value;
    if (rate) {
        for (var i = 1; i <= rate; i++) {
            commentRateStarsContainer.insertAdjacentHTML('beforeend', commentStarFillHtml);
        }
        for (var i = 1; i <= 5 - rate; i++) {
            commentRateStarsContainer.insertAdjacentHTML('beforeend', commentStarEmptyHtml);
        }
    }
}









