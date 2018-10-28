/*			01. ����� "������� ���� ��������� ��������� �����"			 */

#include <iostream>
// ����������� ������� ��� ��������.
// remainder_blocks - ���������� ���������� �� �������������� ������
// count �� ������ - ������� ��� �������� ��������� ���������
// used_blocks - ���������� ��� ������������ ������
// last_layer_lenght - ������ ���������� ������ � ���������� ���� ��������
void calc_top_layers(int remainder_blocks, unsigned long & count, int used_blocks, int last_layer_lenght)
{
	// ���� �������� �� ��������,
	if (remainder_blocks == 0)
		// ������ �������� ����� ������� �����������
		count++;
	else
		// �� ������� ���� ��������� �������� ������ ������� �� ����������� ���������� ���������� � ���������� ����� �����
		for (auto i = last_layer_lenght - 1; i > 0; --i)
			// ���� ����� ���������� ��� ������ ���� ��� �������� ������� (�����)
			if (remainder_blocks - i >= 0)
				// �� ������� ���������� ��������� ���������� ��������, ������� � ������� ������ (� �������� ����)
				calc_top_layers(remainder_blocks - i, count, used_blocks + i, i);
}

// ������� �������� ���������� ��������� ������� �� ������������� ���������� ������
unsigned long count_possible_pyramids(int count_blocks)
{
	// ������� ������� ��� �������� ��������� ���������� �������
	unsigned long count = 0;
	// � ������� ����������� �����
	calc_top_layers(count_blocks, count, 0, count_blocks + 1);
	// ��������� �������� ������
	return count;
}

int main()
{
	// Test from task
	std::cout << "N = 3; Answer = " << count_possible_pyramids(3) << std::endl;
	std::cout << "N = 5; Answer = " << count_possible_pyramids(5) << std::endl;
	std::cout << "N = 6; Answer = " << count_possible_pyramids(6) << std::endl;
	// Other tests
	std::cout << "N = 7; Answer = " << count_possible_pyramids(7) << std::endl;
	std::cout << "N = 8; Answer = " << count_possible_pyramids(8) << std::endl;
	std::cout << "N = 9; Answer = " << count_possible_pyramids(9) << std::endl;
	std::cout << "N = 10; Answer = " << count_possible_pyramids(10) << std::endl;
	std::cout << "N = 20; Answer = " << count_possible_pyramids(20) << std::endl;
	std::cout << "N = 30; Answer = " << count_possible_pyramids(30) << std::endl;
	std::cout << "N = 40; Answer = " << count_possible_pyramids(40) << std::endl;
	std::cout << "N = 50; Answer = " << count_possible_pyramids(50) << std::endl;
	std::cout << "N = 60; Answer = " << count_possible_pyramids(60) << std::endl;
	std::cout << "N = 70; Answer = " << count_possible_pyramids(70) << std::endl;
	std::cout << "N = 80; Answer = " << count_possible_pyramids(80) << std::endl;
	std::cout << "N = 90; Answer = " << count_possible_pyramids(90) << std::endl;
	std::cout << "N = 100; Answer = " << count_possible_pyramids(100) << std::endl;
	// Test from chat
	std::cout << "N = 42; Answer = " << count_possible_pyramids(42) << std::endl;
	return 0;
}
