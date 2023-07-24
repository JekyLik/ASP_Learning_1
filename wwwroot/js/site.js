
function onEditClick(i) {
    ChangeState(`viewState_${i}`, `editState_${i}`);
    
    ChangeValue(document.getElementById(`title_text_${i}`));        
    ChangeValue(document.getElementById(`description_text_${i}`));
    ChangeValue(document.getElementById(`price_num_${i}`));
    ChangeValue(document.getElementById(`quantity_num_${i}`));
}

function ChangeValue(element) {                                  
    let newElement = document.createElement("input");
    newElement.value = element.innerText;
    newElement.dataset.oldValue = element.innerText;
    element.innerHTML = "";
    element.appendChild(newElement);
}

function ChangeState(classToHide, classToShow) {
    let blockToHide = document.getElementById(classToHide);
    let blockToShow = document.getElementById(classToShow);

    blockToShow.classList.remove("d-none");
    blockToHide.classList.add("d-none");
}

function onDeleteClick(i) {
    const row = document.getElementById(`row_${i}`);
    row.remove();
}

function onApproveClick(i) {
    ChangeState(`editState_${i}`, `viewState_${i}`);

    SaveValue(document.getElementById(`title_text_${i}`));
    SaveValue(document.getElementById(`description_text_${i}`));
    SaveValue(document.getElementById(`price_num_${i}`));
    SaveValue(document.getElementById(`quantity_num_${i}`));
}

function SaveValue(element){
    let inputs = element.getElementsByTagName("input");
    element.innerHTML = inputs[0].value;
}

function onDeclineClick(i) {
    ChangeState(`editState_${i}`, `viewState_${i}`);

    ReturnValue(document.getElementById(`title_text_${i}`));
    ReturnValue(document.getElementById(`description_text_${i}`));
    ReturnValue(document.getElementById(`price_num_${i}`));
    ReturnValue(document.getElementById(`quantity_num_${i}`));
}

function ReturnValue(element){
    let inputs = element.getElementsByTagName("input");
    element.innerHTML = inputs[0].dataset.oldValue;
}
