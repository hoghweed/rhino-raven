using Rhino;
using Rhino.Commands;
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
    public static SaveToRavenCommand? Instance { get; private set; }

    ///<returns>The command name as it appears on the Rhino command line.</returns>
    public override string EnglishName => "SaveToRaven";

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
        var snapshot = doc.RecordSelection();
        RhinoApp.WriteLine("A Selection Snapshot [{0}] has been created.", snapshot.Id);

        var result = snapshot.Save();
        RhinoApp.WriteLine("The Snapshot [{0}] was saved with {1}: {2}", snapshot.Id, result.Kind, result.Message);

        System.Diagnostics.Debug.WriteLine(result.Get<string>());


        return Result.Success;
    }
}

