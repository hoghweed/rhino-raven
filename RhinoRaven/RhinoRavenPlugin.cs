using System;
using System.Text;
using System.Reflection;
using Rhino;
using Rhino.PlugIns;
using RhinoRaven.Extensions;
using System.IO;
using Rhino.UI;

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

    public override PlugInLoadTime LoadTime => PlugInLoadTime.AtStartup;
}
