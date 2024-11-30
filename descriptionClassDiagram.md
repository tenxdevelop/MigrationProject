
![](https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagram.png)


ссылка на StarUml диаграмму - https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagram.mdj

<h1>Описание</h1>
<h2>Используется шаблон CQRS<h2>
<ul>
    <li>Models - сущности (Domain уровень)</li>
    <li>Controllers - произодит маршрутизацию по запросам пользователя(Presentation уровень)</li>
    <!--
    <li>Query - Описывает сигнатуру и тип запроса(Application уровень)</li>
    -->
    <li>QueryHandlers - исполнители запросов к данным(Application уровень)</li>
    <!--
    <li>Command - описывает тип и сигнатуру команды(Application уровень)</li>
    -->
    <li>CommandHandler - исполнители команд(Application уровень)</li>
    <li>Repository - слой доступа к данным (Domain и Persistance уровень)</li>
</ul>
<hr />
<h2>Models</h2>
<ul>
    <li>UserModel - Модель пользователя, без роли, все другие типы пользователя являются её наследниками</li>
    <li>RoleModel - Роль которая указывается у пользователя</li>
    <li>MigrantModel - Модель мигранта</li>
    <li>RegulationModel - Модель регламента услуги</li>
    <li>StatementModel - Модель заявления</li>
    <li>DocumentModel - Модель для документов</li>
    <li>PlaceOwnerModel - Модель владельца жилплощади</li>
    <li>NotificationModel - Модель отрывного уведомления</li>
    <li>DocumentTypeModel - Модель типа документа</li>
</ul>
<hr />
<h2>Interfaces</h2>
<ul>
    <li>INotificationRepository - интерфейс репозиторий с данными отрывных уведомлений</li>
    <li>IRoleRepository - интерфейс репозитория с данными ролей </li>
    <!---
    <li>ICommand - интерфейс от которого наследуются все остальные комманды</li>
    <li>ICommandHandler - интефейс от которого наследуются все исполнители комманд</li>
    -->
    <li>ICommandProcessor - позволяет на основе ICommand определяет какой именно commandHandler вызвать</li>
    <!---
    <li>IQuery - интерфейс от которого наследуются все остальные запросы(queries)</li>
    <li>IQueryHandler - интерфейс от которого наследуются все исполнители запросов</li>
    -->
    <li>IQueryProcessor - позволяет на основе IQuery определяет какой именно queryHandler вызвать</li>
    <li>IUserRepository - репозиторй с данными пользователей</li>
    <li>IPasswordHasher - интерфейс который абстрагируется от конкретного PasswordHasher</li>
    <li>ITokenProvider - интерфейс который абстрагируется от конкретного TokenProvider</li>
    <li>IRegulationRepository - интерфейс репозитория с данными регламентов услуг</li>
    <li>IMigrantRepository - репозиторий с данными мигрантов</li>
    <li>IStatementRepository - иинтерфейс описывающий логику обработки и получения данных из бд </li>
</ul>
<hr />
<h2>Controllers</h2>
<ul>
    <li>ControllerBase - самый основной класс, является родителем для всех контроллеров в системе, базовый класс самого asp.net</li>
    <li>BaseController - единственный наследний baseController, является родителем для всех остальных контроллеров</li>
    <li>UserController - производит маршрутизацию для комманд и запросов связанных с пользователями</li>
    <li>RegulationController - производит машрутизацию для запросов и комманд связанных с регламентом услуги</li>
    <li>MigrantController - производит маршрутизацию для запросов и комманд связанных с мигрантами</li>
    <li>StatementController - реализует маршрутизацию для запросов и комманд связанных с заявлениями</li>
    <li>NotificationController - производит маршрутизацию для запросов и комманд связанных с отрывным уведомлением</li>
    <li>RoleController - производит машрутизацию для запросов и комманд связанных с получением ролей</li>
    <li>DocumentController - производит маршрутизацию для запросов и комманд связанных с документами</li>
