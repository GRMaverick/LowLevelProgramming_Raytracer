#include <fstream>
#include <sstream>
#include <iostream>
#include <algorithm>

#include "Defines.h"
#include "Tracing.h"
#include "Rendering.h"
#include "RTAParameters.h"

float Renderer::Angle = 0.0f;
float Renderer::FieldOfView = 0.0f;
float Renderer::AspectRatio = 0.0f;
float Renderer::InverseWidth = 0.0f;
float Renderer::InverseHeight = 0.0f;

void Renderer::Render(const std::vector<Sphere*>& spheres, int iteration)
{
	unsigned width = RTAParameters::ResolutionWidth;
	unsigned height = RTAParameters::ResolutionHeight;

	Vector3* image = new Vector3[width * height];
	Vector3* pixel = image;

	float invWidth = 1 / float(width);
	float invHeight = 1 / float(height);
	float fov = 30;
	float aspectratio = width / float(height);
	float angle = tan(M_PI * 0.5 * fov / 180.0);

	// Trace rays
	for (unsigned y = 0; y < height; ++y)
	{
		for (unsigned x = 0; x < width; ++x, ++pixel)
		{
			float xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
			float yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;

			Vector3 raydir = Vector3(xx, yy, -1).Normalise();

			*pixel = Tracing::Trace(Vector3(0), raydir, spheres, 0);
		}
	}

	// Save result to a PPM image (keep these flags if you compile under Windows)
	std::stringstream ss;
	ss << RTAParameters::PPMOutputPath << RTAParameters::FilenameTemplate << iteration << ".ppm";
	std::string tempString = ss.str();
	char* filename = (char*)tempString.c_str();

	std::ofstream ofs(filename, std::ios::out | std::ios::binary);
	ofs << "P6\n" << width << " " << height << "\n255\n";
	for (unsigned i = 0; i < width * height; ++i)
	{
		ofs << (unsigned char)(std::min(float(1), image[i].x) * 255) << (unsigned char)(std::min(float(1), image[i].y) * 255) << (unsigned char)(std::min(float(1), image[i].z) * 255);
	}

	ofs.close();

	delete[] image;
}
void Renderer::Render(Sphere* spheres[], int sphereCount, int iteration)
{
	unsigned width = RTAParameters::ResolutionWidth;
	unsigned height = RTAParameters::ResolutionHeight;

	Vector3* image = new Vector3[width * height];
	Vector3* pixel = image;

	float invWidth = 1 / float(width);
	float invHeight = 1 / float(height);
	float fov = 30;
	float aspectratio = width / float(height);
	float angle = tan(M_PI * 0.5 * fov / 180.0);

	// Trace rays
	for (unsigned y = 0; y < height; ++y)
	{
		for (unsigned x = 0; x < width; ++x, ++pixel)
		{
			float xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
			float yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;

			Vector3 raydir = Vector3(xx, yy, -1).Normalise();

			*pixel = Tracing::Trace(Vector3(0), raydir, spheres, sphereCount, 0);
		}
	}

	// Save result to a PPM image (keep these flags if you compile under Windows)
	std::string fileString = RTAParameters::PPMOutputPath + RTAParameters::FilenameTemplate + std::to_string(iteration) + ".ppm";

	std::ofstream ofs(fileString.c_str(), std::ios::out | std::ios::binary);
	if (ofs.is_open())
	{
		ofs << "P6\n" << width << " " << height << "\n255\n";
		for (unsigned i = 0; i < width * height; ++i)
		{
			ofs << (unsigned char)(std::min(float(1), image[i].x) * 255) << (unsigned char)(std::min(float(1), image[i].y) * 255) << (unsigned char)(std::min(float(1), image[i].z) * 255);
		}

		ofs.close();
	}
	else
	{
		std::cout << fileString.c_str() << ": File IO FAILED!" << std::endl;
	}

	delete[] image;
}

