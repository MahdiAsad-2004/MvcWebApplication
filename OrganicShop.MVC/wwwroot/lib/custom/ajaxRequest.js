


//let Forms = Array.from(document.getElementsByClassName('ajax-request'));

//let Formss = Array.from(document.getElementsByName('form'));
//Formss.forEach(function (a) {
//    if (a.classList.contains('ajax-request')) {
//        a.onsubmit = function (e) {
//            e.preventDefault();
//            console.log('form has ajax request');
//        }
//    }
//    else {
//        a.onsubmit = function (e) {
//            console.log('form does not have ajax request');
//        }
//    }

//})


let As = Array.from(document.getElementsByClassName('ajax-load-partial'));


var elem = document.getElementById('sdfs');

var formData = new FormData();


var fff = document.createElement('form');

let element = document.createElement('form')

let loadingBackground = document.getElementById('loading-background');
let loadingSvg = document.getElementById('loading-svg');



function ShowLoading() {

    return new Promise((resolve, reject) => {

        loadingBackground.style.height = '' + document.body.clientHeight + 'px';
        loadingBackground.style.display = 'block';
        loadingSvg.style.display = 'block';

        //console.log('show');

        resolve();

    });


}

function HideLoading() {

    return new Promise((resolve, reject) => {

        loadingBackground.style.display = 'none';
        loadingSvg.style.display = 'none';

        //console.log('hide');

        resolve();

    });

}

//let myPromise = new Promise(ShowLoading);



//document.getElementById('asdf').onclick = () => {
//    loadingBackground.style.display = 'block';
//    loadingSvg.style.display = 'block';
//    console.log(loadingBackground);
//}



function AjaxRequest(e) {
    element = e.target;
    console.log(e.target);
    e.preventDefault();
    ShowLoading();
    OnSubmit();
    HideLoading();
}





function OnSubmit() {
    if ($(element).valid()) {
        formData = new FormData(element);
        $.ajax({
            url: element.getAttribute('href'),
            method: element.getAttribute('method'),
            data: formData,
            async: false,
            processData: false,
            contentType: false,
            success: function (result, textStatus, jqxhr) {
                HandleResponse(result, jqxhr);
            },
            error: function (x, y, z) {
                console.log(x);
                console.log(y);
                console.log(z);
            },
        });
        element.reset();
    }
    else {
        console.log('form is invalid');
    }
}





As.forEach(function (element) {
    if (element.tagName === 'A') {
        if (element.hasAttribute('data-target-id')) {
            element.onclick = function (e) {
                e.preventDefault();
                var elementTargetId = element.getAttribute('data-target-id');
                var targetElement = document.getElementById(elementTargetId);
                $.ajax({
                    url: element.getAttribute('href'),
                    method: 'get',
                    data: {},
                    success: function (result, textStatus, jqxhr) {
                        targetElement.innerHTML = result;
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    },
                });
            }
        }
    }
})



let fetchResponse = null;
let formElem = document.createElement('form');
let formMethod;
let CkEditorElement = document.getElementById('ckeditor');

async function FetchRequest(e) {
    e.preventDefault();
    formElem = e.target;
    console.log(formElem);
    CkEditorElement = formElem.querySelector('#ckeditor');
    console.log(`Is Form Valid: ${$(formElem).valid()}`)
    if ($(formElem).valid()) {
        ShowLoading();
        try {
            formData = new FormData(formElem);
            if (CkEditorElement) {
                formData.set(CkEditorElement.name, `${CkEditor.getData()}`);
            }
            formMethod = formElem.getAttribute('method').toLowerCase();
            fetchResponse = await fetch(formElem.action, {
                method: formMethod,
                body: formMethod == 'get' ? null : formData,
            });
            HandleFetchResponse(fetchResponse, e.target);
            formElem.reset();
        }
        catch (er) {
            Toast('Warning', 'An error was thrown from client', 2, 5000);
            console.log(er);
        }
        HideLoading();
    }
    else {

    }
}


let RequestResult = false;
async function FetchRequestForm(form) {
    RequestResult = false;

    return new Promise(async (resolve, reject) => {

        form.onsubmit = () => false;
        form.requestSubmit();
        //console.log(form);
        //console.log(new FormData(form));
        CkEditorElement = form.querySelector('#ckeditor');
        console.log(`Is Form Valid: ${$(form).valid()}`)
        if ($(form).valid()) {
            ShowLoading();
            try {
                formData = new FormData(form);
                if (CkEditorElement) {
                    formData.set(CkEditorElement.name, `${CkEditor.getData()}`);
                }
                formMethod = form.getAttribute('method').toLowerCase();
                fetchResponse = await fetch(form.action, {
                    method: formMethod,
                    body: formMethod == 'get' ? null : formData,
                });
                RequestResult = await HandleFetchResponse(fetchResponse, form);
                form.reset();
            }
            catch (er) {
                Toast('Warning', 'An error was thrown from client', 2, 5000);
                console.log(er);
            }
            await HideLoading();
        }

        resolve(RequestResult);

        //return RequestResult;

    });


    //return new Promise((resolve, reject) => {
    //    resolve(RequestResult);
    //});
}



async function FetchRequestFormWithId(formId) {

    return new Promise(async (reslove, reject) => {
        var result = false;

        var form = document.getElementById(formId);
        if (form) {
            result = await FetchRequestForm(form);
        }
        else {
            console.log('FetchRequestFormWithId => form not found');
        }

        reslove(result);
    })

}


let containerId = null;
let containerElement = document.createElement('div');
let promiseResponse = null;
async function LoadPartial(e) {
    e.preventDefault();
    containerId = e.target.getAttribute('data-container-id');
    if (containerId) {
        containerElement = document.getElementById(containerId);
        if (containerElement) {
            try {
                promiseResponse = await fetch(e.target.getAttribute('href'), {
                    method: 'get',
                });
                promiseResponse.text()
                    .then(p => containerElement.innerHTML = p);
            }
            catch (er) {
                Toast('Warning', 'An error was thrown from client', 2, 5000);
                console.log(er);
            }
        }
    }
}

//async function LoadPartial(e) {

//    e.preventDefault();
//    containerId = e.target.getAttribute('data-container-id');
//    if (containerId) {
//        containerElement = document.getElementById(containerId);
//        if (containerElement) {
//            $.ajax({
//                url: element.getAttribute('href'),
//                method: 'get',
//                data: {},
//                success: function (result, textStatus, jqxhr) {
//                    targetElement.innerHTML = result;
//                },
//                error: function (jqXHR, textStatus, errorThrown) {
//                    console.log(jqXHR);
//                    console.log(textStatus);
//                    console.log(errorThrown);
//                },
//            });

//        }
//    }
//}







//function P1(response) {
//    var targetElementId = response.headers.get('ResponseDataType');
//    if (ttargetElementId) {
//        document.getElementById('view-container').innerHTML = document.getElementById(TargetElementId).innerHTML = ;
//    }
//    ViewContainer.innerHTML = data;
//}