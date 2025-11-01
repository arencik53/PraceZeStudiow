document.addEventListener('DOMContentLoaded', function () {
    const tabButtons = document.querySelectorAll('.tab-button');

    tabButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Remove active class from all buttons
            document.querySelectorAll('.tab-button').forEach(btn => {
                btn.classList.remove('active');
            });

            // Remove active class from all content sections
            document.querySelectorAll('.tab-content').forEach(content => {
                content.classList.remove('active');
            });

            // Add active class to clicked button
            this.classList.add('active');

            // Get the tab ID from data attribute and show corresponding content
            const tabId = this.getAttribute('data-tab');
            const tabContent = document.getElementById(tabId);
            if (tabContent) {
                tabContent.classList.add('active');
            }
        });
    });

    // Show first tab by default
    const defaultTab = document.querySelector('.tab-button[data-tab="weather"]');
    if (defaultTab) {
        defaultTab.click();
    }
});