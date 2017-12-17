#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <iterator>
//#include <Windows.h>

using namespace std;

vector<int> getDataFromString(string str) {
	istringstream buffer(str);
	vector<int> data{ istream_iterator<int>(buffer),
					istream_iterator<int>() };

	return data;
}

vector<int> getCurrentWorth(const vector<int> &D, const vector<int> &C) {
	vector<int> worth;
	for (auto i = 0; i < D.size(); ++i) {
		worth.push_back(D[i] * C[i]);
	}

	return worth;
}

void sortByWorth(vector<int> &D, vector<int> &C, vector<int> &W) {
	for (auto i = 0; i < W.size(); ++i) {
		int max = W[i], n_max = i;
		for (auto j = i; j < W.size(); ++j) {
			if (max < W[j]) {
				max = W[j];
				n_max = j;
			}
		}

		swap(W[i], W[n_max]);
		swap(D[i], D[n_max]);
		swap(C[i], C[n_max]);
	}
}

void endOfDay(vector<int> &D, vector<int> &C) {
	for (int i = D.size() - 1; i >= 0; --i) {
		D[i]--;

		if (D[i] <= 0) {
			D.erase(D.begin() + i);
			C.erase(C.begin() + i);
		}
	}
}

int main() {
	ifstream input("input.txt");
	ofstream output("output.txt", ios::out | ios::trunc);

	if (input.is_open()) {
		string temp;

		getline(input, temp);
		vector<int> Dk = getDataFromString(temp);
		
		getline(input, temp);
		istringstream buffer(temp);
		vector<int> Ck = getDataFromString(temp);
			
		int total = 0;
		while (Dk.size() > 0) {
			vector<int> Wk = getCurrentWorth(Dk, Ck);
			sortByWorth(Dk, Ck, Wk);

			// Sell
			total += Wk[0];
			Dk[0]--;

			endOfDay(Dk, Ck);
		}

		output << total;
	}
	else {
		output << "[ERROR] Input file was not found\n";
	}

	//system("pause");
	return 0;
}