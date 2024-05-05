#!/bin/bash

# Determine the platform-specific Rhino executable path
if [ "$(uname)" == "Darwin" ]; then
    # macOS
    YAK_EXECUTABLE="/Applications/Rhino 8.app/Contents/Resources/bin/yak"
elif [ "$(expr substr $(uname -s) 1 10)" == "MINGW32_NT" ]; then
    # Windows
    YAK_EXECUTABLE="C:\\Program Files\\Rhino 8\\System\\yak.exe"
fi

# Run Rhino with the appropriate command line to uninstall the plugin
"$YAK_EXECUTABLE" uninstall RhinoRaven
