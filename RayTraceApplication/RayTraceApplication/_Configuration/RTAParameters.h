#pragma once

#include <string>

class RTAParameters
{
public:
	static int MaxFrames;
	static int ResolutionWidth;
	static int ResolutionHeight;
	static int FramesPerSecond;
	static int NumberOfThreads;
	
	static std::string RootOutputPath;
	static std::string ApplicationType;
	static std::string MP4OutputPath;
	static std::string PPMOutputPath;
	static std::string ReportPath;
	static std::string FilenameTemplate;

	static bool LoadParametersCSV(char* filename);
	static void DisplayParameters(void);
};