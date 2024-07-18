let MessageTypes = [
    { Icon: 'success', Color: '#27a027', BackGround: '#dff9ec' },
    { Icon: 'error', Color: '#af2727', BackGround: '#ffe5e5' },
    { Icon: 'warning', Color: '#e3b519', BackGround: '#fff2e1' },
    { Icon: 'info', Color: '#0e74b4', BackGround: '#d6f7fa' },
    { Icon: 'question', Color: '#585e64', BackGround: '#e7ebef' }
];


let MessagePositions = ["top", "top-start", "top-end", "center", "center-start", "center-end", "bottom", "bottom-start", "bottom-end"];

let Message = {
    Title: "", Text: "", Position: 0, Type: 0, TimeMs: 0,
};

let Redirect = {
    Url: "", IsReplace: "", TimeOut: 0,
};

let Messagetype = MessageTypes[0];

let ViewContainer = document.getElementById('view-container');

var TargetElementId = null;
var ContainerElementId = null;

let ResponseDataType = '';

let MessageString = null;


//function HandleResponse(data, jqxhr) {
//    ShowLoading();
//    if (jqxhr == null || jqxhr == undefined) {
//        throw new Error("jxhr is null or undefined");
//    }
//    ResponseDataType = jqxhr.getResponseHeader("ResponseDataType");

//    if (ResponseDataType == 'partial') {
//        Partial(data, jqxhr);
//    }
//    else if (ResponseDataType == 'partial-toast') {
//        PartialThenToast(data, jqxhr);
//    }
//    else if (ResponseDataType == 'redirect-toast') {
//        RedirectThenToast(data, jqxhr);
//    }
//    else if (ResponseDataType == 'toast-redirect') {
//        ToastThenRedirect(data, jqxhr);
//    }
//    else if (ResponseDataType == 'toast-refresh') {
//        ToastThenRefresh(data, jqxhr);
//    }
//    else if (ResponseDataType == 'toast') {
//        Message = JSON.parse(data);
//        HandleMessage(Message);
//    }
//    HideLoading();
//}



async function HandleFetchResponse(response, form) {
    let ResponseResult = true;

    if (response.status < 400) {
        ResponseDataType = response.headers.get('ResponseDataType');
        ResponseResult = response.headers.get('ResponseResult') == 'True';
        //console.log(`Response Result : ${ResponseResult}`);
        //console.log(response.headers.get('ResponseResult'));
        if (ResponseDataType == 'partial') {
            await Partial(response, form);
        }
        else if (ResponseDataType == 'partial-toast') {
            await PartialThenToast(response, form);
        }
        else if (ResponseDataType == 'redirect-toast') {
            await RedirectThenToast(response);
        }
        else if (ResponseDataType == 'toast-redirect') {
            await ToastThenRedirect(response);
        }
        else if (ResponseDataType == 'toast-refresh') {
            await ToastThenRefresh(response);
        }
        else if (ResponseDataType == 'toast') {
            await response.json().then(a => { HandleMessage(a) });
        }
        else if (ResponseDataType == 'json') {
            await response.json().then(a => { console.log(a); });
        }
        else if (ResponseDataType == 'redirect') {
            await RedirectThenToast(response);
        }
        else if (ResponseDataType == 'empty') {
            // nothing to do
        }
        return ResponseResult;
    }
    else {
        if (response.status == 500) {
            Toast('Warning', 'Internal Server error', 2, 5000);
        }
        else if (response.status == 400) {
            Toast('Warning', 'Bad Request', 2, 5000);
        }
        else if (response.status == 401) {
            Toast('Warning', 'Unauthorized', 2, 5000);
        }
        else if (response.status == 403) {
            Toast('Warning', 'Forbidden', 2, 5000);
        }
        else if (response.status == 404) {
            Toast('Warning', 'Not Found', 2, 5000);
        }
        else if (response.status == 405) {
            Toast('Warning', 'Not Allowed', 2, 5000);
        }
        else if (response.status == 503) {
            Toast('Warning', 'Service Unavailable', 2, 5000);
        }
        console.log(response);
        return false;
    }

}




async function Partial(response, form) {
    ContainerElementId = form.getAttribute('data-container-id');
    TargetElementId = form.getAttribute('data-target-id');
    response.text().then(partial => {
        if (TargetElementId) {
            console.log(document.getElementById(TargetElementId));
            //console.log(partial);


            document.getElementById(TargetElementId).insertAdjacentHTML('afterend', partial);
            //document.getElementById(TargetElementId).insertAdjacentElement('beforeend', document.createElement('h6'));


            console.log(document.getElementById(TargetElementId));

            //var template = document.createElement('div');
            //template.append(partial);
            //console.log(template);
            //console.log(template.firstChild);
            //console.log(String.toString(partial));
            //document.getElementById(TargetElementId).replaceWith(document.createElement('h6'));


            //document.getElementById(TargetElementId).remove();
        }
        else if (ContainerElementId) {
            document.getElementById(ContainerElementId).innerHTML = partial;
        }
        else {
            ViewContainer.innerHTML = partial;
        }
    });

}

