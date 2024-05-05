using System;
using System.IO;
using System.Reflection;

namespace RhinoRaven;

public static class RhinoRavenPathProvider
{
    private static string UserDataPathEnvVar => "RAVEN_USERDATA_PATH";

    private static string? Path => Environment.GetEnvironmentVariable(UserDataPathEnvVar);

    public static string ExecutingPluginPath => System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(RhinoRavenPlugin)).Location);

    /// <summary>
    /// Get the installation path.
    /// </summary>
    public static string InstallApplicationDataPath =>
      Assembly.GetAssembly(typeof(RhinoRavenPlugin)).Location.Contains("ProgramData")
        ? Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
        : UserApplicationDataPath();

    /// <summary>
    /// Get the platform specific user configuration folder path.
    /// </summary>
    public static string UserApplicationDataPath()
    {
        // if we have an override, just return that
        var PathOverride = Path;
        if (PathOverride != null && !string.IsNullOrEmpty(PathOverride))
        {
            return PathOverride;
        }

        // on desktop linux and macos we use the appdata.
        // but we might not have write access to the disk
        // so the catch falls back to the user profile
        try
        {
            return Environment.GetFolderPath(
              Environment.SpecialFolder.ApplicationData,
              // if the folder doesn't exist, we get back an empty string on OSX,
              // which in turn, breaks other stuff down the line.
              // passing in the Create option ensures that this directory exists,
              // which is not a given on all OS-es.
              Environment.SpecialFolderOption.Create
            );
        }
        catch (SystemException ex) when (ex is PlatformNotSupportedException or ArgumentException)
        {
            // on server linux, there might not be a user setup, things can run under root
            // in that case, the appdata variable is most probably not set up
            // we fall back to the value of the home folder
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}

