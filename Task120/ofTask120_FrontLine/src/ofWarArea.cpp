#include "ofWarArea.h"
#include "ofMesh.h"
#include "ofBitmapFont.h"

void ofWarArea::setup(unsigned width, unsigned height)
{
	logicSizeArea_.x = width;
	logicSizeArea_.y = height;

	for (auto i = 0; i < logicSizeArea_.y; ++i)
	{
		std::vector<cell> line;
		for (auto j = 0; j < logicSizeArea_.x; ++j)
		{
			cell curCell;
			curCell.value = ' ';
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			line.push_back(curCell);
		}
		area_.push_back(line);
	}

	auto winWidth = ofGetWindowWidth();
	auto winHeight = ofGetWindowHeight();
	windowResized(winWidth, winHeight);
}

void ofWarArea::update()
{
}

void ofWarArea::draw()
{
	ofSetColor(127, 127, 127);
	ofDrawRectangle(rectArea_);
}

void ofWarArea::windowResized(int w, int h)
{
	ofPoint size(w / logicSizeArea_.x, h / logicSizeArea_.y);
	if (size.x < size.y)
	{
		cellSize_.x = size.x / 6 * 5;
		betweenInterval_ = size.x / 6;
		cellSize_.y = cellSize_.x;
		rectArea_.width = w;
		rectArea_.height = cellSize_.y * logicSizeArea_.y;
	} else
	{
		cellSize_.y = size.y / 6 * 5;
		betweenInterval_ = size.y / 6;
		cellSize_.x = cellSize_.y;
		rectArea_.height = h;
		rectArea_.width = cellSize_.x * logicSizeArea_.x;
	}
	rectArea_.x = w / 2 - rectArea_.width / 2;
	rectArea_.y = h / 2 - rectArea_.height / 2;
}