</ul>
<hr />
<!---
<h2>Query</h2>
<ul>
    <li>QueryProcessor - основной класс для реализации других query(запросов)</li>
    <li>GetRegulationListQuery - запрос на получение списка регламентов услуг</li>
    <li>GetRegulationQuery - запрос на получение опрелененого регламента услуг</li> 
    <li>GetUserListQuery - запрос на получение списка пользователей, независимо от роли</li>
    <li>GetMigrantQuery - запрос на получение определенного мигранта</li>
    <li>GetStatementListQuery - запрос на получение списка заявок</li>
    <li>GetStatusStatusQuery запрос на получение статуса заявление</li>
    <li>GetNotificationQuery - запрос получение способа вручения отрывного уведомления </li>
    <li>GetNewStatementQuery - запрос на получение нового заявления</li>
    <li>GetRolesListQuery - запрос на получение списка всех ролей</li>
    <li>GetDocumentListQuery -  запрос на получения списка документов</li>
    <li>GetNotififcationTypeListQuery - запрос на получение всех типов получения отрывного уведомления</li>
    <li>GetUserQuery - запрос на получение определённого user-a</li>
</ul>
-->
<hr />
<h2>QueryHandler</h2>
<ul>
    <li>GetRegulationListQueryHandler - класс который реализует запрос на получение списка всех возможных регламентов услуг</li>
    <li>GetRegulationQueryHandler - класс который реализует запрос на получение конкретного регламента услуг</li>
    <li>GetUserListQueryHandler - клсаа который реализует запрос на получение списка пользователей в системе</li>
    <li>GetMigrantQueryHandler - класс который реализует запрос на получение конкретного пользователя мигранта</li>
    <li>GetStatementQueryHandler - класс который реализует запрос на получение конкретного заявления</li>
    <li>GetStatusStatusQueryHandler - класс который реализует запрос на получение статуса у заявления</li>
    <li>GetNotificationQueryHandler - класс который реализует запрос на получение конкретного уведомления</li>
    <li>GetNewStatementQueryHandler - класс который реализует запрос на получение любого не рассмотренного заявления для специалиста мвд</li>
    <li>GetRolesListQueryHandler - класс который реализует запрос на получение списка всех ролей в системе</li>
    <li>GetDocumentListQueryHandler - класс который реализует запрос на получение всех документов пользователя</li>
    <li>GetNotififcationTypeListQueryHandler - класс который реализует запрос на получение всех типов уведомления в системе</li>
    <li>GetUserQueryHandler - класс который реализует запрос на получение конкретного пользователя</li>
</ul>
<hr />
<!---
<h2>Commands</h2>
<ul>
    <li>CommandProcessor - Основной класс для реализации комманд</li>
    <li>RegisterUserCommand - команда на регистрацию пользователя</li>
    <li>LoginUserCommand - команда на авторизацию пользователя</li>
    <li>UpdateRegulationTermCommand - команда на обновление регламента услуги</li>
    <li>CreateUserStatementCommand - команда на создание нового заявления</li>
    <li>UpdateDataMigrantCommand - команда на обновление данных мигранта</li>
    <li>DeleteUserCommand - команда на удаление пользователя</li>
    <li>CreateNotificationCommand - команда на создание уведомления</li>
    <li>SetStatusStatementCommand - команда на установку статуса заявления</li>
    <li>CreateDocumntCommand - команда на создание документа</li>
    <li>SetNofiticationTypeCommand - команда на установку типа получения отрывного уведомления</li>
    <li>SendNotification - команда на отправку отрывного уведомления</li>
    <li>CreateStatementCommand - команда на создание заявления</li>
</ul>
-->




<hr />
<h2>CommandHandlers</h2>
<ul>
    <li>RegisterUserCommandHandler - класс, который описывает реализацию команды регистрация пользователя</li>
    <li>LoginUserCommandHandler - класс, который описывает реализацию команды авторизация пользователя</li>
    <li>UpdateRegulationTermCommandHandler - класс, который описывает реализацию команды обновить сроки в регламенте услуг</li>
    <li>CreateUserStatementCommandHandler - класс, который описывает реализацию команды создать нового пользователя в системе</li>
    <li>UpdateDataMigrantCommandHandler - класс, который описывает реализацию команды обновить данные мигранта в системе</li>
    <li>DeleteUserCommandHandler - класс, который описывает реализацию команды уадалить пользователя</li>
    <li>CreateNotificationCommandHandler - класс, который описывает реализацию команды создать уведомление</li>
    <li>SetStatusStatementCommandHandler - класс, который описывает реализацию команды установить статус заявлению</li>
    <li>CreateDocumntCommandHandler - класс, который описывает реализацию команды создать новый документ</li>
    <li>SetNofiticationTypeCommandHandler - класс, который описывает реализацию команды установить тип уведомлению</li>
    <li>SendNotificationHandler - класс, который описывает реализацию команды отправить уведомление</li>
    <li>CreateStatementCommandHandler - класс, который описывает реализацию команды создать заявление</li>