void Renderer::ParallelRender(Sphere* spheres[], int sphereCount, int iteration, int threads)
{
	Vector3* image = new Vector3[RTAParameters::ResolutionWidth * RTAParameters::ResolutionHeight];
	Vector3* pixel = image;

	InverseWidth = 1 / float(RTAParameters::ResolutionWidth);
	InverseHeight = 1 / float(RTAParameters::ResolutionHeight);
	FieldOfView = 30;
	AspectRatio = RTAParameters::ResolutionWidth / float(RTAParameters::ResolutionHeight);
	Angle = tan(M_PI * 0.5 * FieldOfView / 180.0);
	
	int startHeight = 0;
	int heightPerThread = (RTAParameters::ResolutionHeight) / threads;
	
	std::thread* threadArray = new std::thread[threads - 1];
	for (int thread = 0; thread < threads - 1; thread++)
	{
		int endHeight = startHeight + heightPerThread;
		threadArray[thread] = std::thread(RenderThread, thread+1, startHeight, endHeight, pixel, spheres, sphereCount);

		startHeight = endHeight;
	}

#ifdef _DEBUG
	std::cout << "Parent Render Method!" << std::endl;
	std::cout << "Parent Start Element: " << startHeight << std::endl;
	std::cout << "Parent End Element: " << startHeight + heightPerThread << std::endl << std::endl;
#endif

	for (unsigned y = 0; y < RTAParameters::ResolutionHeight; ++y)
	{
		for (unsigned x = 0; x < RTAParameters::ResolutionWidth; ++x, ++pixel)
		{
			if (y >= startHeight && y < startHeight + heightPerThread)
			{
				float xx = (2 * ((x + 0.5) * InverseWidth) - 1) * Angle * AspectRatio;
				float yy = (1 - 2 * ((y + 0.5) * InverseHeight)) * Angle;

				Vector3 raydir = Vector3(xx, yy, -1).Normalise();

				*pixel = Tracing::Trace(Vector3(0), raydir, spheres, sphereCount, 0);
			}
		}
	}

	for (int thread = 0; thread < threads - 1; thread++)
	{
		threadArray[thread].join();
	}

	// Save result to a PPM image (keep these flags if you compile under Windows)
	std::string fileString = RTAParameters::PPMOutputPath + RTAParameters::FilenameTemplate + std::to_string(iteration) + ".ppm";

	std::ofstream ofs(fileString.c_str(), std::ios::out | std::ios::binary);
	if (ofs.is_open())
	{
		ofs << "P6\n" << RTAParameters::ResolutionWidth << " " << RTAParameters::ResolutionHeight << "\n255\n";
		for (unsigned i = 0; i < RTAParameters::ResolutionWidth * RTAParameters::ResolutionHeight; ++i)
		{
			ofs << (unsigned char)(std::min(float(1), image[i].x) * 255) << (unsigned char)(std::min(float(1), image[i].y) * 255) << (unsigned char)(std::min(float(1), image[i].z) * 255);
		}

		ofs.close();
	}
	else
	{
		std::cout << fileString.c_str() << ": File IO FAILED!" << std::endl;
	}

	delete[] image;
}
void Renderer::RenderThread(int threadID, int start, int end, Vector3* pixel, Sphere* spheres[], int sphereCount)
{
#ifdef _DEBUG
	std::cout << "Render Thread: " << threadID << std::endl;
	std::cout << "Start Element: " << start << std::endl;
	std::cout << "End Element: " << end << std::endl << std::endl;
#endif
	
	for (unsigned y = 0; y < RTAParameters::ResolutionHeight; ++y)
	{
		for (unsigned x = 0; x < RTAParameters::ResolutionWidth; ++x, ++pixel)
		{
			if (y >= start && y < end)
			{
				float xx = (2 * ((x + 0.5) * InverseWidth) - 1) * Angle * AspectRatio;
				float yy = (1 - 2 * ((y + 0.5) * InverseHeight)) * Angle;

				Vector3 raydir = Vector3(xx, yy, -1).Normalise();

				*pixel = Tracing::Trace(Vector3(0), raydir, spheres, sphereCount, 0);
			}
		}
	}
}
