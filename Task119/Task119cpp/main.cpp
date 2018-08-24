#include <iostream>
#include <vector>

using namespace std;

// Функция получения седловых точек из матрицы целых чисел
vector<int> get_point_selles(vector<vector<int>> matrix)
{
	// Объявление вектора для хранения результата (списка седловых точек)
	vector<int> point_selles;

	// Если матрица пустая (не имеет строк или столбцов), то она не имеет седловых точек и мы возвращаем пустрой вектор
	if (matrix.empty()) return point_selles;
	if (matrix[0].empty()) return point_selles;

	// Объявление вектора для хранения максимальных значений в столбцах
	vector<int> maxs;
	// Увеличим ёмкость вектора до количества столбцов матрицы
	maxs.reserve(matrix[0].size());
	// И инициализируем значения максимумов первыми элементами каждого столбца
	for (auto j : matrix[0])
		maxs.emplace_back(j);

	// Аналогично объявляем вектор для хранения минимумов и увеличиваем его ёмкость до количества строк в матрице
	vector<int> mins;
	mins.reserve(matrix.size());

	// Перебираем все строки матрицы
	for(size_t i = 0; i < matrix.size(); ++i)
	{
		// Инициализируя при этом минимумы для каждой строки первым элементом
		mins.emplace_back(matrix[i][0]);
		// Перебераем все столбцы матрицы
		for(size_t j = 0; j < matrix[i].size(); ++j)
		{
			// Если текущий элемент матрицы больше максимума для текущего столбца
			if (matrix[i][j] > maxs[j]) 
				// то максимальным значением для этого столбца назначаем текущий элемент матрицы
				maxs[j] = matrix[i][j];
			// Если текущий элемент матрицы меньше минимума для текущей строки
			if (matrix[i][j] < mins[i])
				// то минимумом текущей строки назначаем текущий элемент матрицы
				mins[i] = matrix[i][j];
		}
	}

	// Теперь выберем из максимумов и минимумов седловые элементы
	for (size_t i = 0; i < mins.size(); ++i)
		for (size_t j = 0; j < maxs.size(); ++j)
			// Если максимум для текщего столбца совпадает с минимумом текущей строки
			if (maxs[j] == mins[i])
				// то этот элемент является седловым элементом матрицы 
				point_selles.emplace_back(matrix[i][j]);

	return point_selles;
}

// Проверка решения
int main()
{
	// Test 1: from task
	const vector<vector<int>> matrix1{ {1,3,5}, {7,9,11}, {13,15,17} };
	auto answer1 = get_point_selles(matrix1);
	// Should Be 13
	for (auto value : answer1)
		cout << value << "; ";
	cout << endl;

	// Test 2: from wiki https://ru.wikipedia.org/wiki/%D0%A1%D0%B5%D0%B4%D0%BB%D0%BE%D0%B2%D0%BE%D0%B9_%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82_%D0%BC%D0%B0%D1%82%D1%80%D0%B8%D1%86%D1%8B
	const vector<vector<int>> matrix2{ {5, 6, 4, 5}, {-2, 5, 3, 7}, {8, 7, -2, 6} };
	auto answer2 = get_point_selles(matrix2);
	// Should Be 4
	for (auto value : answer2)
		cout << value << "; ";
	cout << endl;

	// Test 3: from wiki
	const vector<vector<int>> matrix3{ {2, 3, 5, 2}, {2, 4, 6, 2}, {-2, 7, 2, 0} };
	auto answer3 = get_point_selles(matrix3);
	// Should Be 2; 2; 2; 2;
	for (auto value : answer3)
		cout << value << "; ";
	cout << endl;

	// Test 4: from wiki
	const vector<vector<int>> matrix4{ {3, 2, 1}, {1, 3, 4} };
	auto answer4 = get_point_selles(matrix4);
	// Should Be empty
	for (auto value : answer4)
		cout << value << "; ";
	cout << endl;

	// Test 5: from wiki
	const vector<vector<int>> matrix5{ {1, 1}, {1, 1} };
	auto answer5 = get_point_selles(matrix5);
	// Should Be 1; 1; 1; 1;
	for (auto value : answer5)
		cout << value << "; ";
	cout << endl;

	return 0;
}