</ul>
<hr />
<h2>Enums</h2>
<ul>
    <li>AccessLevel - все имеющиеся роли в системе</li>
    <li>StatusType - возможные статусы заявки</li>
    <li>NotificationType - типы получения отрывного уведомления</li>
</ul>

<h2><b>Domain level Description</b></h2>
<hr />
<h4>NotificationModel</h4>
<ul>
    <li>StatementGrid - уникальный номер заявления</li>
    <li>Name - Имя - заявителя</li>
    <li>Surname - Фамилия - заявителя</li>
    <li>Patronymic - Отчество - заявителя</li>
    <li>Status - Текущий статус</li>
    <li>NotificationType - тип получения отырвного уведомления</li>
</ul>
<hr />
<h4>INotificationRepository</h4>
<ul>
    <li>GetNotification - Получение уведомления по его уникальному номеру</li>
    <li>Add - добавление уведомления в репозиторий</li>
    <li>Update - обновить данные заявление</li>
</ul>
<hr />
<h4>UserModel</h4>
<ul>
    <li>Id - уникальный номер юзера</li>
    <li>Name - имя юзера</li>
    <li>Surname - фамилия юзера</li>
    <li>Patronymic - отчество юзера</li>
    <li>PasswordHash - хэш для пароля юзера</li>
    <li>Role - роль юзера</li>
</ul>
<hr />
<h4>RoleModel</h4>
<ul>
    <li>Name - наименовае роли</li>
    <li>AccessLevel - уровень доступа, показывает какие возможности будут доступны пользователю</li>
</ul>
<hr />
<h4>IRoleRepository</h4>
<ul>
    <li>GetAllRoles - получение всех возможных ролей</li>
</ul>
<hr />
<h4>IUserRepository</h4>
<ul>
    <li>Add - добавление юзера в репозиторий</li>
    <li>GetUserByEmail - получение пользователя с помощью его почты</li>
    <li>GetUserByPhone - получение пользователя с помощью его телефона</li>
    <li>GetAllUsers - получение списка всех пользователей</li>
    <li>DeleteUser - удаление пользователя из репозитория</li>
    <li>UpdateUser - обновить данные пользователя</li>
    <li>GetUserBySNP - получение юзера с помощью его ФИО</li>
</ul>
<hr />
<h4>MigrantModel</h4>
<ul>
    <li>EnteringDate - дата попадания в Россию</li>
    <li>HighlyQualified - является ли мигрант высококвалифированным</li>
    <li>ResettelmentProgrammMember - явялется ли членом программы переселения</li>
    <li>ConsistOfMigrationRegistration - состоит ли на мигранционном учёте</li>
    <li>Country - изначальная страна проживания</li>
</ul>
<hr />
<h4>IMigrantRepository</h4>
<ul>
    <li>GetCountryByMigrantId - получение страны мигранты по его уникальному Id </li>
    <li>UpdateMigrant - обновить данные мигранта</li>
    <li>GetMigrantBySNP - получение мигранта по ФИО</li>
</ul>
<hr />
<h4>StatementModel</h4>
<ul>
    <li>AccountingAdress - адрес текущей регистрации</li>
    <li>PreviousAddress - предыдущий адрес пребывания</li>
    <li>Id - уникальный номер</li>
    <li>Documents - список документов в заявлении</li>
    <li>MigrantDocuments - список документов мигранта</li>
    <li>Status - текущий статус заявления</li>
    <li>RegulationModel - регламент заявления</li>
    <li>PlaceOwner - владелец жилплощади</li>
