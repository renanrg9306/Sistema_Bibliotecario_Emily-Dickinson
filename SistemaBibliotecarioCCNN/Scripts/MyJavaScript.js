/* evento cuando toma el foco */
function textFocus(oText) {
    if (oText.value == defText) {
        oText.value = '';
    }
}

/* evento cuando pierde el foco */
function textBlur(oText) {
    if (oText.value == '') {
        oText.value = defText;
    }
}