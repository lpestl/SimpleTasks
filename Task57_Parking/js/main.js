// Входная строка
//var inputStr = "- - -S--C-E--C- -";
var inputStr = "- -C--C--C--C- -";
document.getElementById('input').innerHTML = inputStr;

// Удаляем пробелы из входной строки
var outputStr = inputStr.replace(/\s*/g, '');

// Инициализируем счетчик парковочных мест
var result = 0;
// Проходим посимвольно по входной строке (без пробелов)
for (var i = 0; i < outputStr.length; i++) {
    // Если сейчас теретория без знака (стоянка, переход или выход)
    if (outputStr[i] == '-') {
        // то проверяем чтобы впереди на 10 не было знака остановки
        if (((outputStr[i + 1] != 'S') && (outputStr[i + 2] != 'S'))
            // и проверяем чтобы позади и впереди на 5 метров не было знака пешеходного перехода
            && ((outputStr[i - 1] != 'C') && (outputStr[i + 1] != 'C')))
        {
            // если нет запретов, то увеличиваем счетчик парковочных мест на еденицу
            result++;
        }
    }
}

// Вывод результата
var outputView = document.getElementById('output');
outputView.innerHTML = result;