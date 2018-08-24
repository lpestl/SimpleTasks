#include <iostream>
#include <vector>

using namespace std;

// ��������� ��� ������ ������
struct front_line_data
{	
	unsigned int front_line;	// ����� ����� ������
	unsigned int perimeter_r;	// �������� R
	unsigned int perimeter_f;	// �������� F
};

// ��������� ����� ������ �� �������� �������
front_line_data get_front_line(vector<vector<char>> area)
{
	// ������� ���������� ��� �������� ������
	front_line_data result{};
	// ��������� �� ������ �� ������� ��������
	if (area.empty())
		return result;
	if (area[0].empty())
		return result;
	// ������� �� ������ ������ �������
	for (size_t i = 0; i < area.size(); ++i)
	{
		// � �� ������� �������
		for(size_t j = 0; j < area[i].size(); ++j)
		{
			// ������ �������� ��� �������� ��������� � ����� ������
			unsigned int perimeter = 0;
			unsigned int front_line = 0;
			// ���� ������� ������� ������� � ������ ������ - �� ���� ���� - ����� ���������
			if (i == 0) perimeter++;
			// ����� ���� ������� ������� ���������� �� ������ ������, �� ��� ����� ������
			else if (area[i][j] != area[i - 1][j]) front_line++;
			// ���� ������� ������� ��������� � ��������� ������ - �� ���� - ����� ���������
			if (i == area.size() - 1) perimeter++;
			// ����� ���� ������� ������� ���������� �� ������ ����� - �� ��� ����� ������
			else if (area[i][j] != area[i + 1][j]) front_line++;
			// �������� � �� ���������. ���� ����� ������ ������� - ��������, ����� ���� ���������� �� ������ ����� - �� ����� ������
			if (j == 0) perimeter++;
			else if (area[i][j] != area[i][j - 1]) front_line++;
			// ���� ����� ������ ������� - �� ��������, ����� ���� �� ����� ������ ������ - ����� ������
			if (j == area[i].size() - 1) perimeter++;
			else if (area[i][j] != area[i][j + 1]) front_line++;
			// ��������� ��� ������� �����������
			switch (area[i][j])
			{
			// ���� R, �� ��������� �� ����������� ��������
			case 'R':
				result.perimeter_r += perimeter;
				break;
			// ���� F, �� ������� �� ��������
			case 'F':
				result.perimeter_f += perimeter;
				break;
			default: ;
			}
			// � ����� ������ ����� ��� ����
			result.front_line += front_line;
		}
	}
	// ������ �������� ����� ��������� �� ����� ����� ������
	result.perimeter_r += result.front_line;
	result.perimeter_f += result.front_line;
	// � ������� ���������
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