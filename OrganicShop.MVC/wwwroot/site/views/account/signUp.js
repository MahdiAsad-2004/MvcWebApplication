
let AcceptTermsCheck = document.getElementById('accept-terms-check');
let SubmitSignUpButton = document.getElementById('submit-sign-up-button');



function AcceptTermsCheckChanged(e) {
    SubmitSignUpButton = document.getElementById('submit-sign-up-button');
    if (e.target.checked) {
        SubmitSignUpButton.disabled = false;
    }
    else {
        SubmitSignUpButton.disabled = true;
    }
}


