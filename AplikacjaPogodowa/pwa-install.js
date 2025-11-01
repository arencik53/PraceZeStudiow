document.addEventListener('DOMContentLoaded', function () {
    let deferredPrompt;
    const installButton = document.getElementById('install-button');

    if (!installButton) return;

    window.addEventListener('beforeinstallprompt', (e) => {
        e.preventDefault();
        deferredPrompt = e;
        installButton.style.display = 'block';

        installButton.addEventListener('click', () => {
            if (deferredPrompt) {
                deferredPrompt.prompt();
                deferredPrompt.userChoice.then((choiceResult) => {
                    if (choiceResult.outcome === 'accepted') {
                        console.log('User accepted install');
                    } else {
                        console.log('User declined install');
                    }
                    deferredPrompt = null;
                    installButton.style.display = 'none';
                });
            }
        });
    });

    window.addEventListener('appinstalled', () => {
        console.log('PWA installed');
        if (installButton) {
            installButton.style.display = 'none';
        }
    });
});