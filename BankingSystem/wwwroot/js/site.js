// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//alert"Hello");

var cardNumberId = document.querySelector('.form-control'),
    btnsKeyboard = document.querySelectorAll('.btnKeyboard');

const keychars = [48,49,50,51,52,53,54,55,56,57]

btnsKeyboard.forEach(function (btn) {
    btn.addEventListener('click', function (e) {
        cardNumberId.value += btn.textContent;
    })
    //btn.addEventListener('keyup', function (e) {
    //    cardNumberId.;
    //})
});

document.querySelector(".btnClear").onclick = function (e) {
    cardNumberId.value = "";
}
//document.getElementById("clearPinButton").onclick = function (e) {
//    cardNumberId.value = "";
//}
//btnsKeyboard.forEach(function (btn,i) {
//    btn.addEventListener('click', function (e) {
//        btn.setAttribute(data, keychars[i]);
//    })
//});

