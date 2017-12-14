#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <iterator>
#include <Windows.h>

using namespace std;

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

		for (auto& line : tArray)
		{ 
			for (auto& t : line) 
			{
				cout << t << " ";
			}
			cout << endl;
		}
	}
	else {
		output << "[ERROR] Input file was not found\n";
	}

	system("pause");
	return 0;
}