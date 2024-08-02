//EditProductWishListForm = document.getElementById('edit-product-wishlist-form');

var isInWishList = false;
async function EditProductInWishList1(event, productId) {
    if (productId > 0) {
        var btn = event.target;
        EditProductWishListForm.querySelector("input[name = 'productId']").value = productId;
        isInWishList = btn.getAttribute('data-iswish') == 'true';
        EditProductWishListForm.querySelector("input[name = 'isDelete']").value = isInWishList;
        //AddProductToWishlistProductIdInput.value = productId;
        var result = await FetchRequestForm(EditProductWishListForm);
        if (result == true) {
            if (isInWishList) {
                btn.firstChild.style.removeProperty('color')
                btn.setAttribute('data-iswish', 'false');

            }
            else {
                btn.firstChild.style.setProperty('color', 'red');
                btn.setAttribute('data-iswish', 'true');
            }
        }
    }
}