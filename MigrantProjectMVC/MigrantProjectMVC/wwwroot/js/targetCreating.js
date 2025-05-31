

target = null
function createTarget() {
 

    if (target == null) {
        alert("Не создано условий для услуги")
        return
    }


}

function toCreateRegulationPage() {
    var targetInput = document.getElementById("targetInput")
    var instructionInput = document.getElementById("instructionInput")
    var regulations = ""

    var targetName = targetInput.value
    var instructionText = instructionInput.value


    if (targetName === null || instructionText === null) {
        return 
    }
    var targetString = sessionStorage.getItem("target");
    var target = JSON.parse(targetString)
    if (targetString === undefined || targetString === null) {
        var target = {
            name: targetName,
            instruction: instructionText,
            regulations: null
        }
        sessionStorage.setItem("target", JSON.stringify(target))
    }
   
}

function getTarget() {
    var targetString = sessionStorage.getItem("target");
    if (targetString) {
        var target = JSON.parse(targetString);
        console.log(target);
        console.log(target.name);
    } else {
        console.log("Объект target не найден в sessionStorage");
    }
}

function CheckTargetInStorage() {
    var targetString = sessionStorage.getItem("target");
    var target = JSON.parse(targetString)
    if (targetString === undefined || targetString === null) {
        return
    }
    else {
        var targetInput = document.getElementById("targetInput")
        var instructionInput = document.getElementById("instructionInput")

        targetInput.value = target.name
        instructionInput.value = target.instruction
    }
}
