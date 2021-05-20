#!/bin/bash
# Samuel Caron

bash ~/Dashboard-IoT/Scripts/build.sh
ret=$?
if [ $ret -ne 0 ]; then
	exit 1;
fi

bash ~/Dashboard-IoT/Scripts/run.sh
exit $?
