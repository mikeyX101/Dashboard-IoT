#!/bin/bash
# Samuel Caron

cd ~/DashboardIoT/DashboardIoT/
dotnet ./bin/Release/publish/DashboardIoT.dll
exit $?