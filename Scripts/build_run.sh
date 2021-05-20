#!/bin/bash
# Samuel Caron

bash ~/dashboard/Scripts/build.sh
ret=$?
if [ $ret -ne 0 ]; then
	exit 1;
fi

bash ~/dashboard/Scripts/run.sh
exit $?
