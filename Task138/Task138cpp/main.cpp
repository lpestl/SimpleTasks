/*						����� 01. ������� �����					 */	
#include <iostream>
#include <vector>
#include <complex>

// ���������� ��������� � ������������ ������ �� ������
std::vector<int> sub_array_with_max_abs_sum(const std::vector<int>& input_array)
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
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum(input_vector)); std::cout << std::endl;

	return 0;
}
