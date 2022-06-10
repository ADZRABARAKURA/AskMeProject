import React from "react";
import { Link } from "react-router-dom";
import "./Header.css";

export default function Header() {
    const registred = localStorage.getItem("login");
    return (
        <header>
            {registred === null ? (
                <>
                    <img src="img/search.svg" alt="" className="header__icon" />
                    <input
                        type="text"
                        className="header__input"
                        placeholder="Поиск автора"
                    />
                    <Link to="/profile">
                        <div className="header__signin">Войти</div>
                    </Link>
                    <Link to="/auth">
                        <div className="header__signup">Зарегистрироваться</div>
                    </Link>
                </>
            ) : (
                <>
                    <img src="img/search.svg" alt="" className="header__icon" />
                    <input
                        type="text"
                        className="header__input"
                        placeholder="Поиск автора"
                    />
                </>
            )}
        </header>
    );
}
