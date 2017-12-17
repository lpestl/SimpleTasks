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
void printArrays(const vector<int> &D, const vector<int> &C, const vector<int> &W, int &result);

int main() {
	ifstream input("input.txt");
	ofstream output("output.txt", ios::out | ios::trunc);

	if (input.is_open()) {
		string temp;

		// Читаем данные из файла
		getline(input, temp);
		// записываем данные в массивы
		vector<int> Dk = getDataFromString(temp);
		
		getline(input, temp);
		// записываем данные в массивы
		vector<int> Ck = getDataFromString(temp);
			
		// Общая сумма, вырученная с продаж
		int total = 0;

		// До тех пор пока у нас еще остались нераспроданные путевки
		while (Dk.size() > 0) {
			// Считаем сегодняшнюю ценность путёвок
			vector<int> Wk = getCurrentWorth(Dk, Ck);
			// Сортируем по убыванию ценности
			sortByWorth(Dk, Ck, Wk);

			//printArrays(Dk, Ck, Wk, total);
			
			// Продаем самую дорогую путевку
			total += Dk[0] * Ck[0];
			// Путевка продана (удаляем из массивов)
			Dk.erase(Dk.begin());
			Ck.erase(Ck.begin());

			// Наступает следующий день
			endOfDay(Dk, Ck);

			//printArrays(Dk, Ck, Wk, total);
		}

		// результат - максимальная прибыль с реализации
		output << total;
	}
	else {
		output << "[ERROR] Input file was not found\n";
	}

	//system("pause");
	return 0;
}

// Получить данные в массив из строки
vector<int> getDataFromString(string str) {
	istringstream buffer(str);
	vector<int> data{ istream_iterator<int>(buffer),
		istream_iterator<int>() };

	return data;
}

// Считаем ценность путевок с учетом оставшихся дней
vector<int> getCurrentWorth(const vector<int> &D, const vector<int> &C) {
	vector<int> worth;
	for (auto i = 0; i < D.size(); ++i) {
		// Ценность путевки равна ОСТАВШИЕСЯ ДНИ * СТОИМОСТЬ ЗА ДЕНЬ минус убытки за день от непроданных путёвок
		int currW = D[i] * C[i];
		for (auto j = 0; j < D.size(); ++j) {
			if (i != j) currW -= C[j];
		}
		worth.push_back(currW);
	}

	return worth;
}

// Сортируем массивы по убыванию ценности путёвки
void sortByWorth(vector<int> &D, vector<int> &C, vector<int> &W) {
	for (auto i = 0; i < W.size(); ++i) {
		int max = W[i], n_max = i;
		// Метод прямого выбора (Сложность O(n^2) - можно более оптимально)
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

// Продажа путёвок один раз в день. Когда день кончается, нужно уменьшить Dk у всех оставшихся путевок
void endOfDay(vector<int> &D, vector<int> &C) {
	for (int i = D.size() - 1; i >= 0; --i) {
		// уменьшаем количество оствшихся дней у путевки
		D[i]--;

		// если у путевки не осталось дней, то она "сгорает"
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