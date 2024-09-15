var myCode = document.getElementById("myCode");
function CopyCode() {
    var textToCopy = myCode.innerText;
    var btnCopy = document.getElementById('copyBtn');
    var textarea = document.createElement("textarea");
    textarea.value = textToCopy;
    document.body.appendChild(textarea);
    textarea.select();
    document.execCommand("copy");
    document.body.removeChild(textarea);
    setTimeout(function () {
        btnCopy.innerHTML = '<i class="bi bi-check-lg"></i>'
    }, 10)
    setTimeout(function () {
        btnCopy.innerHTML = '<i class="bi bi-clipboard"></i>'
    }, 2000)
}