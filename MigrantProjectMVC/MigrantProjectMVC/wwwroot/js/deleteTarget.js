
targetsForDeletion = []

async function loadTargetForDeletion() {
    try {
        const response = await fetch('/Target/GetTargets');
        if (!response.ok) {
            throw new Error('Ошибка при загрузке: ' + response.status);
        }
        targetsForDeletion = await response.json();
        fillTargetsForRemove()
    } catch (error) {
        console.error('Ошибка:', error);
    }
}


function fillTargetsForRemove() {
    var select = document.getElementById("selectForTargetDeletion")
    targetsForDeletion.forEach((target, index) => {
        const option = document.createElement('option');
        option.value = index;
        option.textContent = target.name;
        select.appendChild(option)
    });
}

function DeleteTargetChange() {
    var targetNameInput = document.getElementById("removeTargetInput")

    var targetName = targetsForDeletion[event.target.value].name

    targetNameInput.value = targetName

}