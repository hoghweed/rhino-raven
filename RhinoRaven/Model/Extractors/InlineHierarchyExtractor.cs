using System;
using Rhino;

namespace RhinoRaven.Model.Extractors;

public class InlineHierarchyExtractor : ISelectionExtractor
{
    private readonly RhinoDoc _document;

    public InlineHierarchyExtractor(RhinoDoc document)
    {
        _document = document;
    }

    public OperationResult Extract()
    {
        throw new NotImplementedException();
    }
}

