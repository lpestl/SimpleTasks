var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");

var cW = 50;
var cH = 50;

var btn = document.createElement("BUTTON");
btn.addEventListener("click", function () {
    btn.disabled = true;
    startClick();
});
var t = document.createTextNode("Start");
btn.appendChild(t);
document.body.appendChild(btn);

function calcPacManPath(width, height, row, column) {
    var count = 1;
    var direction = 0;
    var i = 1;
    var j = 1;
    var isOmNomNom = false;

    var array = new Array(height);
    for (var l = 0; l < height; l++) {
        array[l] = new Array(width);
        for (var k = 0; k < width; k++)
            array[l][k] = 1;
    }

    function nextStep() {
        if (isOmNomNom) {
            j += j == width && j != 1 ? --direction : j == 1 && j != width ? ++direction : direction;
            i += direction == 0;
            count++;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawMatrix(array, row, column);
            drawPacMan(i, j, direction, isOmNomNom);
            isOmNomNom = false;
        } else {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawMatrix(array, row, column);
            drawPacMan(i, j, direction, isOmNomNom);
            isOmNomNom = true;
            array[i-1][j-1] = 0;
        }
        document.querySelector("#step").innerHTML = count;

        if ((i == row) && (j == column)) {
            document.querySelector("#answer").innerHTML = count;
            btn.disabled = false;
        } else {
            setTimeout(nextStep, 300);
        }
    }

    nextStep();
}

function startClick()
{
    var N = document.getElementById("width").value;
    var M = document.getElementById("height").value;
    var row = document.getElementById("row").value;
    var column = document.getElementById("column").value;

    document.querySelector("#step").innerHTML = 1;

    canvas.width = N * cW;
    canvas.height = M * cH;

    calcPacManPath(N, M, row, column);
}

function drawPacMan(row, column, direction, isOMNONNOM) {
    var radius = cW / 2 - 4;
    var y = row * cW - radius - 2;
    var x = column * cH - radius - 2;
    
    var startAngle = isOMNONNOM ? Math.PI / 15 : Math.PI / 4;

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
    ctx.beginPath();
    ctx.arc(x, y, radius, startAngle, Math.PI + startAngle);
    ctx.closePath();
    ctx.stroke();
    ctx.fill();
    ctx.beginPath();
    ctx.arc(x, y, radius, -startAngle, Math.PI - startAngle, direction == -1 ? true : direction == 1);
    ctx.stroke();
    ctx.fill();
}

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
            if ((i == (row - 1)) && (j == (column - 1))) {
                ctx.rect(j * cH, i * cW, cW, cH);
                ctx.stroke();
            }
        }
    }
}