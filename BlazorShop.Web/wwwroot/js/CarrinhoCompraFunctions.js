function HiddenAttQntBtn(id, visible) {
    const attQtdBtn = document.querySelector("button[data-itemId='" + id + "']");

    if (visible == true) {
        attQtdBtn.style.display = "inline-block";
    } else {
        attQtdBtn.style.display = "none";
    }
}