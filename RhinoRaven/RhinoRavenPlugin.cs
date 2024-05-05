using System;
using System.Text;
using System.Reflection;
using Rhino;
using Rhino.PlugIns;
using RhinoRaven.Extensions;
using System.IO;

namespace RhinoRaven;

///<summary>
/// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
/// class. DO NOT create instances of this class yourself. It is the
/// responsibility of Rhino to create an instance of this class.</para>
/// <para>To complete plug-in information, please also see all PlugInDescription
/// attributes in AssemblyInfo.cs (you might need to click "Project" ->
/// "Show All Files" to see it in the "Solution Explorer" window).</para>
///</summary>
public class RhinoRavenPlugin : PlugIn
{
    public RhinoRavenPlugin()
    {
        Instance = this;
    }

    ///<summary>Gets the only instance of the RhinoRavenPlugin plug-in.</summary>
    public static RhinoRavenPlugin? Instance { get; private set; }

    // You can override methods here to change the plug-in behavior on
    // loading and shut down, add options pages to the Rhino _Option command
    // and maintain plug-in wide options in a document.

    public void Init()
    {
        RhinoDoc.CloseDocument += RhinoDoc_CloseDocument;
        RhinoDoc.BeginOpenDocument += RhinoDoc_BeginOpenDocument;
        RhinoDoc.EndOpenDocument += RhinoDoc_EndOpenDocument;
    }

    private void RhinoDoc_EndOpenDocument(object sender, DocumentOpenEventArgs e)
    {

    }

    private void RhinoDoc_BeginOpenDocument(object sender, DocumentOpenEventArgs e)
    {   

    }

    private void RhinoDoc_CloseDocument(object sender, DocumentEventArgs e)
    {
        
    }

    protected override LoadReturnCode OnLoad(ref string errorMessage)
    {
        try
        {
            Init();
        }
        catch (Exception ex) when (!ex.IsFatal())
        {
            errorMessage = $"Failed to load Rhino Raven Plugin with {ex.ToFormattedString()}";
            RhinoApp.CommandLineOut.WriteLine(errorMessage);
            return LoadReturnCode.ErrorShowDialog;
        }
        EnsureVersionSettings();

        return LoadReturnCode.Success;
    }

    private void EnsureVersionSettings()
    {
        // Get the version number of our plugin, that was last used, from our settings file.
        var pluginVersion = Settings.GetString("PlugInVersion", null);
        if (string.IsNullOrEmpty(pluginVersion))
        {
            return;
        }

        // If the version number of the plugin that was last used does not match the
        // version number of this plugin, proceed.
        if (0 == string.Compare(Version, pluginVersion, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        // Build a path to the user's staged RUI file.
        var sb = new StringBuilder();
        sb.Append(RhinoRavenPathProvider.InstallApplicationDataPath);
        sb.Append(@"\McNeel\Rhinoceros\8.0\UI\Plug-ins\");
        sb.AppendFormat("{0}.rui", Assembly.GetName().Name);
        var path = sb.ToString();

        if (File.Exists(path))
        {
            RhinoApp.CommandLineOut.WriteLine("Deleting and Updating RUI settings file");
            try
            {
                File.Delete(path);
            }
            catch (IOException ioEx)
            {
                RhinoApp.CommandLineOut.WriteLine($"Failed to delete Speckle toolbar {path} with {ioEx.ToFormattedString()}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                RhinoApp.CommandLineOut.WriteLine($"Failed to delete Speckle toolbar {path} with {uaEx.ToFormattedString()}");
            }
        }
        // Save the version number of this plugin to our settings file.
        Settings.SetString("PlugInVersion", Version);
    }
}
