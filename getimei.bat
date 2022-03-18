@echo off
setlocal enabledelayedexpansion
for /f "tokens=6*" %%a in ('adb -s %1 shell "service call iphonesubinfo 1 ^| grep -m 1 \"'\""') do (
set imei1=%%a)
for /f "tokens=6*" %%b in ('adb -s %1 shell "service call iphonesubinfo 1 ^| grep -m 2 \"'\""') do (
set imei2=%%b)
for /f "tokens=4*" %%c in ('adb -s %1 shell "service call iphonesubinfo 1 ^| grep -m 3 \"'\""') do (
set imei3=%%c) 
set imei=!imei1!!imei2!!imei3!
echo !imei! > imei.txt
for /f "delims=" %%d in (imei.txt) do (
set DeviceIMEI=%%d
set DeviceIMEI=!DeviceIMEI:'=!
set DeviceIMEI=!DeviceIMEI:.=!
set OIMEI=!DeviceIMEI!
) 
echo %OIMEI%>> imeis.txt
del imei.txt