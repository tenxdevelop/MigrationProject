
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/ChangeSystemSD.png)


Описание Диаграммы последовательности "Настроить систему":<br><br>&emsp;&emsp;
<span>Операция: GetPossibleToChangeData</span><br>&emsp;&emsp;
<span>Предусловие:  инициирует изменение некоторых данных в системе</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получен список регламентов доступных к изменению.

&emsp;&emsp;
<span>Операция: ChangeRegulation(regulation, newTerm)</span><br>&emsp;&emsp;
<span>Предусловие:  получен список регламентов и выбран необходимый для изменения</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* регламенту, необходимому для изменения, присвоено новое значение term, в случаи некоректного значения term возвращена ошибка.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/CheckRegulationSD.png)

Описание Диаграммы последовательности "Просмотреть регламент услуги":<br><br>&emsp;&emsp;
<span>Операция: GetRegulations</span><br>&emsp;&emsp;
<span>Предусловие:  авторизированный мигрант инициирует просмотр регламента услуг</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Просмотреть регламент услуги”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получен регламент услуги, на основе страны мигранта.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/CreateUserSD.png)

Описание Диаграммы последовательности "Создать пользователя":<br><br>&emsp;&emsp;
<span>Операция: CreateUserStatement(Name, surname, patronymic, email, password)</span><br>&emsp;&emsp;
<span>Предусловие:  администратор инициирует создание другого пользователя</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Создать пользователя”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* создан новый пользователь.
* пользователь добавлен в систему.
* если почта была не действительной, отправлено сообщение об ошибке.


<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/DataControleSD.png)

Описание Диаграммы последовательности "Управление данными":<br><br>&emsp;&emsp;
<span>Операция: ChangeData(EnteringDate, country, resettlementProgramMember, consistsOfMigrationRegistration, HighlyQualified)</span><br>&emsp;&emsp;
<span>Предусловие:  авторизированный мигрант инициирует изменение данных</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Управление данными”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* личные данные мигранта изменены на новые.
* если данные были некорректны, то вывелось сообщение об ошибке.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/DeleteUserSD.png)

Описание Диаграммы последовательности "Удалить пользователя":<br><br>&emsp;&emsp;
<span>Операция: GetAllUsers</span><br>&emsp;&emsp;
<span>Предусловие:  администратор инициирует удаление другого пользователя</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Удалить пользователя”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получен список всех пользователей системы.

&emsp;&emsp;
<span>Операция: TryDeleteUser(user)</span><br>&emsp;&emsp;
<span>Предусловие:  получен список всех пользователей системы и администратор выбрал пользователя на удаление</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент "Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* пользователь был успешно удален из системы.
* если пользователь не был удален, вывелось сообщение об ошибке.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/GetMigrantInfoSD.png)

Описание Диаграммы последовательности "Получить информацию по мигранту":<br><br>&emsp;&emsp;
<span>Операция: GetMigrantInfo(name, surname, patronymic, birthday, migrationCardNumber, passport)</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД инициирует запрос о мигранте</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Получить информацию по иностранному гражданину”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* информация о мигранте была получена.
* если данные по мигранту были некорректны, то вывелось сообщение об отсутствии его в системе.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/GetNotificationSD.png)

Описание Диаграммы последовательности "Получить Отрыввное уведомление о прибытии":<br><br>&emsp;&emsp;
<span>Операция: GetMyStatements</span><br>&emsp;&emsp;
<span>Предусловие: владелец жилплощади инициирует запрос на получение отрывного уведомления о прибытии</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Получить отрывное уведомление о прибытии”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получен список всех заявлений данного владельца жилплощади.

&emsp;&emsp;
<span>Операция: IsMyStatementReady(IdStatement)</span><br>&emsp;&emsp;
<span>Предусловие: владелец жилплощади выбрал нужное заявление </span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Получить отрывное уведомление о прибытии”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получена информация, как ему получить отрывное уведомление о прибытии.
* если статус заявления был "в процессе", вывелось соответствующее сообщение.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/GetStatementSD.png)

