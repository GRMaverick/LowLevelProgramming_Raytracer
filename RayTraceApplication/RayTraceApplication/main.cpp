#include <iostream>

#include "Timer.h"
#include "AppManager.h"
#include "BaseApplication.h"
#include "MemoryPoolManager.h"

void CleanupManagers()
{
	MemoryPoolManager* pMemManager = MemoryPoolManager::Instance();
	delete pMemManager;

	AppManager* pAppManager = AppManager::Instance();
	delete pAppManager;
}

int main(int argc, char** argv)
{
	selection:
		std::cout << "Low Level Programming - Raytracing Assignment" << std::endl;
		std::cout << "Select Option: " << std::endl;
		std::cout << "[1] :- Sequential Static Application" << std::endl;
		std::cout << "[2] :- Sequential Static Application [Bounding Volume]" << std::endl;
		std::cout << "[3] :- Sequential Physics Application" << std::endl;
		std::cout << "[4] :- Sequential Physics Application [Bounding Volume]" << std::endl;
		std::cout << "[5] :- Parallel Static Application" << std::endl;
		std::cout << "[6] :- Parallel Static Application [Bounding Volume]" << std::endl;
		std::cout << "[7] :- Parallel Physics Application" << std::endl;
		std::cout << "[8] :- Parallel Physics Application [Bounding Volume]" << std::endl;
		std::cout << "[9] :- Dummy Application" << std::endl;
		std::cout << "[0] :- Exit" << std::endl;

		int selection = -1;
		std::cin >> selection;

		if (selection != 0)
		{
			BaseApplication* application = AppManager::Instance()->GetApplication(selection);

			if (!application)
				goto selection;

			application->Run();

			delete application;

			goto selection;
		}
		else
		{
			MemoryPoolManager::Instance()->GenerateReport();

			CleanupManagers();

			std::system("pause");
			return 0;
		}
}