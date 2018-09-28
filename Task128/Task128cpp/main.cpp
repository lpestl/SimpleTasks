#include <iostream>
/// ������� ��������� ��������� ����� �� ���������, ������������ ������� �����������, �� ����� ����� �������� ��������������,
/// ��� ������������ ������������ �����������, ����� ����������� ��������� = 3. ��� ��� ��������, � ���� �� ����, �� � �������� ������������ ���� ���������������.
/// ��������� ��� - ������� ��� ������� ������: 
/// 1) ����� ����� ������ ����, ����� ����� ��� ����������� ����� ��������;
// N%3==0 => N=3+..(N/3 ���)..+3 => MaxP=3*..(N/3 ���)..*3
/// 2) ����� ������� �� ������� = 1, �� 1 � ������������ �� ���� ��� ������, ������� ��� ������� ����� ������� � ��������� �������;
// N%3==1 => N=3+..(N/3 ���)..+3+1 = 3+..(N/3-1 ���)..+3+4 => MaxP=3*..(N/3-1 ���)..*3*4
/// 3) ����� ������� �� ������� = 2, �� �� � ������� ��������� ��������� � ����������
// N%3==2 => N=3+..(N/3 ���)..+3+2 => MaxP=3*..(N/3 ���)..*3*2

// ������ ���� ������� ������ � ������������� ��������� (���������) - �������� ������ �������� ��� �������� ������� � ���
const int derivatives_of_the_residue[3] = { 3, (3 + 1), 3 * 2 };

// ���� ������� ����� ��������� O(1)
unsigned long long split_summand_on_max_multipl(int n)
{
	// � ��������� ����� = 3^(N/3-1) * �������� �� ������� �� �������
	return static_cast<unsigned long long>(pow(3, n / 3 - 1) * derivatives_of_the_residue[n % 3]);
}

int main()
{
	// Tests
	std::cout << split_summand_on_max_multipl(4) << std::endl;		// Should be 4
	std::cout << split_summand_on_max_multipl(5) << std::endl;		// Should be 6
	std::cout << split_summand_on_max_multipl(6) << std::endl;		// Should be 9
	std::cout << split_summand_on_max_multipl(7) << std::endl;		// Should be 12
	std::cout << split_summand_on_max_multipl(8) << std::endl;		// Should be 18
	std::cout << split_summand_on_max_multipl(9) << std::endl;		// Should be 27
	std::cout << split_summand_on_max_multipl(10) << std::endl;		// Should be 36
	std::cout << split_summand_on_max_multipl(11) << std::endl;		// Should be 54
	std::cout << split_summand_on_max_multipl(12) << std::endl;		// Should be 81
	std::cout << split_summand_on_max_multipl(13) << std::endl;		// Should be 108
	std::cout << split_summand_on_max_multipl(14) << std::endl;		// Should be 162
	std::cout << split_summand_on_max_multipl(15) << std::endl;		// Should be 243
	std::cout << split_summand_on_max_multipl(16) << std::endl;		// Should be 324
	std::cout << split_summand_on_max_multipl(17) << std::endl;		// Should be 486
	std::cout << split_summand_on_max_multipl(18) << std::endl;		// Should be 729
	std::cout << split_summand_on_max_multipl(19) << std::endl;		// Should be 972
	std::cout << split_summand_on_max_multipl(20) << std::endl;		// Should be 1458
	// ...
	std::cout << split_summand_on_max_multipl(100) << std::endl;	// Should be 7412080755407364

	return 0;
}
