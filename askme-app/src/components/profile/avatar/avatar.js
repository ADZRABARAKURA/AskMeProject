import React from "react";

import "./avatar.css";

import avatar_img from "../../../assets/images/avatar.jpg";

const data = {
    avatar_img: avatar_img,
    nickname: "Pro100User",
    job: "Разработчик",
    subscribes: "19",
};
export default function avatar() {
    return (
        <>
            <div className="leftP__img">
                <img src={data.avatar_img} alt="avatar" />
            </div>
            <div className="avatar-container">
                <div className="nickname">{data.nickname}</div>
                <div className="job">{data.job}</div>
                <div className="body-leftP__subscibers">
                    {data.subscribes} подписчиков
                </div>
                <div className="subscribe-button">Подписаться</div>
            </div>
        </>
    );
}
