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
	// Answer Should Be FrontLine = 14; PerimeterR = 27; PerimeterF = 20
	auto answer02 = get_front_line(area02);
	cout << "FrontLine = " << answer02.front_line << "; PerimeterR = " << answer02.perimeter_r << "; PerimeterF = " << answer02.perimeter_f << ";" << endl;

	// RRRR
	// RFFR
	// RRRR
	const vector<vector<char>> area03{ {'R','R','R','R'},
									   {'R','F','F','R'},
									   {'R','R','R','R'} };
	// Answer Should Be FrontLine = 6; PerimeterR = 14; PerimeterF = 6
	auto answer03 = get_front_line(area03);
	cout << "FrontLine = " << answer03.front_line << "; PerimeterR = " << answer03.perimeter_r << "; PerimeterF = " << answer03.perimeter_f << ";" << endl;

	return 0;
}