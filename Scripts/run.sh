#!/bin/bash
# Samuel Caron

cd ~/Dashboard-IoT/DashboardIoT/
dotnet ./bin/Release/publish/DashboardIoT.dll
exit $?