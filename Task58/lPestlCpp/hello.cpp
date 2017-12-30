/*
	lPestl

	Эта программа написана как сопровождение или переходный этап к написанию программы на Basic на ZX Spectrum 48K
	Каждая строка из Basic программы имеет аналог в этом С++ коде и отмечена в комментариях
*/

// 10 REM Task58 "Formula 1"
#include <iostream>
#include <math.h>

using namespace std;

float getMinTime(float D, float V, float A[], int sizeA, float B[], int sizeB);

int main()
{
	// 20 LET D=100
	float D = 100;
	// 30 LET V=5
	float V = 5;
	// 35 LET S = 3
	float S = 3;

	// 40 DIM A(S): DIM B(S)
	// 50 READ A(1), A(2), A(3) : DATA 5, 5, 5
	// 60 READ B(1), B(2), B(3) : DATA 3, 3, 3
	float A[] = {5,5,5};
	float B[] = {3,3,3};
	
	// 70 GO TO 1000
	auto X = getMinTime(D, V, A, S, B, S);
	// 80 PRINT X
	cout << X << endl;

	system("pause");
	// 90 GO TO 9999
	// 9999 REM End programm
	return 0;
}

// 1000 REM Calculate Min time
float getMinTime(float D, float V,	float A[], int sizeA, float B[], int sizeB) {
	// 1010 LET U=2^S
	int size = pow(2, sizeA);
	// 1020 DIM T(U)
	float* times = new float[size];

	// 1030 FOR I=1 TO U
	for (int i = 0; i < size; ++i) {
		// 1040 DIM K(S)
		int *kArr = new int[sizeA];
		
		// 1050 FOR J=1 TO S
		for (int l = 0; l < sizeA; ++l) {
			// 1060 LET K(J)=0
			kArr[l] = 0;
			// 1070 NEXT J
		}

		// 1080 LET J=1
		int index = 0;
		// 1090 LET Q=I-1
		int Q = i;
		int o;
		do {
			// 1100 LET O=Q-(INT (Q/2) + INT (Q/2))
			o = Q % 2;
			// 1110 LET Q = INT(Q / 2)
			Q = Q / 2;
			// 1115 LET K(J)=O
			kArr[index] = o;
			// 1120 LET J=J+1
			index++;
		// 1130 IF Q<>0 THEN GO TO 1100
		} while (Q != 0);

		// 1140 LET W=0
		float W = 0; // sum Vi
		// 1150 LET R=0
		float R = 0; // sum Ti
		// 1160 FOR J=1 TO S
		for (int j = 0; j < sizeA; ++j) {
			//cout << kArr[j] << "\t";
			
			// 1170 LET W = W + A(J)*K(J)
			W += A[j] * kArr[j];
			// 1180 LET R=R+B(J)*K(J)
			R += B[j] * kArr[j];
		// 1190 NEXT J
		}

		// 1200 LET T(I)=D/(V+W)+R
		times[i] = D / (V + W) + R;
		// 1205 PRINT T(I)
		cout << times[i] << endl;

		delete[] kArr;
		// 1210 NEXT I
	}

	// 1220 LET X=T(1)
	float min = times[0];
	// 1230 FOR I=1 TO U
	for (int i = 0; i < size; ++i) {
		// 1240 IF X>T(I) THEN LET X=T(I)
		if (min > times[i]) min = times[i];
		// 1250 NEXT I
	}

	delete[] times;

	// 1255 PRINT "------------------------------": PRINT "Answer: "
	cout << "------------------------------" << endl << "Answer: ";
	// 1260 GO TO 80
	return min;
}
