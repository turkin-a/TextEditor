# TextEditor
Обработчик текста

Программа удаляет слова менее заданного размера и/или удаляет знаки препинания.
Чтение файла происходит построчно во избежание проблем работы с большими файлами.
Программа тестировалась с текстами в формате UTF-8.
Удаляемые знаки препинания ! ? , . ;

Основное меню:
Добавить файл - добавляет файл на обработку с указанием параметров.
Удалить файл - удаляет файл из списка на обработку (выбранный в ListBox).
Очистить - удаляет из списка сразу все файлы.
Запустить - обрабатывает все файлы из списка (асинхронная обработка).

Меню добавления файла:
Входной файл - полное имя входного файла на обработку.
Входной файл - полное имя выходного файла.
Мин. длина неудаляемых слов - минимальное число букв в словах, которые не удаляются из текста.
Удалять знаки препинания - при выборе удаляет знаки препинания.
