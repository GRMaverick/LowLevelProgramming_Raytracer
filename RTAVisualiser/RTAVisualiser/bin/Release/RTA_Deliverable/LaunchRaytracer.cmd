@echo off
set arg1=%1

if %arg1%==preview RTA_Deliverable\Release\RayTraceApplication_Release.exe preview
if %arg1%==baseline RTA_Deliverable\Release_Baseline\RayTraceApplication_Release_Baseline.exe
if %arg1%==O2 RTA_Deliverable\Release_O2\RayTraceApplication_Release_O2.exe 
if %arg1%==Ox RTA_Deliverable\Release_OX\RayTraceApplication_Release_OX.exe 
if %arg1%==Oy RTA_Deliverable\Release_OY\RayTraceApplication_Release_OY.exe 

ECHO Done.