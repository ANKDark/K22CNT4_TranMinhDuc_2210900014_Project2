document.addEventListener("DOMContentLoaded", function () {
    ClassicEditor
        .create(document.querySelector('#Mota'))
        .catch(error => {
            console.error(error);
        });
});
document.addEventListener("DOMContentLoaded", function () {
    ClassicEditor
        .create(document.querySelector('#Mota1'))
        .catch(error => {
            console.error(error);
        });
});
document.addEventListener("DOMContentLoaded", function () {
    ClassicEditor
        .create(document.querySelector('#Mota2'))
        .catch(error => {
            console.error(error);
        });
});
function updateFileName(input, editorId, previewImgId) {
    const fileInput = document.getElementById(editorId);
    const imgPreview = document.getElementById(previewImgId);
    const file = input.files[0];

    if (file) {
        fileInput.value = file.name;

        const reader = new FileReader();
        reader.onload = function (e) {
            imgPreview.src = e.target.result;
            imgPreview.style.display = 'block';
        };
        reader.readAsDataURL(file);
    } else {
        fileInput.value = '';
        imgPreview.src = '';
        imgPreview.style.display = 'none';
    }
}

function previewImage(event, previewId) {
    var input = event.target;
    var preview = document.getElementById(previewId);

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            preview.src = e.target.result;
            preview.style.display = 'block';
        }

        reader.readAsDataURL(input.files[0]);
    }
}

