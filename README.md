# otus_architecture_lab_3

Диаграмма классов программы P1. программа считывает матрицы из указаных в параметрах файлах и записывает сумму матриц в файл указанный так же в параметрах.

![alt text](https://github.com/AlexandrBashkirev/otus_architecture_lab_3/blob/master/otus_architecture_lab_3/P1_class_diagramm.png?raw=true)


Диаграмма классов программы P2. Программа генерирует две матрицы, складывает и выводит результат в консоль. Для суммирования используется класс MatrixSumCommand который является адаптером, который адаптирует интерфейс программы P1 к интерфейсу ICommand. И таким образом скрывает в себе логику суммирования матрицы.
![alt text](https://github.com/AlexandrBashkirev/otus_architecture_lab_3/blob/master/otus_architecture_lab_3/P2_class_diagramm.png?raw=true)
