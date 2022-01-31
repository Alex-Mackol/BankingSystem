// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//alert"Hello");

let cardNumberId = document.getElementById('cardNumber'),
    btnsKeyboard = document.querySelectorAll('.btnKeyboard');

alert(cardNumberId);
alert(btnsKeyboard);

btnsKeyboard.forEach(function (btn) {
    // Вешаем событие клик
    btn.addEventListener('click', function (e) {
        alert('Button clicked' + e.target.classList);
    })
});
alert("");

//btnsKeyboard.addEventListener('click', event => {
//    const target = event.target;

//    cardNumber.textContent += target.item.textContent;
//});