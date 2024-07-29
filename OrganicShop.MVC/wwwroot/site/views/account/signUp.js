let AcceptTermsCheck = document.getElementById('accept-terms-check');

let SubmitSignUpButton = document.getElementById('submit-sign-up-button');

AcceptTermsCheck.oninput = (e) => {
    if (e.target.checked) {
        SubmitSignUpButton.disabled = false;
    }
    else {
        SubmitSignUpButton.disabled = true;
    }
}