Описание Диаграммы последовательности "Получить заявку":<br><br>&emsp;&emsp;
<span>Операция: GetNewStatement</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД инициирует получение нового заявления</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Получить заявку”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* было получено новое заявление.
* если новых заявлений не было, то вывелось сообщение об их отсутствии.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/GiveRoleSD.png)

Описание Диаграммы последовательности "Выдать роль":<br><br>&emsp;&emsp;
<span>Операция: GetAllUsers</span><br>&emsp;&emsp;
<span>Предусловие: администратор инициирует выдачу роли другому пользователю</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Выдать роль”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* были получены все пользователи системы.

&emsp;&emsp;
<span>Операция: GetAllRoles</span><br>&emsp;&emsp;
<span>Предусловие: администратор получил список всех пользователей системы </span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Выдать роль”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* были получены все роли системы.

&emsp;&emsp;
<span>Операция: SetRoleToUser(user, role)</span><br>&emsp;&emsp;
<span>Предусловие: администратор выбрал нужного пользователя и роль</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Выдать роль”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* выбранному пользователю была изменена роль.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/LoginingSD.png)

Описание Диаграммы последовательности "Войти в систему":<br><br>&emsp;&emsp;
<span>Операция: Login(email, phone, password)</span><br>&emsp;&emsp;
<span>Предусловие: пользователь инициирует вход в систему</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Войти в систему”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* пользователь успешно вошел в систему под своей ролью.
* если данные при входе были ошибочные, вывелось сообщение о некоректных данных.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/PlaceRegistrationSD.png)

Описание Диаграммы последовательности "Подготовить свидетельство о регистрации":<br><br>&emsp;&emsp;
<span>Операция: CreateDocument(name, content)</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД инициирует создание свидетельства о регистрации по месту пребывания</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Подготовить свидетельство о регистрации по месту пребывания”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* создано свидетельство о регистрации по месту пребывания.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/RegistrationSD.png)

Описание Диаграммы последовательности "Регистрация":<br><br>&emsp;&emsp;
<span>Операция: Registration(email, phone, password)</span><br>&emsp;&emsp;
<span>Предусловие: Пользователь инициирует регистрацию</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Зарегистрироваться в системе”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* учетная запись пользователя была создана.
* учетная запись была добавлена в систему.
* если при регистрации почта была не действительна, то вывелось сообщение об ошибке.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/ResolveStatementSD.png)

Описание Диаграммы последовательности "Вынести решение по заявке":<br><br>&emsp;&emsp;
<span>Операция: GetAllDocuments(statement)</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД инициирует решение по заявлению</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Вынести Решение по заявке”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* получен список документов заявления.

&emsp;&emsp;
<span>Операция: SetStatusStatement(statement, status)</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД ознакомился с документами и готов вынести решение по заявлению</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Вынести Решение по заявке”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* расматреваемому заявлению был назначен новый статус.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/SendNotificationSD.png)

Описание Диаграммы последовательности "Отправить уведомление о решении":<br><br>&emsp;&emsp;
<span>Операция: CreateNotification(statementNumber, name, surname, patronymic)</span><br>&emsp;&emsp;
<span>Предусловие: специалист МВД инициирует создание уведомления</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Отправить уведомление о решении”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* создано уведомление о решении заявления.
* уведомлению назначен способ получения.
* если способ получения был выбран "Электронный документооборот", то система аввтоматически присвоела документ ввладельцу жилплощади.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/SendStatementSD.png)

Описание Диаграммы последовательности "Подать заявление":<br><br>&emsp;&emsp;
<span>Операция: CreateStatement(name, surname, patronymic, previousAddress, accountingAddress)</span><br>&emsp;&emsp;
<span>Предусловие: владелец жилплощади инициирует процесс подачи заявления</span><br>&emsp;&emsp;
<span>Ссылка:  прецедент “Подать заявление”</span><br>&emsp;&emsp;
<span>Постусловие:</span>

* создано заявление о постановки мигранта на учет.
* если данные были некорректны, то вывелось сообщение об ошибке в данных.