</ul>
<hr />
<h4>DocumentModel</h4>
<ul>
    <li>Name - наименование документа</li>
    <li>Content - содержание документа</li>
    <li>CreationDate - дата создания</li>
    <li>DocumentType - тип документа</li>
</ul>
<hr />
<h4>RegulationModel</h4>
<ul>
    <li>Team - период указанный в регламенте</li>
    <li>Rules - правила установленные в регламенте</li>
    <li>Name - название регламента</li>
</ul>
<hr />
<h4>IStatementRepository</h4>
<ul>
    <li>GetAllStatementByPlaceOwner - получить все заявление поданным определенным владельцем жилплощади</li>
    <li>GetStatementStatus - получить статус заявления</li>
    <li>GetAllStatements - получить все заявления</li>
    <li>UpdateStatement - обновить данные заявления</li>
    <li>Add - добавить заявление в репозиторий</li>
</ul>
<hr />
<h4>IRegulationRepository</h4>
<ul>
    <li>GetAllRegulations - получить все регламенты</li>
    <li>UpdateRegulation - обновить данные регламента</li>
    <li>GetRegulationWithCountry - получить регламент согласно стране</li>
</ul>
<hr />
<h4>IDocumentRepository</h4>
<ul>
    <li>Add - добавить документ в репозиторий</li>
    <li>GetAllDocumentsByStatement - получить все документы согласно заявлению</li>
</ul>
<hr />
<h4>DocumentTypeModel</h4>
<ul>
    <li>Name - наименование типа документа</li>
</ul>

<h2><b>Application</b></h2>
<hr />
<h4>ITokenProvider</h4>
<ul>
    <li>GenerateToken - выполняет генерацию токена для пользователя </li>
</ul>
<hr />
<h4>IPasswordHasher</h4>
<ul>
    <li>GenerateHash - хеширует пароль</li>
    <li>Verify - проводит проверку пароля</li>
</ul>
<hr />

<h2><b>Presentation</b></h2>
<hr />
<h4>UserController</h4>
<ul>
    <li>Register - вызывает процесс регистрации пользователя</li>
    <li>Login - вызывает процесс авторизации пользователя</li>
    <li>CreateUserStatement - вызывает процесс создания заявления пользователя </li>
    <li>GetAllUsers - вызывает процесс получения всех пользователей</li>
    <li>Delete - вызывает процесс удаления пользователя</li>
    <li>SetRole - вызывает процесс установки роли пользователю</li>
    <li>GetUser - вызывает процесс получения определёного пользователя</li>
</ul>
<hr />
<h4>RegulationController</h4>
<ul>
    <li>GetRegulationToChange - вызывает процесс по получению определенного регламенту, который нужно изменить</li>
    <li>UpdateRegulationTerm - вызывает процесс изменения периода постановки на учёт в определенном регламенте</li>
</ul>
<hr />
<h4>RoleController</h4>
<ul>
    <li>GetAllRoles - вызывает процесс получения всех ролей</li>
</ul>
<hr />
<h4>StatementController</h4>
<ul>
    <li>GetAllUserStatements - вызывает процесс получения всех заявлений пользователя</li>
    <li>IsStatementReady - вызывает процесс получения статуса заявления</li>
    <li>SetStatusStatement - вызывает процесс установки статуса заявления</li>
    <li>GetNewStatement - вызывает процесс получение нового заявления</li>
    <li>CreateStatement - вызывает процесс создания заявления</li>
</ul>
<hr />
<h4>MigrantController</h4>
<ul>
    <li>ChangeData - вызывает процесс измнения данных мигранта</li>
    <li>GetMigrant - вызывает процесс получения определенного мигранта</li>
</ul>
<hr />
<h4>NotificationController</h4>
<ul>
    <li>GetNotification - вызывает процесс получения определенного уведомления</li>
    <li>CreateNotification - вызывает процесс создания уведомления</li>
    <li>GetAllTypes - вызывает процесс получения всех типов получения уведомления</li>
    <li>SetNotification - вызывает процесс установки определенного способо получения уведомления</li>
</ul>
<hr />
<h4>DocumentController</h4>
<ul>
    <li>CreateDocument - вызывает процесс создания документа </li>
    <li>GetAllDocuments - вызывает процесс по получению всх документов</li>
</ul>

