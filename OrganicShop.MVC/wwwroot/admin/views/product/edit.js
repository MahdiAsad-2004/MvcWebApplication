

let SelectPropertiesElem = document.getElementById('select-properties');
let PropertiesContainerDiv = document.getElementById('properties-container');
let PropertyRowElem = null;

SelectPropertiesElem.onchange = (e) => {
    var selectedOption = e.target.options[e.target.selectedIndex];
    if (selectedOption.value) {

        // if (Boolean(document.getElementById(propertyGroupId)) == false) {
        // PropertiesContainerDiv.insertAdjacentHTML('beforeend', `  <div class="input-group mt-4" id="property-group-${selectedOption.value}">
        //                                 <span class="input-group-text">${selectedOption.text}</span>
        //                                 <input data-val="true" data-val-required="${selectedOption.text} ضروری است" name="Properties[asdd]" type="text" class="form-control" />
        //                                 <button onclick="DeletePropertyGroup(${selectedOption.value})" type="button" style="background-color:#dd0000;" class="btn btn-sm"><i class="fa-solid fa-xmark" style="color: white; font-size:22px;"></i></butto>
        //                                                                                                 </div>
        //                                 <span class="mt-1 text-danger field-validation-error" data-valmsg-for="Properties[asdd]" data-valmsg-replace="true"></span>`);
        // }
        //console.log($(document.getElementById(`property-group-${selectedOption.value}`).querySelector('input')).valid());
        // ====>>>> In This Way Validation For Input Not Work !

        PropertyRowElem = document.getElementById(`property-row-${selectedOption.value}`);
        PropertyRowElem.classList.remove('d-none');
        PropertyRowElem.querySelectorAll('input').forEach(x => x.disabled = false);
        //PropertyRowElem.querySelector('input').disabled = false;
    }
    e.target.options[0].selected = true;
}

function DeletePropertyGroup(propertyId) {

    PropertyRowElem = document.getElementById(`property-row-${propertyId}`);
    PropertyRowElem.classList.add('d-none');
    PropertyRowElem.querySelectorAll('input').forEach(x => x.disabled = true);
    //PropertyRowElem.querySelector('input').disabled = true;
}

let NewImagesContainer = document.getElementById('new-images-container');
let ImageCounter = 0;

function PreviewImages(e) {
    var imageUrl = '';
    var imgElem = null;
    NewImagesContainer.innerHTML = '';
    e.target.files.forEach(file => {
        ImageCounter++;
        imageUrl = URL.createObjectURL(file);

        NewImagesContainer.insertAdjacentHTML('beforeend', `
    <img id="img-${ImageCounter}" class="col-sm-2 image-fluid rounded-2" style="border:solid 2px black; margin-left:6px; margin-right:6px; margin-top:14px;" />
    `);

        imgElem = document.getElementById(`img-${ImageCounter}`);
        imgElem.src = imageUrl;
        imgElem.onload = () => {
            URL.revokeObjectURL(imageUrl);
        };
    });
}

function DeleteOldPicture(key) {
    document.getElementById(`old-picture-${key}`).remove();
}

let OldMainPictureUrl = document.getElementById('main-picture-url').innerHTML;
//console.log(OldMainPictureName);
function EditImage(e, imageContainerId) {
    var imageUrl = '';
    var imgElem = document.getElementById(imageContainerId);
    var file = e.target.files[0];
    if (file) {
        imageUrl = URL.createObjectURL(file);
        imgElem.src = imageUrl;
        imgElem.onload = () => {
            URL.revokeObjectURL(imageUrl);
        };
    }
    else {
        imgElem.src = OldMainPictureUrl;
    }

}










let AddUnitValueButton = document.getElementById('add-unit-value-button');
let UnitsContainer = document.getElementById('units-container');
let UnitTypeSelect = document.getElementById('unit-type-select');
let UnitTypeValue = UnitTypeSelect.options[0].value;
let UnitTypeText = UnitTypeSelect.options[0].text;
let UnitsCounter = 0;
AddUnitValueButton.disabled = true;

AddUnitValueButton.onclick = () => {
    if (UnitTypeValue > 1) {
        UnitsCounter++;
        UnitsContainer.insertAdjacentHTML('beforeend', `
         <div class="mt-1 col-4" id="unit-group-${UnitsCounter}">
                <div class="input-group">
                    <input data-val="true" type="number" min="0" step="0.1" name="UnitValuesArray" type="text" class="form-control" />
                    <span class="input-group-text unit-type-text">${UnitTypeText}</span>
                    <button onclick="DeleteUnitGroup(${UnitsCounter})" type="button" style="background-color:#dd0000;" class="btn btn-sm"><i class="fa-solid fa-xmark" style="color: white; font-size:22px;"></i></button>
                </div>
        </div>
        `)
    }
}

UnitTypeSelect.onchange = (e) => {
    var selectedOption = e.target.options[e.target.selectedIndex];
    UnitTypeText = selectedOption.text;
    UnitTypeValue = selectedOption.value;
    if (selectedOption.value && selectedOption.value > 1) {
        UnitsContainer.querySelectorAll('.unit-type-text').forEach(a => {
            a.innerHTML = UnitTypeText;
        });
        AddUnitValueButton.disabled = false;
    }
    else {
        UnitsContainer.innerHTML = '';
        UnitsCounter = 0;
        AddUnitValueButton.disabled = true;
    }
};

function DeleteUnitGroup(unitNumber) {
    document.getElementById(`unit-group-${unitNumber}`).remove();
}





