#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
	mi_ = nullptr;
	char current_char;
	ifstream war_area_map("data\\war_area.ini");
	if (war_area_map.is_open())
	{
		vector<char> line;
		do
		{
			war_area_map.get(current_char);
			if ((current_char == 'R') || (current_char == 'F'))
			{
				line.push_back(current_char);
			} else
			{
				if ((!line.empty()) || (current_char == EOF))
				{
					war_area_.push_back(line);
					line.clear();
				}
			}
			current_char = EOF;
		} while (!war_area_map.eof());
	}
	mi_ = new military_intelligence(position(0, 0), war_area_);
}

//--------------------------------------------------------------
void ofApp::update(){

}

//--------------------------------------------------------------
void ofApp::draw(){

}

//--------------------------------------------------------------
void ofApp::keyPressed(int key){
	switch (key)
	{
	case ' ':
		if (mi_ != nullptr)
		{
			if (mi_->next_step() == mission_complete)
			{
				auto report = mi_->get_report();
				cout << "FrontLine = " << report.front_line << "; PerimeterR = " << report.perimeter_R << "; PerimeterF = " << report.perimeter_F << endl;
				delete mi_;
				mi_ = nullptr;
			} else
			{
				auto pos = mi_->get_position();
				auto dir = mi_->get_direction();
				cout << "Checked pos(" << pos.x << "; " << pos.y << ") on direction " << dir << endl;
			}
		}
		break;
	default:;
	}
}

//--------------------------------------------------------------
void ofApp::keyReleased(int key){

}

//--------------------------------------------------------------
void ofApp::mouseMoved(int x, int y ){

}

//--------------------------------------------------------------
void ofApp::mouseDragged(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mousePressed(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mouseReleased(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mouseEntered(int x, int y){

}

//--------------------------------------------------------------
void ofApp::mouseExited(int x, int y){

}

//--------------------------------------------------------------
void ofApp::windowResized(int w, int h){

}

//--------------------------------------------------------------
void ofApp::gotMessage(ofMessage msg){

}

//--------------------------------------------------------------
void ofApp::dragEvent(ofDragInfo dragInfo){ 

}
