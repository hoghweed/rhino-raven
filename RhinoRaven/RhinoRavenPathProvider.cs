using System;
using System.IO;
using System.Reflection;

namespace RhinoRaven;

public static class RhinoRavenPathProvider
{
    public static string ExecutingPluginPath => Path.GetDirectoryName(Assembly.GetAssembly(typeof(RhinoRavenPlugin)).Location);
}

