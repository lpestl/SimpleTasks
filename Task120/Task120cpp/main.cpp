#include <iostream>
#include <vector>

using namespace std;

// Структура для записи ответа
struct front_line_data
{	
	unsigned int front_line;	// Длина линии фронта
	unsigned int perimeter_r;	// Периметр R
	unsigned int perimeter_f;	// Периметр F
};

// Посчитать линию фронта по заданной области
front_line_data get_front_line(vector<vector<char>> area)
{
	// Объявим переменную для возврата ответа
	front_line_data result{};
	// Проверяем не пустая ли область сражений
	if (area.empty())
		return result;
	if (area[0].empty())
		return result;
	// Пройдем по каждой строке матрицы
	for (size_t i = 0; i < area.size(); ++i)
	{
		// И по каждому столбцу
		for(size_t j = 0; j < area[i].size(); ++j)
		{
			// Объвим счетчики для подсчета периметра и линии фронта
			unsigned int perimeter = 0;
			unsigned int front_line = 0;
			// Если текущий элемент матрицы в первой строку - то выше него - линия периметра
			if (i == 0) perimeter++;
			// Иначе если текущий элемент отличается от соседа сверху, то это линия фронта
			else if (area[i][j] != area[i - 1][j]) front_line++;
			// Если текущий элемент находится в последней строку - то ниже - линия периметра
			if (i == area.size() - 1) perimeter++;
			// Иначе если текущий элемент отличается от соседа снизу - то это линия фронта
			else if (area[i][j] != area[i + 1][j]) front_line++;
			// Аналочно и со столбцами. Если самый первый столбец - периметр, иначе если отличается от соседа слева - то линия фронта
			if (j == 0) perimeter++;
			else if (area[i][j] != area[i][j - 1]) front_line++;
			// Если самый правый столбец - то периметр, Иначе если не равен соседу справа - линия фронта
			if (j == area[i].size() - 1) perimeter++;
			else if (area[i][j] != area[i][j + 1]) front_line++;
			// Проверяем чей квадрат рассмотрели
			switch (area[i][j])
			{
			// Если R, то добавляем им посчитанный периметр
			case 'R':
				result.perimeter_r += perimeter;
				break;
			// Если F, то добавим им периметр
			case 'F':
				result.perimeter_f += perimeter;
				break;
			default: ;
			}
			// А линия фронта общая для всех
			result.front_line += front_line;
		}
	}
	result.front_line /= 2; // Линия фронта была посчитана дважды для каждой из сторон, поэтому делим на 2.
	// Каждый периметр нужно увеличить на длину линии фронта
	result.perimeter_r += result.front_line;
	result.perimeter_f += result.front_line;
	// И вернуть результат
	return result;
}

int main()
{
	// RR
	// RF
	const vector<vector<char>> area01{ { 'R', 'R'},
									   { 'R', 'F'} };
	// Answer Should Be FrontLine = 2; PerimeterR = 8; PerimeterF = 4
	auto answer01 = get_front_line(area01);
	cout << "FrontLine = " << answer01.front_line << "; PerimeterR = " << answer01.perimeter_r << "; PerimeterF = " << answer01.perimeter_f << ";" << endl;

	// RRRRRR
	// RRFFRR
	// FRRFFR
	// FFFFRR
	const vector<vector<char>> area02{ {'R','R','R','R','R','R'},
									   {'R','R','F','F','R','R'},
									   {'F','R','R','F','F','R'},
									   {'F','F','F','F','R','R'} };
	// Answer Should Be FrontLine = 14; PerimeterR = 28; PerimeterF = 20
	auto answer02 = get_front_line(area02);
	cout << "FrontLine = " << answer02.front_line << "; PerimeterR = " << answer02.perimeter_r << "; PerimeterF = " << answer02.perimeter_f << ";" << endl;

	// RRRR
	// RFFR
	// RRRR
	const vector<vector<char>> area03{ {'R','R','R','R'},
									   {'R','F','F','R'},
									   {'R','R','R','R'} };
	// Answer Should Be FrontLine = 6; PerimeterR = 20; PerimeterF = 6
	auto answer03 = get_front_line(area03);
	cout << "FrontLine = " << answer03.front_line << "; PerimeterR = " << answer03.perimeter_r << "; PerimeterF = " << answer03.perimeter_f << ";" << endl;

	return 0;
}