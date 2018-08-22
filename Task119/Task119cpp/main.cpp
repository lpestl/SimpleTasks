#include <iostream>
#include <vector>

using namespace std;

struct point
{
	int value;
	int i_index;
	int j_index;

	point(int v, int i, int j): value(v), i_index(i), j_index(j) {}
};

vector<int> get_point_selles(vector<vector<int>> matrix)
{
	vector<int> point_selles;
	

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