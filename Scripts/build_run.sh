#!/bin/bash
# Samuel Caron

bash ~/DashboardIoT/Scripts/build.sh
ret=$?
if [ $ret -ne 0 ]; then
	exit 1;
fi

bash ~/DashboardIoT/Scripts/run.sh
exit $?
