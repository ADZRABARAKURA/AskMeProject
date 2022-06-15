import React from "react";
import "./posts.css";

import lock from "../../../assets/icons/lock.svg";
import { posts_mock } from "./posts-mock";

export default function posts() {
    console.log(posts_mock);
    return (
        <>
            {posts_mock.map((post) => (
                <div className="post">
                    <div className="post-title">
                        {post.title}
                        <div className="post__date">{post.Date}</div>
                    </div>
                    {post.secret ? (
                        <>
                            <div className="post__text2">
                                <span>Пост только для подписчиков</span>
                                <img src={lock} alt="" />
                            </div>
                            <img
                                src={post.img}
                                alt=""
                                className="img blurred"
                            />
                        </>
                    ) : (
                        <img src={post.img} alt="" className="img" />
                    )}
                </div>
            ))}
        </>
    );
}
