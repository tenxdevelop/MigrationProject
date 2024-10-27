<br><br><br>
<h1 align="center">ER Диаграмма предметной области</h1>
<br><br><br>

![](https://github.com/tenxdevelop/MigrationProject/blob/main/ERModel.png)

<h1>
Описание ER диаграммы
</h1>

<h2>
Сущности
</h2>
<meta http-equiv=Content-Type content="text/html; charset=utf-8">
<meta name=Generator content="Microsoft Word 15 (filtered)">
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:Wingdings;
	panose-1:5 0 0 0 0 0 0 0 0 0;}
@font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:0in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:.5in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
p.MsoListParagraphCxSpFirst, li.MsoListParagraphCxSpFirst, div.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
p.MsoListParagraphCxSpMiddle, li.MsoListParagraphCxSpMiddle, div.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
p.MsoListParagraphCxSpLast, li.MsoListParagraphCxSpLast, div.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:.5in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
.MsoChpDefault
	{font-family:"Calibri",sans-serif;}
.MsoPapDefault
	{margin-bottom:8.0pt;
	line-height:107%;}
@page WordSection1
	{size:595.3pt 841.9pt;
	margin:56.7pt 42.5pt 56.7pt 85.05pt;}
div.WordSection1
	{page:WordSection1;}
 /* List Definitions */
 ol
	{margin-bottom:0in;}
ul
	{margin-bottom:0in;}
-->
</style>

</head>

<body lang=EN-US style='word-wrap:break-word'>

<div class=WordSection1>

<p class=MsoNormal align=center style='text-align:center'><span lang=RU>Описание
диаграммы</span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=RU>Сущности
и их атрибуты</span></p>

<p class=MsoNormal><span lang=RU>Пользователь – сущность которая описывает
пользователя.</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span>: </p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.4pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Почта – </span>email <span lang=RU>пользователя</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.4pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>ФИО – Фамилия Имя и Отчество пользователя</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.4pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Телефон – номер телефона пользователя</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.4pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Пароль – пароль пользователя.</span></p>

<p class=MsoNormal><span lang=RU>Мигрант – сущность, которая описывает
иностранного гражданина, которому необходимо встать на миграционный учёт в
России</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span>:</p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Дата въезда в Россию – дата, когда мигрант попал на
территорию России</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Страна – Государственное образование из которого
мигрант приехал</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Высококвалифицированный – Имеет ли мигрант высокую
квалификацию в каком-либо виде деятельности.</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Член программы – входит ли мигрант в
государственную программу переселения</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Миграционный учёт – Состоит ли член вашей семьи или
вы на миграционном учёте ранее.</span></p>

<p class=MsoNormal><span lang=RU>Документ – Сущность, описывающая документы,
которые используются в заявлении</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span>:</p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Тип документа – Описывает конкретный тип документа.</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Название - <span style='border:none windowtext 1.0pt;
padding:0in'>Уникальное имя документа, которое отражает его содержание или
цель.</span></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Дата создания - <span style='border:none windowtext 1.0pt;
padding:0in'>Дата, когда документ был впервые создан или опубликован</span></span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Содержание - <span style='border:none windowtext 1.0pt;
padding:0in'>Основное содержание документа, которое может включать текст,
изображения, таблицы и другие элементы.</span></span></p>

<p class=MsoNormal><span lang=RU>Заявление – сущность, описывающая заявку,
которая подаётся, для постановки мигранта на учёт.</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span></p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Адрес учёта – адрес на учёт, на котором надо
поставить мигранта</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Прежний адрес – адрес, на котором мигрант был
закреплен раньше, если таковой имелся.</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Статус – текущее состояние заявления</span></p>

<p class=MsoNormal><span lang=RU>Регламент заявления – сущность, которая описывает
условия постановки мигранта на миграционный учёт.</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span></p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Срок – Период времени, в который необходимо выполнить
условие регламента</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Условие – Описывает требование к документам</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Название – Именование самого регламента</span></p>

<p class=MsoNormal><span lang=RU>&nbsp;</span></p>

<p class=MsoNormal><span lang=RU>Роль – сущность, которая описывает список
возможностей пользователя</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span></p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Название – Именование роли.</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Уровень доступа – определяет возможности роли</span></p>

<p class=MsoNormal><span lang=RU>Уведомление - Сущность, описывающая результат,
полученный после обработки заявления</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span>:</p>

<p class=MsoListParagraphCxSpFirst style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Результат – Одобрена или нет была заявка на
постановку мигранта на учёт</span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-left:71.25pt;text-indent:
-.25in'><span lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>ФИО заявителя – Фамилия Имя и Отчество подавшего
заявление</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:71.25pt;text-indent:-.25in'><span
lang=RU style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Номер заявки – Уникальный номер заявления.</span></p>

<p class=MsoNormal><span lang=RU>Способ уведомления – Сущность, которая
описывает, способ, с помощью которого, заявителя уведомят о результате
поданного им заявления</span></p>

<p class=MsoNormal><span lang=RU>                Атрибуты</span>:</p>

<p class=MsoListParagraph style='margin-left:71.25pt;text-indent:-.25in'><span
lang=EN-GB style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span lang=RU>Название – название способа уведомления.</span></p>

</div>

</body>

<h2>
Связи между сущностями
</h2>

Пользователь -> Мигрант: 1 К 1, 1 пользователь, описывает только 1 мигранта, и 1 мигрант может являться только 1 пользователем
<br><br>
Пользователь -> Документ: 1 к М, Пользователь может иметь 0 или много документов, конкретный документ может быть только у 1-го пользователя
<br><br>
Пользователь -> Заявление: 1 к М, Пользователь может подавать много заявлений, конкретное заявление относится только к 1 пользователю.
Так же Пользователь может обрабатывать много заявлений, а конкретное заявление может обрабатываться только 1 пользователем
<br><br>
Пользователь -> Регламент заявления: 1 к М, пользователь может менять множество регламентов, конкретный регламент может изменять только 1 пользователь.
<br><br>
Регламент заявления -> Заявление: 1 к М, по одному регламенту может быть подано много заявлений, но любое заявление относится только к 1 регламенту
<br><br>
Документ -> заявление: N к М, один документ может быть использован во множестве заявлений, в одном заявлении содержится множество документов
<br><br>
Роль -> пользователь: 1 к М, Пользователь может иметь макс. 1 роль, в то же время каждая роль может иметь множество пользователей.
<br><br>
Пользователь -> уведомление: 1 к М, Пользователь может иметь множество уведомлений, но любое уведомление относится только к 1 пользователю. 
Так же, пользователь может создать много уведомлений, но каждое уведомление создано лишь 1 пользователем.
<br><br>
Способ уведомления -> Уведомление: 1 к М, 1 способом можно отправить много уведомлений, но каждое уведомление может быть отправлено лишь 1 способом.
