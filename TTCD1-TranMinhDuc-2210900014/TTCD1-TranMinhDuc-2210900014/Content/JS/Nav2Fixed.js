document.addEventListener('DOMContentLoaded', function () {
    const nav2 = document.querySelector('.nav2');
    const nav2Offset = nav2.offsetTop;

    window.addEventListener('scroll', function () {
        if (window.pageYOffset > nav2Offset) {
            nav2.classList.add('fixed');
        } else {
            nav2.classList.remove('fixed');
        }
    });
});

document.getElementById('showMoreButton').addEventListener('click', function () {
    const hiddenLinks = document.querySelectorAll('.nav-link.custom-link.d-none');
    hiddenLinks.forEach(link => {
        link.classList.remove('d-none');
    });
    this.style.display = 'none';
});

