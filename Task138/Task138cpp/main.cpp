#include <iostream>
#include <vector>
#include <complex>
#include <numeric>

/*						����� 01. ������� �����						 */
// ���������� ��������� � ������������ ������ �� ������
std::vector<int> sub_array_with_max_abs_sum1(const std::vector<int>& input_array)
{
	// ������ �� �� ������� ��� ������� ��� ������������� � �������������?
	std::vector<int> positive;
	std::vector<int> negative;
	// � ��������� �� �����
	unsigned long long sum_positive = 0;
	unsigned long long sum_negative = 0;
	// ������� �� ���� ��������� �������
	for (auto& value : input_array)
		// ���� ������������� �������
		if (value > 0) 
		{
			// ������� � ������ � ���������� �����
			positive.push_back(value);
			sum_positive += value;
		}
		// ���� �� �������������
		else if (value < 0) 
		{
			// ������� � ��������� � ���������� �����
			negative.push_back(value);
			sum_negative -= value;
		}
	// ������ ��������� � ����������� �� ����, � �������� ����� �� ������ ������
	return sum_positive > sum_negative ? positive : negative;
}

/*						����� 02. ����� - ���������					   */			
std::vector<int> sub_array_with_max_abs_sum2(const std::vector<int>& input_array)
{
	// �������� ����� ��� ����� �������
	long long sum = std::accumulate(input_array.begin(), input_array.end(), 0);
	// �������������� ������ ��� �������� 
	std::vector<int> output_array;
	// �������� ��������, ������� ����� �� ������ ������������ �����
	for (auto& value : input_array)
	{
		// ���� ����� ����� - ������������
		if (sum > 0)
			// �� � �������� ��������� ���� ������� �� ������������� ���������
			if (value > 0)
				output_array.push_back(value);
		// ��������� - ���� ����� ������������
		if (sum < 0)
			if (value < 0)
				output_array.push_back(value);
	}
	// ������ ���������
	return output_array;
}

/*						����� 03. �������������					   */
std::vector<int> sub_array_with_max_abs_sum3(const std::vector<int>& input_array)
{
	// ������� ������ ��� ����
	std::vector<long long> sums;
	// � � ������� ��� ������ ����� ����� �������� ���� ���������
	std::vector<std::vector<int>> sub_arrays;
	// �������� max � i_max ��� ���� - ��� ������ �������
	int max = input_array[0]; int i_max = 0;
	// ������� �� ���� ��������� ��������� �������
	for (size_t i = 0; i < input_array.size(); ++i)
	{
		// �������� ������� ������� - ������� ���������� � �� ���� ����� ������� �����
		sums.push_back(input_array[i]);
		sub_arrays.push_back(std::vector<int> { input_array[i] });
		// ��������� �������� ��������� ������� ������� �� ���������� � �� �����
		for (size_t j = i + 1; j < input_array.size(); ++j)
			// ���� ����� �� ������ �� ��������� ��������� �����������
			if (std::abs(sums[i]) < std::abs(sums[i] + input_array[j]))
			{
				// �� �������� �����
				sums[i] += input_array[j];
				// � ������� ������� � ���������
				sub_arrays[i].push_back(input_array[j]);
			}
		// ������ ��������� ������������ ����� �� ������ � ������
		if (std::abs(sums[i]) > std::abs(max))
		{
			max = sums[i];
			i_max = i;
		}
	}
	// � ���������� ��������� � ������������ ������ �� ������
	return sub_arrays[i_max];
}


// ��������������� ������� ��� ������ ������� �� �����
void print_vector(const std::vector<int>& vector)
{
	// ���� ������ ������
	if (vector.empty())
	{
		// ������� ������ ������
		std::cout << "[ ]" << std::endl;
		return;
	}
	// ������� �������� � ������ �������
	std::cout << "[ " << vector[0];
	// � ��������� �������� (���� ��� ����), ����� �������
	for (size_t i = 1; i < vector.size(); ++i)
		std::cout << ", " << vector[i];
	// ��������� ������
	std::cout << " ]" << std::endl;
}

int main()
{
	// Test from task
	std::vector<int> input_vector = { -1, 2, -1, 3, -4 };

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum1(input_vector)); std::cout << std::endl;

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum2(input_vector)); std::cout << std::endl;

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum3(input_vector)); std::cout << std::endl;
	return 0;
}
