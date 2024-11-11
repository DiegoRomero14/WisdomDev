document.querySelectorAll('.inner-box').forEach(box => {
    box.addEventListener('mouseenter', () => {
        const popup = box.querySelector('.popup-text');
        popup.style.display = 'block';
    });
    
    box.addEventListener('mouseleave', () => {
        const popup = box.querySelector('.popup-text');
        popup.style.display = 'none';
    });
});