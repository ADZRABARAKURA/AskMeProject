export const FORM_CONFIG = {
    registration: {
        inputs: [
            {
                label: "Электронная почта",
                type: "email",
                name: "mail",
                placeholder: "Введите email",
            },
            {
                label: "Логин",
                type: "text",
                name: "login",
                placeholder: "Введите логин",
            },
            {
                label: "Пароль",
                type: "password",
                name: "password",
                placeholder: "Введите пароль",
            },
        ],
        title: "Добро пожаловать",
        subtitle: "Введите адрес электронной почты, придумайте логин и пароль",
    },

    authtorisation: {
        inputs: [
            {
                label: "Логин",
                type: "text",
                name: "login",
                placeholder: "Введите логин",
            },
            {
                label: "Пароль",
                type: "password",
                name: "password",
                placeholder: "Введите пароль",
            },
        ],
        title: "С возвращением",
        subtitle: "Введите адрес электронной почты, придумайте логин и пароль",
    },
};
