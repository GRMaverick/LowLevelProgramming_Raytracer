@echo off
set arg1=%1

if %arg1%==preview RTA_Deliverable\Debug\RayTraceApplication_Debug.exe preview
if %arg1%==baseline RTA_Deliverable\Debug_Baseline\RayTraceApplication_Debug_Baseline.exe
if %arg1%==O2 RTA_Deliverable\Debug_O2\RayTraceApplication_Debug_O2.exe 
if %arg1%==Ox RTA_Deliverable\Debug_OX\RayTraceApplication_Debug_OX.exe 
if %arg1%==Oy RTA_Deliverable\Debug_OY\RayTraceApplication_Debug_OY.exe 

ECHO Done.