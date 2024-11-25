
![](https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagramSource/CD1.png)


![](https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagramSource/CD2.png)

![](https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagramSource/CD3.png)

ссылка на StarUml диаграмму - https://github.com/tenxdevelop/MigrationProject/blob/main/ClassDiagram.mdj

<h1>Описание</h1>
<h2>Используется шаблон CQRS<h2>
<ul>
    <li>Models - сущности (Domain уровень)</li>
    <li>Controllers - произодит маршрутизацию по запросам пользователя(Presentation уровень)</li>
    <li>Query - Описывает сигнатуру и тип запроса(Application уровень)</li>
    <li>QueryHandlers - исполнители запросов к данным(Application уровень)</li>
    <li>Command - описывает тип и сигнатуру команды(Application уровень)</li>
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
    <li>ICommand - интерфейс от которого наследуются все остальные комманды</li>
    <li>ICommandHandler - интефейс от которого наследуются все исполнители комманд</li>
    <li>ICommandProcessor - позволяет на основе ICommand определяет какой именно commandHandler вызвать</li>
    <li>IQuery - интерфейс от которого наследуются все остальные запросы(queries)</li>
    <li>IQueryHandler - интерфейс от которого наследуются все исполнители запросов</li>
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
