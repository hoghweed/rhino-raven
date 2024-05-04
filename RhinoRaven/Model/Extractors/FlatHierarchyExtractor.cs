using System.Linq;
using Rhino;
using RhinoRaven.Model;
using RhinoRaven.Model.Extractors;

namespace RhinoRaven.Extensions;

public class FlatHierarchyExtractor : ISelectionExtractor
{
    private readonly RhinoDoc _document;

    public FlatHierarchyExtractor(RhinoDoc document)
    {
        _document = document;
    }

    public OperationResult Extract()
    {
        var objs = _document.Objects.GetSelectedObjects(true, false).ToList();

        throw new System.NotImplementedException();
    }
}