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
	const vector<vector<int>> matrix{ {1,3,5}, {7,9,11}, {13,15,17} };
	auto answer = get_point_selles(matrix);
	for (auto value : answer)
		cout << value << "; ";
	cout << endl;

	return 0;
}