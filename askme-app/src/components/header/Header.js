import React from "react";
// import "./Header.css";

export default function Header() {
    return (
        <header className="header">
            <img src="img/search.svg" alt="" className="header__icon" />
            <input type="text" className="header__input" placeholder="Поиск автора" />
            <a href="#">
                <div className="header__signin">Войти</div>
            </a>
            <a href="#">
                <div className="header__signup">Зарегистрироваться</div>
            </a>
        </header>

    );
}
