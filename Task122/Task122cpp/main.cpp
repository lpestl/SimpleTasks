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

max_sum_sub_matrix_data get_sum_sub_matrix(std::vector<std::vector<int>> matrix, int i_start, int j_start, int i_end, int j_end)
{
	max_sum_sub_matrix_data sum(0, i_start, j_start, i_end, j_end);
	for (auto i = i_start; i <= i_end; ++i)
		for (auto j = j_start; j <= j_end; ++j)
			sum.sum += matrix[i][j];
	return sum;
}

max_sum_sub_matrix_data get_max_sum_sub_matrixs_started_at(std::vector<std::vector<int>> matrix, int i_start, int j_start)
{
	max_sum_sub_matrix_data max_sum(matrix[i_start][j_start], i_start, j_start, i_start, j_start);
	for (auto i = i_start; i < matrix.size(); ++i)
		for (auto j = j_start; j < matrix[0].size(); ++j)
		{
			auto sum = get_sum_sub_matrix(matrix, i_start, j_start, i, j);
			if (sum.sum > max_sum.sum)
				max_sum = sum;
		}
	return max_sum;
}

max_sum_sub_matrix_data get_max_sum_sub_matrix(std::vector<std::vector<int>> matrix)
{
	max_sum_sub_matrix_data max_sum(static_cast<long>(matrix[0][0]), 0, 0, 0, 0);

	for (auto i = 0; i < matrix.size(); ++i)
		for (auto j = 0; j < matrix[0].size(); ++j)
		{
			auto max_sum_sub_matrix = get_max_sum_sub_matrixs_started_at(matrix, i, j);
			if (max_sum_sub_matrix.sum > max_sum.sum)
				max_sum = max_sum_sub_matrix;
		}

	return max_sum;
}

int main()
{
	// Test01 from task
	std::vector<std::vector<int>> matrix01 {
			{-1,  -2,   -3},
			{ 1,   1,   -4},
			{ 1,   1,   -5}
		};
	auto answer01 = get_max_sum_sub_matrix(matrix01);
	std::cout << "Max sum = " << answer01.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer01.i_start + 1 << "; " << answer01.j_start + 1 << ")";
	std::cout << " - (" << answer01.i_end + 1 << "; " << answer01.j_end + 1 << ");" << std::endl << std::endl;

	// Test02: Null set
	std::vector<std::vector<int>> matrix02 {
				{ -1,   -2,   -3},
				{ -1,   -1,   -4},
				{ -1,   -1,   -5}
		};
	auto answer02 = get_max_sum_sub_matrix(matrix02);
	std::cout << "Max sum = " << answer02.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer02.i_start + 1 << "; " << answer02.j_start + 1 << ")";
	std::cout << " - (" << answer02.i_end + 1 << "; " << answer02.j_end + 1 << ");" << std::endl << std::endl;

	// Test03: From task 8
	std::vector<std::vector<int>> matrix03 { {-1, 10, -9, 5, 6, -10} };
	auto answer03 = get_max_sum_sub_matrix(matrix03);
	std::cout << "Max sum = " << answer03.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer03.i_start + 1 << "; " << answer03.j_start + 1 << ")";
	std::cout << " - (" << answer03.i_end + 1 << "; " << answer03.j_end + 1 << ");" << std::endl << std::endl;

	// Test04: From task 8 v2
	std::vector<std::vector<int>> matrix04 { {1, 5, 7, -20, 3, 100, -250, 88, 33, 1, -40, 120} };
	auto answer04 = get_max_sum_sub_matrix(matrix04);
	std::cout << "Max sum = " << answer04.sum << std::endl;
	std::cout << "SubMatrix coordinate: (" << answer04.i_start + 1 << "; " << answer04.j_start + 1 << ")";
	std::cout << " - (" << answer04.i_end + 1 << "; " << answer04.j_end + 1 << ");" << std::endl << std::endl;


	return 0;
}