function PartialThenToast(response, form) {
    ContainerElementId = form.getAttribute('data-container-id');
    TargetElementId = form.getAttribute('data-target-id');
    MessageString = response.headers.get("Message");
    Message = JSON.parse(MessageString);
    response.text().then(partial => {

        if (TargetElementId) {
            console.log(document.getElementById(TargetElementId));
            document.getElementById(TargetElementId).insertAdjacentHTML('beforebegin', partial);
            document.getElementById(TargetElementId).remove();
        }
        else if (ContainerElementId) {
            document.getElementById(ContainerElementId).innerHTML =partial;
        }
        else {
            ViewContainer.innerHTML = partial;

        }
    });

    HandleMessage(Message);
}

function ToastThenRedirect(response) {
    MessageString = response.headers.get("Message");
    Message = JSON.parse(MessageString);
    response.json().then(redirect => {
        HandleMessage(Message);
        setTimeout(function () {
            if (redirect.IsReplace == true) {
                location.replace(redirect.Url);

            }
            else {
                location.assign(redirect.Url);
            }
        }, Message.TimeMs)
    })

}


function RedirectThenToast(response) {
    response.json().then(redirect => {
        if (redirect.IsReplace == true) {
            console.log("replace action");
            location.replace(redirect.Url);
        }
        else {
            location.assign(redirect.Url);
        }
    });
}

//function Redirect(response) {
//    response.json().then(redirect => {
//        if (redirect.IsReplace == true) {
//            console.log("replace action");
//            location.replace(redirect.Url);
//        }
//        else {
//            location.assign(redirect.Url);
//        }
//    });
//}



function ToastThenRefresh(response) {
    response.json().then(message => {
        HandleMessage(message);
        setTimeout(function () {
            location.reload();
        }, message.TimeMs)
    });
}



























//function Partial(data, jqxhr) {
//    TargetElementId = jqxhr.getResponseHeader('targetElementId');
//    if (TargetElementId) {
//        ViewContainer = document.getElementById(TargetElementId);
//    }
//    ViewContainer.innerHTML = data;
//}



//function PartialThenToast(data, jqxhr) {
//    TargetElementId = jqxhr.getResponseHeader('targetElementId');
//    if (TargetElementId) {
//        ViewContainer = document.getElementById(TargetElementId);
//    }
//    MessageString = jqxhr.getResponseHeader("Message");
//    Message = JSON.parse(MessageString);
//    ViewContainer.innerHTML = data;
//    HandleMessage(Message);
//}



//function ToastThenRedirect(data, jqxhr) {
//    MessageString = jqxhr.getResponseHeader("Message");
//    Message = JSON.parse(MessageString);
//    Redirect = JSON.parse(data);
//    HandleMessage(Message);
//    setTimeout(function () {
//        if (Redirect.IsReplace == true) {
//            console.log("replace action");
//            location.replace(Redirect.Url);

//        }
//        else {
//            location.assign(Redirect.Url);
//        }
//    }, Message.TimeMs + 1000)
//}


//function RedirectThenToast(data, jqxhr) {
//    Redirect = JSON.parse(data);
//    if (Redirect.IsReplace == true) {
//        console.log("replace action");
//        location.replace(Redirect.Url);

//    }
//    else {
//        location.assign(Redirect.Url);
//    }
//}


//function ToastThenRefresh(data, jqxhr) {
//    Message = JSON.parse(data);
//    HandleMessage(Message);
//    setTimeout(function () {
//        location.reload();
//    }, Message.TimeMs + 1000)
//}



function HandleMessage(message) {

    var messageType = MessageTypes[message.Type];
    Swal.fire({
        toast: true,
        title: `<span style="color:${messageType.Color}; font-family: 'iransans'!important; font-size:22px; font-weight:600;">${message.Title}</span>`,
        //titleText: title,
        //text: text,
        html: `<span style="color: #000000; font-family: 'iranyekan'!important; font-size: 17px;">${message.Text}</span>`,
        icon: messageType.Icon,
        timer: message.TimeMs == 0 ? undefined : message.TimeMs,
        position: MessagePositions[message.Position],
        background: messageType.BackGround,
        timerProgressBar: message.TimeMs == 0 ? false : true,

        showConfirmButton: false,
        showCloseButton: false,
        width: '500px',
        allowEscapeKey: false,
        //allowEnterKey: false,
        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
    });
}



function Toast(title, text, typeIndex, timeMs) {
    Messagetype = MessageTypes[typeIndex];
    //console.log(Messagetype);
    Swal.fire({
        toast: true,
        title: `<span style="color:${Messagetype.Color}; font-family: 'iransans'!important; font-size:22px; font-weight:600;">${title}</span>`,
        //titleText: title,
        //text: text,
        html: `<span style="color: #000000; font-family: 'iranyekan'!important; font-size: 17px;">${text}</span>`,
        icon: Messagetype.Icon,
        timer: timeMs == 0 ? undefined : timeMs,
        position: 'top-end',
        background: Messagetype.BackGround,
        timerProgressBar: timeMs == 0 ? false : true,

        showConfirmButton: false,
        showCloseButton: false,
        width: '500px',
        allowEscapeKey: false,
        //showCloseButton: true,
        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
        //allowEscapeKey:true,
        //allowEnterKey:true,
    });
}












