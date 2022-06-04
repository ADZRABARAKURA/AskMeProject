import React from "react";

function input(props) {
    const data = props.data;
    return (
        <div>
            <div className="left-reg__mail">
                <label htmlFor="mail">{data.label}</label>
                <input
                    type={data.type}
                    name={data.name}
                    placeholder={data.placeholder}
                />
            </div>
        </div>
    );
}

export default input;
