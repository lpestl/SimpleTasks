#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <iterator>
//#include <Windows.h>

using namespace std;

vector<int> getDataFromString(string str);
vector<int> getCurrentWorth(const vector<int> &D, const vector<int> &C);
void sortByWorth(vector<int> &D, vector<int> &C, vector<int> &W);
void endOfDay(vector<int> &D, vector<int> &C);
//void printArrays(const vector<int> &D, const vector<int> &C, const vector<int> &W, int &result);

int main() {
	ifstream input("input.txt");
	ofstream output("output.txt", ios::out | ios::trunc);

	if (input.is_open()) {
		string temp;

		// ������ ������ �� �����
		getline(input, temp);
		// ���������� ������ � �������
		vector<int> Dk = getDataFromString(temp);
		
		getline(input, temp);
		// ���������� ������ � �������
		vector<int> Ck = getDataFromString(temp);
			
		// ����� �����, ���������� � ������
		int total = 0;

		// �� ��� ��� ���� � ��� ��� �������� �������������� �������
		while (Dk.size() > 0) {
			// ������� ����������� �������� ������
			vector<int> Wk = getCurrentWorth(Dk, Ck);
			// ��������� �� �������� ��������
			sortByWorth(Dk, Ck, Wk);

			//printArrays(Dk, Ck, Wk, total);
			
			// ������� ����� ������� �������
			total += Dk[0] * Ck[0];
			// ������� ������� (������� �� ��������)
			Dk.erase(Dk.begin());
			Ck.erase(Ck.begin());

			// ��������� ��������� ����
			endOfDay(Dk, Ck);

			//printArrays(Dk, Ck, Wk, total);
		}

		// ��������� - ������������ ������� � ����������
		output << total;
	}
	else {
		output << "[ERROR] Input file was not found\n";
	}

	//system("pause");
	return 0;
}

// �������� ������ � ������ �� ������
vector<int> getDataFromString(string str) {
	istringstream buffer(str);
	vector<int> data{ istream_iterator<int>(buffer),
		istream_iterator<int>() };

	return data;
}

// ������� �������� ������� � ������ ���������� ����
vector<int> getCurrentWorth(const vector<int> &D, const vector<int> &C) {
	vector<int> worth;
	for (auto i = 0; i < D.size(); ++i) {
		// �������� ������� ����� ���������� ��� * ��������� �� ���� ����� ������ �� ���� �� ����������� ������
		int currW = D[i] * C[i];
		for (auto j = 0; j < D.size(); ++j) {
			if (i != j) currW -= C[j];
		}
		worth.push_back(currW);
	}

	return worth;
}

// ��������� ������� �� �������� �������� ������
void sortByWorth(vector<int> &D, vector<int> &C, vector<int> &W) {
	for (auto i = 0; i < W.size(); ++i) {
		int max = W[i], n_max = i;
		// ����� ������� ������ (��������� O(n^2) - ����� ����� ����������)
		for (auto j = i; j < W.size(); ++j) {
			if (max < W[j]) {
				max = W[j];
				n_max = j;
			}
		}

		if (i != n_max) {
			swap(W[i], W[n_max]);
			swap(D[i], D[n_max]);
			swap(C[i], C[n_max]);
		}
	}
}

// ������� ������ ���� ��� � ����. ����� ���� ���������, ����� ��������� Dk � ���� ���������� �������
void endOfDay(vector<int> &D, vector<int> &C) {
	for (int i = D.size() - 1; i >= 0; --i) {
		// ��������� ���������� ��������� ���� � �������
		D[i]--;

		// ���� � ������� �� �������� ����, �� ��� "�������"
		if (D[i] == 0) {
			D.erase(D.begin() + i);
			C.erase(C.begin() + i);
		}
	}
}

//void printArrays(const vector<int> &D, const vector<int> &C, const vector<int> &W, const int &result) {
//	for (const auto &currD : D) {
//		cout << "\t" << currD;
//	}
//	cout << endl;
//	for (const auto &currC : C) {
//		cout << "\t" << currC;
//	}
//	cout << endl;
//	for (const auto &currW : W) {
//		cout << "\t" << currW;
//	}
//	cout << endl << "Total: " << result << endl;
//}