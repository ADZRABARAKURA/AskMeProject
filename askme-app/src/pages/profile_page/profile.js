import React, { Component } from "react";
import "./profile.css";

import Links from "../../components/profile/links/links";
import About from "../../components/profile/about/about";
import Avatar from "../../components/profile/avatar/avatar";
import Posts from "../../components/profile/posts/posts";

import main from "../../assets/images/main.jpg";
import photo from "../../assets/images/photo.jpg";

export default class Profile extends Component {
    render() {
        return (
            <div>
                <img src={main} alt={main} />
                <div className="main">
                    <div className="main__container">
                        <About />
                        <div className="sort">
                            <div className="sort__text">Сортировать</div>
                            <div className="sort__arrow">
                                <img src="img/dropdown.svg" alt="arrow" />
                            </div>
                        </div>
                        <Posts />
                        <aside className="leftP">
                            <Avatar />
                        </aside>
                        <aside className="rightP">
                            <div className="rightP__top top-rightP">
                                <Links />
                            </div>
                            <div className="leftP__top goal">
                                <div className="goal__text">Цель</div>
                                <div className="goal__progress">
                                    30 из 100 рублей
                                </div>
                                <div className="goal__main">
                                    Ни штриха не мог бы я сделать, а никогда не
                                    был таким большим художником, как в эти
                                    минуты.
                                </div>
                            </div>
                        </aside>
                    </div>
                </div>
            </div>
        );
    }
}
