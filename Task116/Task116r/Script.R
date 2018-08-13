# Task 116
optimalWay <- function(oilCosts, trainRoads) {

    # Построим матрицу edges, которая будет хранить (edges[A]) все пути из пункта A
    # А в ребре edges[A][i] второй индекс - это пунтк назначения, а значение - это вес, который заранее не известен и будет INF
    edges <- matrix(data = Inf, length(oilCosts), length(oilCosts), T);
    for (i in 0:(length(trainRoads) / 2 - 1)) {
        edges[trainRoads[1 + 2 * i], trainRoads[2 + 2 * i]] <- oilCosts[trainRoads[1 + 2 * i]];
        edges[trainRoads[2 + 2 * i], trainRoads[1 + 2 * i]] <- oilCosts[trainRoads[2 + 2 * i]];
    }
    # Вектор costs будет содержать стоимость поездки до населденного пункта
    costs <- matrix(data = Inf, length(oilCosts), 1)
    costs[1, 1] <- 0
    # И создадим вектор для хранения пути
    path <- matrix(data = 1, length(oilCosts), 1)
    # Реализуем алгоритм Белльана - Форда
    # Переберем все ребра(пути)
    for (e in 1:length(oilCosts)) {
        # Переберем все начальные пункт отправления
        for (v in 1:length(oilCosts)) {
            # Переберем все пункты назначения
            for (i in 1:length(oilCosts)) {
                # Если нужно, то обновим вес рубра (стоимость поездки до пункта)
                if (costs[i, 1] > costs[v, 1] + edges[v, i]) {
                    costs[i, 1] <- costs[v, 1] + edges[v, i];
                    path[i, 1] <- v;
                }
            }
        }
    }
    # Ну и раз есть такая возможность, то нарисуем наш граф

    # Вычесляем путь
    answer <- vector(mode = "list");
    current <- length(oilCosts);
    answer <- append(answer, current, 0)
    # И выстраеваем его по порядку
    while (current != 1) {
        answer <- append(answer, path[current, 1], 0);
        current <- path[current, 1];
    }
    return(answer);
}

# Test from task
oilCosts <- c(5, 10, 1);
trainRoads <- c(c(1, 3), c(1, 2), c(3, 2));
answer1 <- optimalWay(oilCosts, trainRoads);

oilCosts <- c(10, 20, 30, 40, 50);
trainRoads <- c(c(1, 2), c(1, 3), c(1, 4), c(2, 4), c(3, 5), c(3, 4), c(4, 5));
answer2 <- optimalWay(oilCosts, trainRoads);

oilCosts <- c(5, 5, 5, 5, 5, 5, 5, 5, 5, 5);
trainRoads <- c(c(1, 3), c(1, 2), c(2, 4), c(3, 5), c(4, 6), c(5, 7), c(6, 8), c(7, 9), c(8, 10), c(9, 10));
answer3 <- optimalWay(oilCosts, trainRoads)

# end