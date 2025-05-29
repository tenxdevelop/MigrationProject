// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let targets = [];
let regulations = []
let countries = []
let documents = []
var selectedDocuments = [];
var selectedCountries = []
let documentsDict = {
    "HighlyQualifiedDocument": "Высоквалифицированный специалист",
    "ResettlementDocument": "Член программы переселения",
    "ConsistOfMigrationProgramDocument": "Состоял на миграционном учёте раннее",
    "Высоквалифицированный специалист": "HighlyQualifiedDocument",
    "Член программы переселения": "ResettlementDocument",
    "Состоял на миграционном учёте раннее": "ConsistOfMigrationProgramDocument"
}
targetName = ""

async function loadTargetsInstructionPage() {
    try {
        const response = await fetch('/Target/GetTargets');
        if (!response.ok) {
            throw new Error('Ошибка при загрузке: ' + response.status);
        }
        targets = await response.json();
        fullFillTargetSelect()
    } catch (error) {
        console.error('Ошибка:', error);
    }
}


function fullFillTargetSelect() {
    const select = document.getElementById('targetSelect');
    targets.forEach((target, index) => {
        const option = document.createElement('option');
        option.value = index;
        option.textContent = target.name;


        select.appendChild(option)
    });

    select.addEventListener('change', handleSelectionChange);
}


