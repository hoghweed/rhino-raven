using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class BrepLoopExtractor : ObjectRefExtractor<BrepLoop>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(BrepLoop source, ObjectRef? parent)
    {
        var self = new ObjectRef(NewId(), string.Empty, source.ObjectType.ToString(), null, parent?.Id);
        yield return self;

        foreach (var item in Extractors.For(source.Face).Extract(source.Face, self))
            yield return item;
    }
}

