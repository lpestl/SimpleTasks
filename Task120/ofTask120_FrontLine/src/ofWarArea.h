#pragma once
#include "ofPoint.h"
#include "ofRectangle.h"
#include "MilitaryIntelligence.h"

struct cell
{
	char value;
	std::vector<neighbor_status> borders;
};

class ofWarArea
{
public:
	void setup(unsigned int width, unsigned int height);
	void update();
	void draw();
	void windowResized(int w, int h);
private:
	ofPoint logicSizeArea_;
	ofRectangle rectArea_;
	ofPoint cellSize_;
	std::vector<std::vector<cell>> area_;
	float betweenInterval_;
};

