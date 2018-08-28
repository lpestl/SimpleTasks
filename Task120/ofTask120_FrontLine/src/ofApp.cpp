#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
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
	war_map_.setup(war_area_);
}

//--------------------------------------------------------------
void ofApp::update(){
	war_map_.update();
}

//--------------------------------------------------------------
void ofApp::draw(){
	ofBackgroundGradient(ofColor::orange, ofColor::blue);
	war_map_.draw();
}

//--------------------------------------------------------------
void ofApp::keyPressed(int key){
	switch (key)
	{
	case ' ':
		war_map_.next_step();
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
	war_map_.windowResized(w, h);
}

//--------------------------------------------------------------
void ofApp::gotMessage(ofMessage msg){

}

//--------------------------------------------------------------
void ofApp::dragEvent(ofDragInfo dragInfo){ 

}
