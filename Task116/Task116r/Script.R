# Task 116
optimalWay <- function(oilCosts, trainRoads) {
    # Построим матрицу направленного графа
    graph <- matrix(data = NA, length(oilCosts), length(oilCosts), T);
    graph[trainRoads[1:length(trainRoads), 1], trainRoads[1:length(trainRoads), 2]] = oilCosts[trainRoads[1:length(trainRoads), 1]]
    graph
}

# Test from task
oilCosts <- c(5, 10, 1);
trainRoads <- c(c(1, 3), c(1, 2), c(3, 2));
optimalWay(oilCosts, trainRoads);