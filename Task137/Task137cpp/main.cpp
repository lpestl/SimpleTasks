/*					01_1. ������������ � ������������ �����				*/	

#include <iostream>
#include <vector>
#include <algorithm>
// ������ ENUM ��� �������� ����������, � ������� -1 - ����� ���������� �� ������, � 1 - ������ ���������� ����� ����������
enum status { NOT_FOUND = -1, DONE = 1 };

// ����������� �������. ��������� ��������� ������� ��������� � ��������� ��� � ������
int factor(unsigned remainder, std::vector<int> &multipliers)
{
	// ���� ������� ������ 10 (�������� ������)
	if (remainder < 10) 
	{
		// �� ��������� ��� � ����� �������
		multipliers.push_back(remainder);
		// � ����������� �����
		return DONE;
	}
	// ��� ��� ��� ����� �������������� �����-�����, �� ����� ��������� ����� ������, ��� ����� ��������������� ������ ����� � ���� �����
	// ������� ���� ���������� � ������������ ����� � ���� �� ����� ������.
	for (auto i = 9; i > 1; --i)
		// ���� ������� �������� �� ������� ����� ��� �������
		if (remainder % i == 0)
		{
			// �� ��������� ��������� ���������
			multipliers.push_back(i);
			// � ���� ���������� ����� ������ � ���������� ����������
			if (factor(remainder / i, multipliers) == DONE)
				// �� �������� ���������� �������� � ��������, ��� ������������ �����-��������� �������
				return DONE;
			// ����� ������� ������� ����� �� �������
			multipliers.pop_back();
		}
	// ���������� ����������, � ���, ��� ����������� �� �������
	return NOT_FOUND;
}

// �������� ����������� ����������� ����� �� ������ ����������
long long get_min_number(std::vector<int>& multipliers)
{
	// ��� ������ ��������� ������ �� ����������� �� ��������
	std::sort(multipliers.begin(), multipliers.end(), std::greater<int>());
	// �������������� ����������, ������� � ����� ������� ����� ������
	long long number = 0;
	// � ������ ����� ������������ � ��������� � ������������ � ��������
	for (auto i = 0; i < multipliers.size(); ++i)
		number += multipliers[i] * static_cast<long long>(std::pow(10.0, i));
	// � ������ ���������
	return number;
}

// ������� ������� �������� ������������ � ��������� ������������ ������
long long factoring(unsigned n)
{
	// ������������� ������ ��� ���������� 
	std::vector<int> multipliers;	
	// ���� ��������� �� �������, �� ������ -1. ����� ��������� ������ � ����� 
	return factor(n, multipliers) == NOT_FOUND ? -1 : get_min_number(multipliers);
}

int main()
{
	unsigned n;

	// Tests from task
	n = 11;	std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 12;	std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 14; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	
	// My test
	n = 126; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 300; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 1000000000; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;

	return 0;
}
