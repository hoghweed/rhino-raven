using System;
using System.Linq;
using Rhino;
using RhinoRaven.Model;
using RhinoRaven.Model.Persisters;

namespace RhinoRaven.Extensions
{
	public static class ExtensionsToRhinoDoc
	{
		public static SelectionSnapshot RecordSelection(this RhinoDoc document) {

            return new SelectionSnapshot(
                    new FilePersister(),
                    new FlatHierarchyExtractor(document)
                );
        }
    }
}