async function loadTargets() {
    try {
        const response = await fetch('/Target/GetTargets');
        if (!response.ok) {
            throw new Error('Ошибка при загрузке: ' + response.status);
        }
        targets = await response.json();
        populateSelect();
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function populateSelect() {
    const select = document.getElementById('targetSelect');
    targets.forEach((target, index) => {
        const option = document.createElement('option');
        option.value = index;
        option.textContent = target.name;


        selectChangeRegulation.appendChild(option)
    });

    select.addEventListener('change', handleSelectionChange);
}

function handleSelectionChange(event) {
    const selectedIndex = event.target.value;
    const block = document.getElementById('instructionBlock');
    const targetNameInput = document.getElementById('targetNameInput')

    const area = document.getElementById('instructionTextArea');


    if (selectedIndex === "") {
        block.style.display = 'none';
        return;
    }

    const selectedTarget = targets[selectedIndex];
    targetNameInput.value = selectedTarget.name
    targetName = selectedTarget.name
    area.value = selectedTarget.condition?.instruction || ''
    block.style.display = 'block';
}

async function loadTargetsChangeRegulation() {
    try {
        console.log('loadTargetsChangeRegulation called');
        const response = await fetch('/Target/GetTargets');
        if (!response.ok) {
            throw new Error('Ошибка при загрузке: ' + response.status);
        }
        targets = await response.json();
        changeTargetSelect()
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function changeTargetSelect() {
    const select = document.getElementById('ChangeRegulationTargetSelect');

    targets.forEach((target, index) => {
        const option = document.createElement('option');
        option.value = index;
        option.textContent = target.name;
        select.appendChild(option);
    });

    select.addEventListener('change', handleTargetChangeSelectionChange);
}

async function handleTargetChangeSelectionChange(event) {
    console.log('handleTargetChangeSelectionChange called with event:', event);
    const select = document.getElementById('ChangeRegulationTargetSelect');
    select.remove(0)
   
    var targetName = targets[event.target.value].name
    try {
        const response = await fetch(`/Target/GetRegulations?targetName=${targetName}`)
        if (!response.ok) {
            throw new Error('Ошибка при загрузке: ' + response.status);
        }
        regulations = await response.json();
        fullFillRegulationSelect()
    } catch (error) {
        console.error('Ошибка:', error);
    }

    const targetNameInput = document.getElementById('targetNameInput')
    targetNameInput.value = targetName
    


    const regulationSelect = document.getElementById('regulationSelect')
    regulationSelect.style.visibility = "visible"
}
function fullFillRegulationSelect() {
    const regulationSelect = document.getElementById('regulationSelect')
    regulations.forEach((regulation, index) => {
        const option = document.createElement('option')
        option.value = index
        option.textContent = regulation.name
        regulationSelect.appendChild(option)
    })

    regulationSelect.addEventListener('change', handleRegulationSelectionChange);
}

function handleRegulationSelectionChange(event) {

    var countrySelect = document.getElementById('countrySelect')
    var documentSelect = document.getElementById('documentSelect')
    var termInput = document.getElementById('termInput')
    var documentFormList = document.getElementById('documentBox')
    var countryFormList = document.getElementById('countryBox')


    var regulationNameInput = document.getElementById('ChangeRegulationTargetInput')
    var regulationIndex = event.target.value
    var regulation = regulations[regulationIndex]
    regulationNameInput.value = regulation.name





    if (termInput === null) {
        return
    }
    while (documentFormList.firstChild) {
        documentFormList.removeChild(documentFormList.firstChild);
    }
    while (countryFormList.firstChild) {
        countryFormList.removeChild(countryFormList.firstChild);
    }

    
    selectedCountries = []
    selectedDocuments = []


    document.getElementById("documentNames").value = selectedDocuments.join(',');
    document.getElementById("countryNames").value = selectedDocuments.join(',');


    var countries = regulation.countries
    var documents = regulation.useDocuments
    termInput.value = regulation.term
    console.log(regulationNameInput.value)
    regulationNameInput.value = regulation.name
    console.log(regulationNameInput.value)
    documentSelect.style.visibility = "Visible"
    termInput.style.visibility = "Visible"
    countrySelect.style.visibility = "Visible"
    documentFormList.style.visibility = "Visible"
    countryFormList.style.visibility = "Visible"

    documents.forEach(document => {
        addToForm(document)
    })

    countries.forEach(country => {
        addToCountryForm(country)
    })
}

var countryBox = document.getElementById("countryBox")
function addToCountryForm(countryValue) {
    var countryText = ""
    var valueForcountry = ""
    if (!(countryValue === undefined)) {
        valueForcountry = countryValue.name
        countryText = countryValue.name

        if (selectedCountries.includes(valueForcountry)) return;

        selectedCountries.push(valueForcountry);

        // Добавляю к строке новый документ, разделитель ','
        document.getElementById("countryNames").value = selectedCountries.join(',');

        var newCountryLine = document.createElement('div');
        newCountryLine.className = "d-flex flex-row";
        newCountryLine.id = valueForcountry;
        newCountryLine.innerHTML = `
            <span class = "d-flex align-items-center justify-content-between form-control">${countryText}
            <button class="btn btn-light" onclick="removeCountryItemFromBox('${valueForcountry}')">X</button></span>
        `;
        countryBox.appendChild(newCountryLine);
    }
    else {
        var countrySelect = document.getElementById("countrySelect");
        var selectedOption = countrySelect.options[countrySelect.selectedIndex];

        if (document.getElementById("selectLabel") != null) {
            document.getElementById("selectLabel").remove();
        }

        countryValue = selectedOption.value;
        countryText = selectedOption.textContent
        if (selectedCountries.includes(countryValue)) return;

        selectedCountries.push(countryValue);

        // Добавляю к строке новый документ, разделитель ','
        document.getElementById("countryNames").value = selectedCountries.join(',');

        var newCountryLine = document.createElement('div');
        newCountryLine.className = "d-flex flex-row";
        newCountryLine.id = countryValue;
        newCountryLine.innerHTML = `
            <span class = "d-flex align-items-center justify-content-between form-control">${countryText}
            <button class="btn btn-light" onclick="removeCountryItemFromBox('${countryValue}')">X</button></span>
        `;
        countryBox.appendChild(newCountryLine);
    }

    
}

function removeCountryItemFromBox(countryEnglishName) {
    var element = document.getElementById(countryEnglishName)
    element.remove();
    let currentValue = document.getElementById("countryNames").value;
    let value = currentValue.replace(countryEnglishName, "");
    selectedCountries = selectedCountries.filter(e => e !== countryEnglishName)
    // Обновляем значение инпута
    document.getElementById("countryNames").value = value;
}






//registerMigrant JS scripts
var documentBox = document.getElementById("documentBox")
 // Массив для хранения выбранных документов

function addToForm(documentValue) {
    var documentText = ""
    var valueForDocument = ""
    if (!(documentValue === undefined)) {
        valueForDocument = documentValue.name
        documentText = documentValue.name

        if (selectedDocuments.includes(documentValue.name)) return;

        selectedDocuments.push(documentValue.name);

        // Добавляю к строке новый документ, разделитель ','
        document.getElementById("documentNames").value = selectedDocuments.join(',');

        var newDocumentLine = document.createElement('div');
        newDocumentLine.className = "d-flex flex-row";
        newDocumentLine.id = documentValue.name;
        newDocumentLine.innerHTML = `
            <span class = "d-flex align-items-center justify-content-between form-control">${documentsDict[documentValue.name]}
            <button class="btn btn-light" onclick="removeItemFromBox('${documentValue.name}')">X</button></span>
        `;
        documentBox.appendChild(newDocumentLine);
    }
    else {
        var documentSelect = document.getElementById("documentSelect");
        var selectedOption = documentSelect.options[documentSelect.selectedIndex];

        if (document.getElementById("selectLabel") != null) {
            document.getElementById("selectLabel").remove();
        }

         documentValue = selectedOption.value;
        documentText = selectedOption.textContent

        if (selectedDocuments.includes(documentValue)) return;

        selectedDocuments.push(documentValue);

        // Добавляю к строке новый документ, разделитель ','
        document.getElementById("documentNames").value = selectedDocuments.join(',');

        var newDocumentLine = document.createElement('div');
        newDocumentLine.className = "d-flex flex-row";
        newDocumentLine.id = documentValue;
        newDocumentLine.innerHTML = `
            <span class = "d-flex align-items-center justify-content-between form-control">${documentText
    }
            <button class="btn btn-light" onclick="removeItemFromBox('${documentValue}')">X</button></span>
        `;
        documentBox.appendChild(newDocumentLine);
    }

   
}

function removeItemFromBox(documentEnglishName) {
    var element = document.getElementById(documentEnglishName)
    element.remove();
    let currentValue = document.getElementById("documentNames").value;
    let value = currentValue.replace(documentEnglishName, "");
    selectedDocuments = selectedDocuments.filter(e => e !== documentEnglishName)
    // Обновляем значение инпута
    document.getElementById("documentNames").value = value;
}

function changeCountryValue() {
    var countryInput = document.getElementById('countryName')
    var countrySelect = document.getElementById('countrySelect')
    var countryName = countrySelect.value
    countryInput.value = countryName

}