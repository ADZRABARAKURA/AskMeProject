import React, { Component } from 'react'
import './Auth.css'

export default class Test extends Component {
  render() {
    return (
          <div className="wrapper">
            <div className="main">
              <img className="main__angel" src="angel.png" alt="" />
              <div className="reg">
                <div className="reg__left left-reg">
                  <div className="left-reg__choose">
                    <div className="left-reg__registation">Регистрация</div>
                    <div className="left-reg__auth">Авторизация</div>
                  </div>
                  <div className="left-reg__welcome">Добро пожаловать</div>
                  <div className="left-reg__text">Введите адрес электронной почты, придумайте логин и пароль</div>
                  <form action="#" className="left-reg__form">
                    <div className="left-reg__mail active-input">
                      <label htmlFor="mail">Электронная почта</label>
                      <input type="email" name="mail" defaultValue="michelle.rivera@example.com" />
                    </div>
                    <div className="left-reg__login">
                      <label htmlFor="login">Логин</label>
                      <input type="text" name="login" defaultValue="michelle" />
                    </div>
                    <div className="left-reg__password">
                      <label htmlFor="password">Пароль</label>
                      <input type="password" name="password" defaultValue="example.com" />
                    </div>
                    <div className="left-reg__submit">
                      <button type="submit">Далее</button>
                    </div>
                  </form>
                </div>
                <div className="reg__right">
                  <img src="woman.jpg" alt />
                </div>
              </div>
            </div>
          </div>

    )
  }
}
