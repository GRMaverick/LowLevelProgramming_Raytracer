echo off
set arg1=%1

IF "%arg1%"=="baseline" (
    ECHO Launching Baseline Raytracer Application
)
IF "%arg1%"=="O2" (
    ECHO Launching Raytracer Application for MAXIMUM SPEED
)
IF "%arg1%"=="Ox" (
    ECHO Launching Raytracer Application with FULL OPTIMISATION
)
IF "%arg1%"=="Oy" (
    ECHO Launching Raytracer Application with FASTER METHOD CALLS
)