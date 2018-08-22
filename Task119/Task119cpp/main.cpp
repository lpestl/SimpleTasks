#include <iostream>
#include <vector>

using namespace std;

struct point
{
	int value;
	vector<int> indexes;

	point(int v): value(v) {}
};

vector<int> get_point_selles(vector<vector<int>> matrix)
{
	vector<int> point_selles;
	vector<point> maxs;
	maxs.reserve(matrix[0].size());
	for (auto j : matrix[0])
		maxs.emplace_back(point(j));

	vector<point> mins;
	mins.reserve(matrix.size());

	for(auto i = 0; i < matrix.size(); ++i)
	{
		mins.emplace_back(point(matrix[i][0]));
		for(auto j = 0; j < matrix[i].size(); ++j)
		{
			if (matrix[i][j] == maxs[j].value)
				maxs[j].indexes.emplace_back(i);
			else 
				if (matrix[i][j] > maxs[j].value) 
				{
					maxs[j] = point(matrix[i][j]);
					maxs[j].indexes.emplace_back(i);
				}

			if (matrix[i][j] == mins[i].value)
				mins[i].indexes.emplace_back(j);
			else
				if (matrix[i][j] < mins[i].value)
				{
					mins[i] = point(matrix[i][j]);
					mins[i].indexes.emplace_back(j);
				}
		}
	}

	for (auto i = 0; i < matrix.size(); ++i)
	{
		cout << "Min for " << i << " row = " << mins[i].value << " and have columns indexes { ";
		for (auto index : mins[i].indexes)
			cout << index << "; ";
		cout << "} " << endl;
	}

	for (auto j = 0; j < matrix[0].size(); ++j)
	{
		cout << "Max for " << j << " column = " << maxs[j].value << " and have rows indexes { ";
		for (auto index : maxs[j].indexes)
			cout << index << "; ";
		cout << "} " << endl;
	}



	return point_selles;
}

int main()
{
	// Test 1: from task
	const vector<vector<int>> matrix1{ {1,3,5}, {7,9,11}, {13,15,17} };
	auto answer1 = get_point_selles(matrix1);
	// Should Be 13
	for (auto value : answer1)
		cout << value << "; ";
	cout << endl;

	// Test 2: from wiki https://ru.wikipedia.org/wiki/%D0%A1%D0%B5%D0%B4%D0%BB%D0%BE%D0%B2%D0%BE%D0%B9_%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82_%D0%BC%D0%B0%D1%82%D1%80%D0%B8%D1%86%D1%8B
	const vector<vector<int>> matrix2{ {5, 6, 4, 5}, {-2, 5, 3, 7}, {8, 7, -2, 6} };
	auto answer2 = get_point_selles(matrix2);
	// Should Be 4
	for (auto value : answer2)
		cout << value << "; ";
	cout << endl;

	// Test 3: from wiki
	const vector<vector<int>> matrix3{ {2, 3, 5, 2}, {2, 4, 6, 2}, {-2, 7, 2, 0} };
	auto answer3 = get_point_selles(matrix3);
	// Should Be 2; 2; 2; 2;
	for (auto value : answer3)
		cout << value << "; ";
	cout << endl;

	// Test 4: from wiki
	const vector<vector<int>> matrix4{ {3, 2, 1}, {1, 3, 4} };
	auto answer4 = get_point_selles(matrix4);
	// Should Be empty
	for (auto value : answer4)
		cout << value << "; ";
	cout << endl;

	// Test 5: from wiki
	const vector<vector<int>> matrix5{ {1, 1}, {1, 1} };
	auto answer5 = get_point_selles(matrix5);
	// Should Be 1; 1; 1; 1;
	for (auto value : answer5)
		cout << value << "; ";
	cout << endl;

	return 0;
}