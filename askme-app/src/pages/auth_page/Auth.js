import React from "react";
import { Link } from "react-router-dom";
import Input_form from "../../components/form/input/input";
import { FORM_CONFIG } from "../../components/form/form.config";
import woman from "../../assets/images/woman.jpg"
import angel from "../../assets/images/angel.png";
import "./Auth.css";

export default class Test extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            formSelected: "registration",
            isLoginExist: true
        };
    }

    authChange = (e) => {
        this.setState((state) => ({
            formSelected: "authtorisation",
        }));
        e.target.previousSibling.classList.remove("active-btn");
        e.target.classList.add("active-btn");
    };

    regChange = (e) => {
        this.setState((state) => ({
            formSelected: "registration",
        }));
        e.target.nextSibling.classList.remove("active-btn");
        e.target.classList.add("active-btn");
    };



    formRender = (inputs) => {
        let content = [];
        for (let input of inputs) {
            content.push(<Input_form data={input} />);
        }
        return content;
    };

    hadleNext() {
        const login = document.querySelector('#login').value;
        const password = document.querySelector('#password').value;

        
        if (localStorage.getItem('login') !== login) {
            localStorage.setItem('login', login);
            localStorage.setItem('password', password);
            this.setState(prev => {
                
                return {
                    formSelected: prev.formSelected,
                    isLoginExist: false
                }
            });
        } else {
            this.setState(prev => {
                console.log(prev);
                return {
                    formSelected: prev.formSelected,
                    isLoginExist: true
                }
            });
        }
    }

    render() {
        return (
            <div className="wrapper">
                <div className="main">
                    <img className="main__angel" src={angel} alt="angel" />
                    <div className="reg">
                        <div className="reg__left left-reg">
                            <div className="left-reg__choose">
                                <div
                                    className="left-reg__registation active-btn"
                                    onClick={this.regChange}
                                >
                                    Регистрация
                                </div>
                                <div
                                    className="left-reg__auth"
                                    onClick={this.authChange}
                                >
                                    Авторизация
                                </div>
                            </div>

                            <div className="left-reg__welcome">
                                {FORM_CONFIG[this.state.formSelected].title}
                            </div>
                            <div className="left-reg__text">
                                {FORM_CONFIG[this.state.formSelected].subtitle}
                            </div>
                            <form action="#" className="left-reg__form">
                                {this.formRender(
                                    FORM_CONFIG[this.state.formSelected].inputs
                                )}
                                <Link to='/profile'>
                                    <div className="left-reg__submit">
                                        <button onClick={() => {
                                            
                                            this.hadleNext()
                                        }} type="submit">Далее</button>
                                    </div>
                                </Link>
                            </form>
                        </div>
                        <div className="reg__right">
                            <img src={woman} alt="woman" />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
