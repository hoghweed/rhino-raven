#!/bin/bash

SOLUTION_DIR=$(dirname "$(realpath "$0")")
SOLUTION_FILE="$SOLUTION_DIR/rhino-raven.sln"

# Build the solution
dotnet clean
dotnet build "$SOLUTION_FILE"

PLUGIN_OUTPUT_FOLDER="$SOLUTION_DIR/RhinoRaven/bin/Debug/net7.0"

# Determine the platform-specific Rhino executable path
if [ "$(uname)" == "Darwin" ]; then
    # macOS
    YAK_EXECUTABLE="/Applications/Rhino 8.app/Contents/Resources/bin/yak"
elif [ "$(expr substr $(uname -s) 1 10)" == "MINGW32_NT" ]; then
    # Windows
    YAK_EXECUTABLE="C:\\Program Files\\Rhino 8\\System\\yak.exe"
fi

cd $PLUGIN_OUTPUT_FOLDER
cp -r . $SOLUTION_DIR/distrib
cd $SOLUTION_DIR/distrib
"$YAK_EXECUTABLE" build --platform mac
"$YAK_EXECUTABLE" install ./rhinoraven-1.0.0-rh8_7-mac.yak
cd ..


