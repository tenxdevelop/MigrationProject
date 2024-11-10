
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/ChangeSystemSD.png)


Описание Диаграммы последовательности "Настроить систему":<br><br>&emsp;&emsp;
<span>Операция: GetPossibleToChangeData</span><br>&emsp;&emsp;
<span>Предусловие:  инициирует изменение некоторых данных в системе</span><br>&emsp;&emsp;
<span>Ссылка:  прецидент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловвие:</span>

* получен список регламентов доступных к изменению

&emsp;&emsp;
<span>Операция: ChangeRegulation(regulation, newTerm)</span><br>&emsp;&emsp;
<span>Предусловие:  получен список регламентов и выбран необходимый для изменения</span><br>&emsp;&emsp;
<span>Ссылка:  прецидент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловвие:</span>

* регламенту, необходимому для изменения, присвоено новое значение term, в случаи некоректного значения term возвращена ошибка.

<br><br><br>
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/CheckRegulationSD.png)

Описание Диаграммы последовательности "Просмотреть регламент услуги":<br><br>&emsp;&emsp;
<span>Операция: GetRegulations</span><br>&emsp;&emsp;
<span>Предусловие:  авторизированный мигрант инициирует просмотр регламента услуг</span><br>&emsp;&emsp;
<span>Ссылка:  прецидент “Просмотреть регламент услуги”</span><br>&emsp;&emsp;
<span>Постусловвие:</span>

* получен регламент услуги, на основе страны мигранта 
