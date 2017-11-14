#include <fstream>
#include <iostream>
#include <Windows.h>

#include "Timer.h"
#include "RTAParameters.h"

void Timer::Start(void)
{
	m_StartTime = std::chrono::steady_clock::now();
	m_EndTime = m_StartTime;
	m_LastLap = m_StartTime;

	m_TrackingIds = std::vector<std::string>();
	m_FrameTimes = std::map<std::string, double>();
	m_TrackingEnds = std::map<std::string, std::chrono::steady_clock::time_point	>();
	m_TrackingStarts = std::map<std::string, std::chrono::steady_clock::time_point	>();

	m_LastLap = std::chrono::steady_clock::now();
	m_EndTime = std::chrono::steady_clock::now();
	m_StartTime = std::chrono::steady_clock::now();
}
void Timer::Stop(void)
{
	m_EndTime = std::chrono::steady_clock::now();
	m_LastLap = m_EndTime;
}
void Timer::Reset(void)
{
	m_StartTime = std::chrono::steady_clock::now();
	m_EndTime = m_StartTime;
	m_LastLap = m_StartTime;

	m_TrackingIds.clear();
	m_TrackingEnds.clear();
	m_TrackingStarts.clear();
}

void Timer::StartTracking(std::string name)
{
	m_TrackingIds.push_back(name);

	auto finder = m_TrackingStarts.find(name);
	if (finder == m_TrackingStarts.end())
	{
		m_TrackingStarts[name] = std::chrono::steady_clock::now();
	}
	else
	{
#ifdef _DEBUG
		std::cout << "Tracking for ID: " << name.c_str() << " already in progress - Resetting tracking!" << std::endl;
#endif
		m_TrackingStarts[name] = std::chrono::steady_clock::now();
	}
}
void Timer::EndTracking(std::string name)
{
	auto finder = m_TrackingStarts.find(name);
	if (finder == m_TrackingStarts.end())
	{
#ifdef _DEBUG
		std::cout << "No tracking for ID: " << name.c_str() << " in progress - Ignoring!" << std::endl;
#endif
		m_TrackingStarts[name] = std::chrono::steady_clock::now();
	}
	else
	{
		auto finder = m_TrackingEnds.find(name);
		if (finder == m_TrackingEnds.end())
		{
			m_TrackingEnds[name] = std::chrono::steady_clock::now();
		}
		else
		{
#ifdef _DEBUG
			std::cout << "Tracking completed for ID: " << name.c_str() << " - Overwriting last entry!" << std::endl;
#endif
			m_TrackingEnds[name] = std::chrono::steady_clock::now();
		}
	}
}

void Timer::GenerateReport(void)
{
	for (std::string s : m_TrackingIds)
	{
		auto start = m_TrackingStarts.find(s);
		auto end = m_TrackingEnds.find(s);

		if (start == m_TrackingStarts.end())
		{
#ifdef _DEBUG
			std::cout << "No Start Time for " << s.c_str() << " recorded - skipping frame!" << std::endl;
#endif
			continue;
		}

		if (end == m_TrackingEnds.end())
		{
#ifdef _DEBUG
			std::cout << "No End Time for " << s.c_str() << " recorded - skipping frame!" << std::endl;
#endif
			continue;
		}

		std::chrono::duration<double, std::milli> ms = end->second - start->second;

		auto duration = m_FrameTimes.find(s);
		if (duration == m_FrameTimes.end())
		{
			m_FrameTimes[s] = ms.count();
		}
		else
		{
#ifdef _DEBUG
			std::cout << "Duration calculated for ID: " << s.c_str() << " - Overwriting last entry!" << std::endl;
#endif
			m_FrameTimes[s] = ms.count();
		}
	}

	for (auto it = m_FrameTimes.begin(); it != m_FrameTimes.end(); it++)
	{
#ifdef _DEBUG
		std::cout << it->first.c_str() << ": Time taken - " << it->second << " milliseconds" << std::endl;
#endif
	}
}
void Timer::ExportReport(void)
{
	Timer::GenerateReport();
	std::ofstream ofs(std::string(RTAParameters::ReportPath + "Timings.csv").c_str(), std::ofstream::out);
	if (ofs.is_open())
	{
		ofs << "NAME\tDURATION" << std::endl;
		for (auto it = m_FrameTimes.begin(); it != m_FrameTimes.end(); it++)
		{
			ofs << it->first.c_str() << "\t" << it->second << std::endl;
		}
		ofs.close();
	}
	else
	{
		std::cout << std::string(RTAParameters::ReportPath + "Timings.csv").c_str() << ": File IO FAILED!" << std::endl;
		return;
	}
}