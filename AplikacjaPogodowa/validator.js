document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('register-form');
    if (!form) return;

    const validationResult = document.getElementById('validation-result');

    form.addEventListener('submit', function (e) {
        e.preventDefault();

        document.querySelectorAll('.error').forEach(el => {
            el.style.display = 'none';
            el.textContent = '';
        });

        if (validationResult) {
            validationResult.style.display = 'none';
        }

        const username = document.getElementById('username').value;
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;
        const confirmPassword = document.getElementById('confirm-password').value;

        let isValid = true;

        if (username.length < 5 || username.length > 20) {
            const errorElement = document.getElementById('username-error');
            if (errorElement) {
                errorElement.textContent = 'Nazwa użytkownika musi mieć od 5 do 20 znaków';
                errorElement.style.display = 'block';
            }
            isValid = false;
        }

        const emailRegex = /^[^\s@]+@(gmail\.com|wp\.pl|onet\.pl|outlook\.com|mail\.yahoo\.com)$/;
        if (!emailRegex.test(email)) {
            const errorElement = document.getElementById('email-error');
            if (errorElement) {
                errorElement.textContent = 'Nieprawidłowy adres e-mail. Proszę użyć jednego z następujących: gmail.com, wp.pl, onet.pl, outlook.com, mail.yahoo.com';
                errorElement.style.display = 'block';
            }
            isValid = false;
        }
        

        const passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9\s]).{8,}$/;
        if (!passwordRegex.test(password)) {
            const errorElement = document.getElementById('password-error');
            if (errorElement) {
                errorElement.textContent = 'Hasło musi zawierac min. 8 znaków, 1 dużą literę, 1 cyfrę i 1 znak specjalny';
                errorElement.style.display = 'block';
            }
            isValid = false;
        }

        if (password !== confirmPassword) {
            const errorElement = document.getElementById('confirm-password-error');
            if (errorElement) {
                errorElement.textContent = 'Hasła nie są identyczne';
                errorElement.style.display = 'block';
            }
            isValid = false;
        }

        if (validationResult) {
            validationResult.style.display = 'block';
            validationResult.innerHTML = isValid
                ? '<p style="color: #4CAF50;">Formularz został poprawnie wypełniony!</p>'
                : '<p style="color: #ff6b6b;">Proszę poprawić błędy w formularzu</p>';

            if (isValid) {
                form.reset();
            }
        }
    });

    const usernameInput = document.getElementById('username');
    if (usernameInput) {
        usernameInput.addEventListener('input', function () {
            const errorElement = document.getElementById('username-error');
            if (errorElement) {
                if (this.value.length < 5 || this.value.length > 20) {
                    errorElement.textContent = 'Nazwa użytkownika musi mieć od 5 do 20 znaków';
                    errorElement.style.display = 'block';
                } else {
                    errorElement.style.display = 'none';
                }
            }
        });
    }

    const emailInput = document.getElementById('email');
    if (emailInput) {
        emailInput.addEventListener('input', function () {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            const errorElement = document.getElementById('email-error');
            if (errorElement) {
                if (!emailRegex.test(this.value)) {
                    errorElement.textContent = 'Proszę podać poprawny adres email';
                    errorElement.style.display = 'block';
                } else {
                    errorElement.style.display = 'none';
                }
            }
        });
    }

    const passwordInput = document.getElementById('password');
    if (passwordInput) {
        passwordInput.addEventListener('input', function () {
            const passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9\s]).{8,}$/;
            const errorElement = document.getElementById('password-error');
            if (errorElement) {
                if (!passwordRegex.test(this.value)) {
                    errorElement.textContent = 'Hasło musi zawierac min. 8 znaków, 1 dużą literę, 1 cyfrę i 1 znak specjalny';
                    errorElement.style.display = 'block';
                } else {
                    errorElement.style.display = 'none';
                }
            }
        });
    }

    const confirmPasswordInput = document.getElementById('confirm-password');
    if (confirmPasswordInput) {
        confirmPasswordInput.addEventListener('input', function () {
            const password = document.getElementById('password').value;
            const errorElement = document.getElementById('confirm-password-error');
            if (errorElement) {
                if (this.value !== password) {
                    errorElement.textContent = 'Hasła nie są identyczne';
                    errorElement.style.display = 'block';
                } else {
                    errorElement.style.display = 'none';
                }
            }
        });
    }
});