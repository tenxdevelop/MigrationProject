
<br><br><br>
<h1 align="center">Диаграмма прецедентов программы “MigrationSystem”</h1>
<br><br><br>

![](https://github.com/tenxdevelop/MigrationProject/blob/main/useCaseDiagram.png)

<br>Мигрант – иностранный гражданин, который хочет встать на учёт
<br>Владелец жилплощади – Собственник жилья или доли в нём, где оформляется учёт
<br>Админ – Высокоранговый пользователь системы с привилегиями
<br>Специалист МВД - Высококлаифицированный работник в МВД, который способен обрабатывать заявления о постановке на миграционный учет

<br>
Сценарий использования “Зарегистрироваться в системе”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует регистрацию</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует данные о пользователе:
<br>1)	Указывает мобильный телефон / электронную почту
<br>2)	Указывает пароль
</td>
</tr>
<tr>
<th>Пользователь вводит данные и подтверждает</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных:
<br>1.	Почта и телефон должны быть действующими
<br>2.  Пароль удовлетворяет условиям 
</th>
</tr>
<tr>
<th></th>
<th>Система уведомляет пользователя о результате регистрации</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования "Управление данными"
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует изменение данных</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует новые данные о пользователе:
<br>1)	Дата въезда в Россию.
<br>2)	Гражданином какой страны вы являетесь.
<br>3)	Являетесь ли вы или член вашей семьи высококвалифицированным специалистом своей области.
<br>4)	Входите ли вы в государственную программу переселения.
<br>5)	Состояли ли вы или член вашей семьи ранее на миграционном учёте.
</td>
</tr>
<tr>
<th>Пользователь вводит данные и подтверждает</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных:
<br>1.	Дата не может быть позднее сегодняшнего дня.
<br>2.	Гражданство должно быть существующим.
</th>
</tr>
<tr>
<th></th>
<th>Система уведомляет пользователя о результате изменения данных</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Просмотреть регламент услуги”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует просмотр регламента услуг</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система уведомляет пользователя о необходимости обратиться к лицу, у которого проживаете.</td>
</tr>
<tr>
<th></th>
<th>Система выводит результат на основе данных о пользователе:
<br>1)	Если пользователь гражданин Киргизии, Казахстана, Армении или высококвалифицированный специалист (если ранее состоял на миграционном учете в РФ) прибавляет 30 дней к дате въезда.
<br>2)	Если пользователь гражданин Таджикистана или Узбекистана прибавляет 15 дней к дате въезда.
<br>3)	Если пользователь гражданин другой страны прибавляет 7 дней к дате въезда.
<br>4)	Если пользователь участник государственной программы переселения соотечественников прибавляет 30 дней к дате въезда.
<br>5)	Если пользователь гражданин Белоруссии, Украины или является высококвалифицированным специалистом прибавляет 90 дней к дате въезда.
</th>
</tr>
<tr>
<th>Пользователь ознакомляются с рекомендацией системы </th>
<th></th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Подать заявление”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует процесс подачи заявления</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует данные:
<br>1.	Паспорт собственника жилья или доли в нём либо зарегистрированного по месту жительства в этом помещении гражданина РФ
<br>2.	Паспорт или аналог паспорта иностранца — все заполненные страницы
<br>3.	Адрес, по которому нужно встать на учёт
<br>4.	Документ, подтверждающий право пребывания иностранца в России, — виза, разрешение на временное проживание или вид на жительство. Гражданам некоторых зарубежных стран виза не нужна
<br>5.	Миграционная карта. Гражданам некоторых зарубежных стран она не нужна
<br>6.	Прежний адрес пребывания в России — при наличии
<br>7.	Паспорт или аналог паспорта законного представителя — родителя, усыновителя, опекуна или попечителя — при постановке на учёт ребёнка или недееспособного
<br>8.	Документ о собственности на жильё или его долю, где оформляется учёт, — при личной подаче в МВД или МФЦ собственником, который не зарегистрирован в этом жилье
<br>9.	Трудовой договор — если на учёт ставится трудящийся в России иностранец или члены его семьи. Для работника с трудовым патентом можно прикрепить в один файл с договором квитанцию об оплате госпошлины за патент
<br>10.	Документ, подтверждающий родственные связи, например свидетельство о браке, — если ставятся на учёт члены семьи трудящегося иностранца
</td>
</tr>
<tr>
<th>Пользователь заполняет данные и  отправляет заявление</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных
<br>1.	Если есть ошибки просит исправить их
<br>2.	Если ошибки отсутствуют уведомляет об успешной отправке заявления
</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Получить отрывное уведомление о прибытии”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует запрос на получение отрывного уведомления о прибытии</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система получает информацию, что уведомление о прибытии данного пользователя готово и отправляет</td>
</tr>
<tr>
<th></th>
<th>Система отправляет пользователю информацию как ему получить отрывное уведомление о прибытии</th>
</tr>
<tr>
<th>Пользователь получает информацию как получить отрывное уведомление</th>
<th></th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Войти в систему”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует вход в систему</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует данные:
<br>1.	Электронная почта или номер телефона
<br>2.	Пароль
</td>
</tr>
<tr>
<th>Пользователь вводит данные и подтверждает </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных:
<br>1.	Если есть ошибки просит исправить их
<br>2.	Если ошибок нет, то осуществляет вход в личный аккаунт
</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Удалить пользователя”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует удаление другого пользователя</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система выдаёт список возможных для удаления пользователей</td>
</tr>
<tr>
<th>Пользователь выбирает необходимого на удаление пользователя </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет возможность удаления:
<br>1.	Если возможность есть, то производит удаление
<br>2.	Если возможности нет, то уведомляет пользователя об этом</th>
</tr>
</tbody>
</table>


