
$.validator.addMethod('duplicateEmail', function (value, element, params) {
    var isExist = false;
    value = value.toLowerCase();
    $.ajax({
        url: '/Admin/User/EmailExist',
        type: 'Get',
        data: { email: value },
        async: false,
        success: function (res) {
            isExist = res;
        },
        error: function (ts) {

        },
    });
    return !isExist;
});

$.validator.unobtrusive.adapters.add('duplicateEmail', function (options) {
    options.rules['duplicateEmail'] = [];
    options.messages['duplicateEmail'] = options.message;
});


//------------------------------------------------------------------------------------------------------------------------


$.validator.addMethod('fileSize', function (value, element, params) {
    for (var file of element.files) {
        if (file != null) {
            if ((file.size / 1024) > params.max) {
                return false;
                break;
            }
        }
    }
    //var image = element.files[0];
    //if (image != null) {
    //    var imageSize = image.size / 1024;
    //    if (imageSize > params.max) {
    //        return false;
    //    }
    //}
    return true;
});

$.validator.unobtrusive.adapters.add(
    'fileSize',
    ['max'],
    function (options) {
        options.rules['fileSize'] = options.params;
        options.messages['fileSize'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('fileFormat', function (value, element, params) {
    for (var file of element.files) {
        if (file != null) {
            let fileExtension = file.name.split('.').pop();
            if (params.formats.split('/').some(a => a == fileExtension) == false) {
                return false;
                break;
            }
        }
    }
    //var file = element.files[0];
    //if (file != null) {
    //    let fileExtension = file.name.split('.').pop();
    //    //console.log(params.formats.split('/'));
    //    return params.formats.split('/').some(a => a == fileExtension);
    //}
    return true;
});

$.validator.unobtrusive.adapters.add(
    'fileFormat',
    ['formats'],
    function (options) {
        options.rules['fileFormat'] = options.params;
        options.messages['fileFormat'] = options.message;
    }
);

//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('minDate', function (value, element, params) {
    if (new Date(value) != 'Invalid Date') {
        return new Date(value) >= new Date(params.min);
    }
    return true;
});
$.validator.unobtrusive.adapters.add(
    'minDate',
    ['min'],
    function (options) {
        options.rules['minDate'] = options.params;
        options.messages['minDate'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('maxDate', function (value, element, params) {
    if (new Date(value) != 'Invalid Date') {
        return new Date(value) < new Date(params.max);
    }
});

$.validator.unobtrusive.adapters.add(
    'maxDate',
    ['max'],
    function (options) {
        options.rules['maxDate'] = options.params;
        options.messages['maxDate'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('lowerThan', function (value, element, params) {
    if (value) {
        var indicatorValue = document.querySelector(`[data-indicator-${params.indicatorName}]`).value;
        if (indicatorValue) {
            if (indicatorValue.trim() != '') {
                if (params.type == 'date') {
                    return new Date(value) < new Date(indicatorValue);
                }
                else if (params.type == 'number') {
                    return Number(value) < Number(indicatorValue);
                }
            }
        }
    }
    return true;
});


$.validator.unobtrusive.adapters.add(
    'lowerThan',
    ['indicatorName', 'type'],
    function (options) {
        options.rules['lowerThan'] = options.params;
        options.messages['lowerThan'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('greaterThan', function (value, element, params) {
    if (value) {
        var indicatorValue = document.querySelector(`[data-indicator-${params.indicatorName}]`).value;
        if (indicatorValue) {
            if (indicatorValue.trim() != '') {
                if (params.type == 'date') {
                    return new Date(value) > new Date(indicatorValue);
                }
                else if (params.type == 'number') {
                    return Number(value) > Number(indicatorValue);
                }
            }
        }
    }
    return true;
});

$.validator.unobtrusive.adapters.add(
    'greaterThan',
    ['indicatorName', 'type'],
    function (options) {
        options.rules['greaterThan'] = options.params;
        options.messages['greaterThan'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------

$.validator.addMethod('filesCount', function (value, element, params) {
    //console.log("File Count: " + params.max);
    if (element.files) {
        var filesCount = element.files.length;
        if (filesCount) {
            if (filesCount > params.max || filesCount < params.min) {
                return false;
            }
        }
    }

    return true;
});

$.validator.unobtrusive.adapters.add(
    'filesCount',
    ['min', 'max'],
    function (options) {
        options.rules['filesCount'] = options.params;
        options.messages['filesCount'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------


$.validator.addMethod('date', function (value, element, params) {

    const dateRegex = new RegExp('[1,2][0-9][0-9]{2}[/,-,-,.][0-9]{1,2}[/,-,-,.][0-9]{1,2}');

    if (dateRegex.test(value) == false)
        return false;

    if (new Date(value) == 'Invalid Date')
        return false;

    if (value.search(/\D00\D*/gm) > 0)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add(
    'date',
    [],
    function (options) {
        options.rules['date'] = options.params;
        options.messages['date'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------


$.validator.addMethod('PersianDate', function (value, element, params) {

    value = value.trim()
    const dateRegex = new RegExp('1[3,4][0-9]{2}[/,-,-,.][0-9]{1,2}[/,-,-,.][0-9]{1,2}');

    if (dateRegex.test(value) == false)
        return false;

    var p = new PersianDate();
    if (p.fromJalali(value)['error'])
        return false;

    if (value.search(/\D00\D*/gm) > 0)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add(
    'PersianDate',
    [],
    function (options) {
        options.rules['PersianDate'] = options.params;
        options.messages['PersianDate'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------









