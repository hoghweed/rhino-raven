using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using RhinoRaven.Extensions;

namespace RhinoRaven;

public class SaveToRavenCommand : Command
{
    public SaveToRavenCommand()
    {
        // Rhino only creates one instance of each command class defined in a
        // plug-in, so it is safe to store a refence in a static property.
        Instance = this;
    }

    ///<summary>The only instance of this command.</summary>
    public static SaveToRavenCommand Instance { get; private set; }

    ///<returns>The command name as it appears on the Rhino command line.</returns>
    public override string EnglishName => "SaveToRaven";

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
        RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName);
        var snapshot = doc.RecordSelection();

        snapshot.Save();

        return Result.Success;
    }
}

