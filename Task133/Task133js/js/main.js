// Получаем canvas
var canvas = document.getElementById("canvas");
// и его контекст
var ctx = canvas.getContext("2d");
// назначим ширину и высоту одной ячейки
var cW = 50; var cH = 50;
// Добавим кнопку "Старт"
var btn = document.createElement("BUTTON");
btn.addEventListener("click", function () {
    btn.disabled = true;
    // Запуск анимации по клику
    startClick();
});
var t = document.createTextNode("Start");
btn.appendChild(t);
document.body.appendChild(btn);

// Функция подсчета
function calcPacManPath(width, height, row, column) {
    var count = 1;          // Количество съеденных точек
    var direction = 0;      // направление движения (1 - вправо, 0 - вниз, -1 - влево)
    var i = 1; var j = 1;   // текущие строка и столбец
    var isOmNomNom = false; // флажок для кадра кушающего PacMana
    // Инициализируем массим с точками - 1 - точка есть, 0 - уже съедена
    var array = new Array(height);
    for (var l = 0; l < height; l++) {
        array[l] = new Array(width);
        for (var k = 0; k < width; k++)
            array[l][k] = 1;
    }

    // Функция шага PacMan`а
    function nextStep() {
        // Если он жувал до этого
        if (isOmNomNom) {
            // то осуществляем шаг на следующую ячейку.
            // координату столбца меняем в зависимости от направления.
            // Если мы достигли правой границы, то направление меняется на "вниз" (или "влево", если предыдущее было "вниз"), иначе
            // Если мы достигли левой границы, то направление меняем на "вниз" (или "вправо", если предыдущее было "вниз").
            // Ну а коротко, потому что поигрался с инкрементами/декрементами и сокращением условий if
            j += j == width && j != 1 ? --direction : j == 1 && j != width ? ++direction : direction;
            // координату строки меняем только тогда, когда направление = "вниз"
            i += direction == 0;
            // Увеличиваем количество шагов
            count++;

            // Очистим канву
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            // Нарисуем точки
            drawMatrix(array, row, column);
            // нарисуем пакмана с открытым ртом
            drawPacMan(i, j, direction, isOmNomNom);
            isOmNomNom = false;
        } else {
            // Очистим канву и перерисуем точки и пакмана, только уже с закрытым ртом
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawMatrix(array, row, column);
            drawPacMan(i, j, direction, isOmNomNom);
            isOmNomNom = true;
            // и скушаем очередную точку
            array[i-1][j-1] = 0;
        }
        // Выведим текущий шаг на экран
        document.querySelector("#step").innerHTML = count;
        // Если добрались до цели
        if ((i == row) && (j == column)) {
            // то выводим ответ и снова активируем кнопку
            document.querySelector("#answer").innerHTML = count;
            btn.disabled = false;
        } else {
            // иначе снова повторим шаг через 300 милисекунд
            setTimeout(nextStep, 300);
        }
    }

    // запускаем первый шаг
    nextStep();
}

// отсюда стартует алгоритм
function startClick()
{
    // считываем введенные пользователем данные
    var N = document.getElementById("width").value;
    var M = document.getElementById("height").value;
    var row = document.getElementById("row").value;
    var column = document.getElementById("column").value;

    document.querySelector("#step").innerHTML = 1;

    // меняем размер канвы
    canvas.width = N * cW;
    canvas.height = M * cH;

    // и начинаем считать
    calcPacManPath(N, M, row, column);
}

// функция рисования PacMan`а
function drawPacMan(row, column, direction, isOMNONNOM) {
    // считаем радиус пакмана и его координаты центра
    var radius = cW / 2 - 4;
    var y = row * cW - radius - 2;
    var x = column * cH - radius - 2;
    // выбираем начальный угол в зависимости от того, с открытым ртом его рисовать или нет
    var startAngle = isOMNONNOM ? Math.PI / 15 : Math.PI / 4;
    // и в зависимости от направления - корректируем угол
    switch (direction) {
        case 1:
            startAngle += 0;
            break;
        case -1:
            startAngle += Math.PI;
            break;
        default:
            startAngle += Math.PI / 2;
    }

    ctx.strokeStyle = "black";
    ctx.fillStyle = "yellow";
    // рисуем одну половинку
    ctx.beginPath();
    ctx.arc(x, y, radius, startAngle, Math.PI + startAngle);
    ctx.closePath();
    ctx.stroke();
    ctx.fill();
    // и вторую
    ctx.beginPath();
    ctx.arc(x, y, radius, -startAngle, Math.PI - startAngle, direction == -1 ? true : direction == 1);
    ctx.stroke();
    ctx.fill();
}

// рисуем точки по матрице
function drawMatrix(array, row, column) {
    for (var i = 0; i < array.length; i++) {
        for (var j = 0; j < array[i].length; j++) {
            if (array[i][j] == 1) {
                ctx.beginPath();
                ctx.fillStyle = "red";
                ctx.arc((j + 1) * cW - cW / 2, (i + 1) * cH - cH / 2, 5, 0, Math.PI * 2);
                ctx.stroke();
                ctx.fill();
                ctx.closePath();
            }
            // и обведем конечную клетку, куда должен прийти пакман
            if ((i == (row - 1)) && (j == (column - 1))) {
                ctx.rect(j * cH, i * cW, cW, cH);
                ctx.stroke();
            }
        }
    }
}