import React from "react";
import "./Header.css";

export default function Header() {
    return (
        <div className="container">
            <span>AskMe</span>
            <div className="group">
                <input type="text" placeholder="Поиск автора" />
                <div className="avatar"></div>
                <img src="askme-app/assets/icons/arrow-down.svg" alt="" />
            </div>
        </div>
    );
}