<br>
Сценарий использования “Создать пользователя”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует создание другого пользователя</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система просит данные для создания пользователя
<br>1.	ФИО
<br>2.	Электронную почту / Телефон
<br>3.	Пароль
</td>
</tr>
<tr>
<th>Пользователь указывает данные и подтверждает отправку</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность введенных данных:
<br>1.	Если ошибок нет, создаёт пользователя
<br>2.	Если ошибки есть, уведомляет о них пользователя и просит исправить
</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Выдать роль”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует выдачу роли другому пользователю</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система выдаёт список возможных выдачи ролей пользователей</td>
</tr>
<tr>
<th>Пользователь выбирает необходимого пользователя </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система выводит варианты ролей:
<br>1.	Админ
<br>2.	Сотрудник МВД
</th>
</tr> 
<tr>
<th>Пользователь выбирает необходимую роль и подтверждает</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система присваивает соответствующую роль соответствующему пользователю</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Настраивать систему”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует изменение некоторых данных в системе</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система выдаёт возможные для изменения данные
</td>
</tr>
<tr>
<th>Пользователь выбирает необходимые и меняет их </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет возможность изменения:
<br>1.	Если возможность есть, то производит изменение 
<br>2.	Если возможности нет, то уведомляет пользователя об этом
</th>
</tr> 
</tbody>
</table>

<br>
Сценарий использования “Отправить уведомление о решении”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует создание уведомления.</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система запрашивает данные:
<br>1)	номер заявления
<br>2)	ФИО заявителя 
<br>3)	результат проверки
</td>
</tr>
<tr>
<th>Пользователь вводит данные </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных, предотвращающие ошибочное введение данных.
</th>
</tr> 
<tr>
<th></th>
<th>Система предлагает способ уведомления:
<br>1)	Через электронную почту (если заявитель указал адрес).
<br>2)	В виде смс-уведомления (если указаны телефонные номера).
<br>3)	Лично, если заявитель пришел в отделение.
<br>4)	Электронный документооборот
</th>
</tr>
<tr>
<th>Пользователь выбирает способ отправки уведомления</th>
<th></th>
</tr> 
<tr>
<th></th>
<th>Система фиксирует все совершённые действия
</th>
</tr> 
</tbody>
</table>

<br>
Сценарий использования “Получить информацию по иностранному гражданину”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует запрос о гражданине</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует данные:
<br>1)	ФИО
<br>2)	Дата рождения
<br>3)	Паспортные данные
<br>4)	номер миграционной карты
</td>
</tr>
<tr>
<th>Пользователь вводит данные </th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система выводит результат о гражданине</th>
</tr>
</tbody>
</table>

<br>
Сценарий использования “Вынести Решение по заявке”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь ознакамливается с данными</td>
<td></td>
</tr>
<tr>
<td>Пользователь инициирует решение по заявлению</td>
<td></td>
</tr>
<tr>
<th></th>
<th>Система требует вынести решение по заявлению</th>
</tr>
<tr>
<th>Пользовать ознакамливается с результатами системы и после формальной проверки делает вердикт:
<br>1)	принять заявление на постановку миграционного учета.
<br>2)	Отклонить заявление на постановку миграционного учета.  
</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система подтверждает результат о решении по заявлению
</th>
</tr> 
</tbody>
</table>


<br>
Сценарий использования “Получить Заявку”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует получение нового заявления</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система выдает новое заявление из списка возможных
<br>1.	Если в системе список заявлений пуст, то система уведомляет пользователя об этом
</td>
</tr>
<tr>
<th>Пользователь получает результат системы</th>
<th></th>
</tr>
</tbody>
</table>

Сценарий использования “Подготовить свидетельство о регистрации по месту пребывания”
<table>
<thead>
<tr>
<th>Actor</th>
<th>System</th>
</tr>
</thead>
<tbody>
<tr>
<td>Пользователь инициирует создание свидетельства о регистрации по месту пребывания</td>
<td></td>
</tr>
<tr>
<td></td>
<td>Система требует данные:
<br>1)	ФИО
<br>2)	Дата
<br>3)	Паспорт собственника жилья или доли в нём либо зарегистрированного по месту жительства в этом помещении гражданина РФ
<br>4)	Паспорт или аналог паспорта иностранца — все заполненные страницы
<br>5)	Адрес, по которому нужно встать на учёт
<br>6)	Документ, подтверждающий право пребывания иностранца в России, — виза, разрешение на временное проживание или вид на жительство. Гражданам некоторых зарубежных стран виза не нужна
<br>7)	Миграционная карта. Гражданам некоторых зарубежных стран она не нужна
<br>8)	Прежний адрес пребывания в России — при наличии
<br>9)	Паспорт или аналог паспорта законного представителя — родителя, усыновителя, опекуна или попечителя — при постановке на учёт ребёнка или недееспособного
<br>10)	Документ о собственности на жильё или его долю, где оформляется учёт, — при личной подаче в МВД или МФЦ собственником, который не зарегистрирован в этом жилье
<br>11)	Трудовой договор — если на учёт ставится трудящийся в России иностранец или члены его семьи. Для работника с трудовым патентом можно прикрепить в один файл с договором квитанцию об оплате госпошлины за патент
Документ, подтверждающий родственные связи, например свидетельство о браке, — если ставятся на учёт члены семьи трудящегося иностранца
</td>
</tr>
<tr>
<th>Пользователь вводит данные</th>
<th></th>
</tr>
<tr>
<th></th>
<th>Система проверяет корректность данных</th>
</tr>
<tr>
<th></th>
<th>Система создает свидетельство о регистрации по месту пребывания и выдает пользователю</th>
</tr>
<tr>
<th>Пользователь получает свидетельство о регистрации по месту пребывания</th>
<th></th>
</tr>
</tbody>
</table>