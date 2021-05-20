#!/bin/bash
# Samuel Caron

cd ~/DashboardIoT
git pull

dotnet publish ./DashboardIoT/DashboardIoT.sln -c Release -o ./DashboardIoT/bin/Release/publish/

exit $?