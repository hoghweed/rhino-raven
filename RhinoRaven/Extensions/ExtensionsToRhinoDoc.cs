using System.Diagnostics;
using System.Linq;
using Rhino;
using RhinoRaven.Model;
using RhinoRaven.Model.Persisters;

namespace RhinoRaven.Extensions
{
    public static class ExtensionsToRhinoDoc
	{
		public static SelectionSnapshot RecordSelection(this RhinoDoc document) {

            var selection = document.Objects.GetSelectedObjects(true, false).ToArray();

            return new SelectionSnapshot(
                    document.Name,
                    document.Path,
                    new FilePersister(),
                    selection.GetHierarchy()
                );
        }
    }
}

