#!/bin/bash
# Samuel Caron

cd ~/dashboard/DashboardIoT/
dotnet ./bin/Release/publish/DashboardIoT.dll
exit $?