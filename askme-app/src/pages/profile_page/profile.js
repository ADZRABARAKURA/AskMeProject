import React, { Component } from 'react';
import './profile.css';

export default class Profile extends Component {
  render() {
    return (
      <div>
        <img src="img/main.jpg" alt />
        <div className="main">
          <div className="main__container">
            <div className="about">
              <div className="about__title">Об авторе</div>
              <div className="about__text">Душа моя озарена неземной радостью, как эти чудесные весенние утра, которыми я наслаждаюсь от всего сердца. Я совсем один и блаженствую в здешнем краю, словно созданном для таких, как я. Я так счастлив, мой друг, так упоен ощущением покоя, что искусство мое страдает от этого. Ни одного штриха не мог бы я сделать, а никогда не был таким большим художником, как в эти минуты.</div>
            </div>
            <div className="sort">
              <div className="sort__text">Сортировать</div>
              <div className="sort__arrow">
                <img src="img/dropdown.svg" alt="arrow" />
              </div>
            </div>
            <div className="post">
              <div className="post__title">
                <div className="post__text">Helping a local business reinvent itself</div>
                <div className="post__date">29 января 2021, пт</div>
              </div>
              <div className="post__img blurred">
                <img src="img/photo.jpg" alt="photo" />
                <div className="post__text2">
                  <span>Пост только для подписчиков</span>
                  <img src="img/lock.svg" alt />
                </div>
              </div>
            </div>
            <aside className="leftP">
              <div className="leftP__img">
                <img src="img/avatar.jpg" alt="avatar" />
              </div>
              <div className="leftP__body body-leftP">
                <div className="body-leftP__nick">Имя/никнейм</div>
                <div className="body-leftP__job">Род занятий</div>
                <div className="body-leftP__subscibers">0 подписчиков</div>
                <div className="body-leftP__money">0,00 руб/мес</div>
                <div className="body-leftP__subscribe">Подписаться</div>
              </div>
            </aside>
            <aside className="rightP">
              <div className="rightP__top top-rightP">
                <div className="top-rightP__links">
                  <div className="top-rightP__text">Ссылки</div>
                  <div className="top-rightP__link twitter">http://www.donware.com</div>
                  <div className="top-rightP__link youtube">http://www.zoomit.com</div>
                </div>
              </div>
              <div className="leftP__top goal">
                <div className="goal__text">Цель</div>
                <div className="goal__progress">30 из 100 рублей</div>
                <div className="goal__main">Ни штриха не мог бы я сделать, а никогда не был таким большим художником, как в эти минуты.</div>
              </div>
            </aside>
          </div>
        </div>
      </div>

    )
  }
}
