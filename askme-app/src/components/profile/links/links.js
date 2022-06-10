import React from "react";

import "./links.css";

import twitch from "../../../assets/icons/twitch.svg";
import youtube from "../../../assets/icons/youtube.svg";

const data = [
    {
        type: twitch,
        link: "http://www.donware.com",
    },
    {
        type: youtube,
        link: "http://www.zoomit.com",
    },
];

export default function links() {
    return (
        <div>
            <span className="title">Ссылки</span>
            {data.map((elment) => (
                <div className="links-container">
                    <img className="icon" src={elment.type} alt=""/>
                    <a href={elment.link} className="link">{elment.link}</a>
                </div>
            ))}
            {/* <div className="top-rightP__link twitter">
                http://www.donware.com
            </div>
            <div className="top-rightP__link youtube">
                http://www.zoomit.com
            </div> */}
        </div>
    );
}
