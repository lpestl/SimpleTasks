#include <iostream>
#include <vector>

struct max_sum_sub_matrix_data
{
	max_sum_sub_matrix_data(long _sum, int _i_start, int _j_start, int _i_end, int _j_end) : 
		sum(_sum),
		i_start(_i_start),
		j_start(_j_start),
		i_end(_i_end),
		j_end(_j_end) {}
	long sum;     // Максимальная сумма
	int i_start;  // Индекс строки левого верхнего угла подматрицы
	int j_start;  // Индекс столбца левого верхнего угла подматрицы
	int i_end;    // Индекс строки прового нижнего угла подматрицы (включительно)
	int j_end;    // Индекс строки правого нижнего угла подматрицы (включительно)
};

max_sum_sub_matrix_data get_max_sum_sub_matrix(std::shared_ptr<std::vector<std::vector<int>>> matrix)
{
	max_sum_sub_matrix_data max_sum(matrix[0][0], 0, 0, 0, 0);

	return max_sum;
}

int main()
{
	// Test01 from task
	std::shared_ptr<std::vector<std::vector<int>>> matrix01(
		new std::vector<std::vector<int>> 
		{
				{-1,  -2,   -3},
				{ 1,   1,   -4},
				{ 1,   1,   -5}
		});
	auto answer01 = get_max_sum_sub_matrix(matrix01);
	std::cout << "Max sum = " << answer01.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer01.i_start << "; " << answer01.j_start << ")";
	std::cout << " - (" << answer01.i_end << "; " << answer01.j_end << ");" << std::endl << std::endl;

	// Test02: Null set
	std::shared_ptr<std::vector<std::vector<int>>> matrix02(
		new std::vector<std::vector<int>>
		{
				{ -1,   -2,   -3},
				{ -1,   -1,   -4},
				{ -1,   -1,   -5}
		});
	auto answer02 = get_max_sum_sub_matrix(matrix02);
	std::cout << "Max sum = " << answer02.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer02.i_start << "; " << answer02.j_start << ")";
	std::cout << " - (" << answer02.i_end << "; " << answer02.j_end << ");" << std::endl << std::endl;

	// Test03: From task 8
	std::shared_ptr<std::vector<std::vector<int>>> matrix03(
		new std::vector<std::vector<int>>{ {-1, 10, -9, 5, 6, -10} });
	auto answer03 = get_max_sum_sub_matrix(matrix03);
	std::cout << "Max sum = " << answer03.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer03.i_start << "; " << answer03.j_start << ")";
	std::cout << " - (" << answer03.i_end << "; " << answer03.j_end << ");" << std::endl << std::endl;

	// Test04: From task 8 v2
	std::shared_ptr<std::vector<std::vector<int>>> matrix04(
		new std::vector<std::vector<int>>
		{ {1, 5, 7, -20, 3, 100, -250, 88, 33, 1, -40, 120} });
	auto answer04 = get_max_sum_sub_matrix(matrix04);
	std::cout << "Max sum = " << answer04.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer04.i_start << "; " << answer04.j_start << ")";
	std::cout << " - (" << answer04.i_end << "; " << answer04.j_end << ");" << std::endl << std::endl;


	return 0;
}