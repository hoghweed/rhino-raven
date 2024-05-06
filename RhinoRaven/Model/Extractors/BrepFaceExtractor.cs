using System;
using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class BrepFaceExtractor : ObjectRefExtractor<BrepFace>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(BrepFace source, ObjectRef? parent)
    {
        var self = new ObjectRef(NewId(), string.Empty, source.ObjectType.ToString(), null, parent?.Id);
        yield return self;

        foreach (var item in source.Loops.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
    }
}

