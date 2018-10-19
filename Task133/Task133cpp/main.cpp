#include <iostream>

// Функция вычисления (тут параметр height даже лишний, если не делать проверку на ввод корректных данных)
unsigned int calc_pac_man_path(int width, int height, int row, int column)
{
	// Сначала умножаем номер строки на ширину матрицы и от полученного значения достаточно отнять
	// количество элементов до номера столбца, в случае если строка четная (значит в этой строке pac-man двигается слева направо),
	// или отнять ширину матрицы за вычетом номера столбца в случае если строка нечетная (двигается справа налево)
	return row * width - (row % 2 == 0 ? column - 1/*единичку отнимаем, чтобы включительно было*/ : width - column);
}

// Tests
int main()
{
	/*
	 *		X 0 0
	 *		0 0 0
	 *		0 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 1 << " x " << 1 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 9, 9, 1) << std::endl << std::endl;

	/*
	 *		. X 0
	 *		0 0 0
	 *		0 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 1 << " x " << 2 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 1, 2) << std::endl << std::endl;

	/*
	 *		. . X
	 *		0 0 0 
	 *		0 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 1 << " x " << 3 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 1, 3) << std::endl << std::endl;

	/*
	 *		. . .
	 *		0 0 X
	 *		0 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 2 << " x " << 3 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 2, 3) << std::endl << std::endl;

	/*
	 *		. . .
	 *		0 X .
	 *		0 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 2 << " x " << 2 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 2, 2) << std::endl << std::endl;

	// Test from task
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 2 << " x " << 1 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 2, 1) << std::endl << std::endl;

	/*
	 *		. . . 
	 *		. . .
	 *		X 0 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 3 << " x " << 1 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 3, 1) << std::endl << std::endl;

	/* 
	 *		. . .
	 *		. . .
	 *		. X 0
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 3 << " x " << 2 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 3, 2) << std::endl << std::endl;

	/*
	 *		. . .
	 *		. . .
	 *		. . X
	 */
	std::cout << "N x M = " << 3 << " x " << 3 << ";" << std::endl <<
		"ROW x COLUMN = " << 3 << " x " << 3 << std::endl <<
		"Answer = " << calc_pac_man_path(3, 3, 3, 3) << std::endl << std::endl;

	return 0;
}