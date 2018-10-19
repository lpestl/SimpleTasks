#include <iostream>

// ������� ���������� (��� �������� height ���� ������, ���� �� ������ �������� �� ���� ���������� ������)
unsigned int calc_pac_man_path(int width, int height, int row, int column)
{
	// ������� �������� ����� ������ �� ������ ������� � �� ����������� �������� ���������� ������
	// ���������� ��������� �� ������ �������, � ������ ���� ������ ������ (������ � ���� ������ pac-man ��������� ����� �������),
	// ��� ������ ������ ������� �� ������� ������ ������� � ������ ���� ������ �������� (��������� ������ ������)
	return row * width - (row % 2 == 0 ? column - 1/*�������� ��������, ����� ������������ ����*/ : width - column);
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