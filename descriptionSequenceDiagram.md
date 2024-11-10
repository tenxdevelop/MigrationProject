
![](https://github.com/tenxdevelop/MigrationProject/blob/main/SequenceDiagramSource/ChangeSystemSD.png)


Описание ChangeSystemSD:<br><br>&emsp;&emsp;
<span>Операция: GetPossibleToChangeData</span><br>&emsp;&emsp;
<span>Предусловие:  инициирует изменение некоторых данных в системе</span><br>&emsp;&emsp;
<span>Ссылка:  прецидент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловвие:</span><br>&emsp;&emsp;&emsp;&emsp;

* 1) получен список регламентов доступных к изменению

<span>Операция: ChangeRegulation(regulation, newTerm)</span><br>&emsp;&emsp;
<span>Предусловие:  получен список регламентов и выбран необходимый для изменения</span><br>&emsp;&emsp;
<span>Ссылка:  прецидент"Настраивать систему"</span><br>&emsp;&emsp;
<span>Постусловвие:</span><br>&emsp;&emsp;&emsp;&emsp;

* 1) регламенту, необходимому для изменения, присвоено новое значение term, в случаи некоректного значения term возвращена ошибка.
