#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <iterator>
//#include <Windows.h>

#define MAX(a,b) (((a)>(b))?(a):(b))

using namespace std;

void distribute(vector<vector<int>> &tArray) {
	int back = 0, front = tArray[0].size();

	while (back < front) {
		// Find local min
		int indexMin = back, j = 0, min = tArray[j][indexMin];

		for (auto i = back; i < front; ++i) {
			for (auto l = 0; l < tArray.size(); ++l) {
				if (min > tArray[l][i]) {
					min = tArray[l][i];
					indexMin = i;
					j = l;
				}
			}
		}

		switch (j)
		{
		case 0:
			swap(tArray[0][back], tArray[0][indexMin]);
			swap(tArray[1][back], tArray[1][indexMin]);
			back++;
			break;
		case 1:
			swap(tArray[0][front-1], tArray[0][indexMin]);
			swap(tArray[1][front-1], tArray[1][indexMin]);
			front--;
			break;
		default:
			cout << "[WARNING] Something is wrong. j - went beyond the array." << endl;
			break;
		}
	}
}

int getMinTime(vector<vector<int>> &tArray) {
	int totalTime = tArray[0][0];

	for (auto i = 0; i < tArray[0].size() - 1; ++i) {
		totalTime +=  MAX(tArray[1][i], tArray[0][i + 1]);
	}

	totalTime += tArray[1][tArray[0].size() - 1];

	return totalTime;
}

int main() {
	ifstream input("input.txt");
	ofstream output("output.txt", ios::out | ios::trunc);
	
	if (input.is_open()) {
		vector<vector<int>> tArray;

		std::string temp;

		while (std::getline(input, temp)) {
			std::istringstream buffer(temp);
			std::vector<int> line { istream_iterator<int>(buffer),
									   istream_iterator<int>() };

			tArray.push_back(line);
		}

		distribute(tArray);
		output << getMinTime(tArray);
	}
	else {
		output << "[ERROR] Input file was not found\n";
	}

	//system("pause");
	return 0;
}