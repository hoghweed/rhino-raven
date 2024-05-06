using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class ArcCurveExtractor : ObjectRefExtractor<ArcCurve>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(ArcCurve source, ObjectRef? parent)
    {
        var self = new ObjectRef(NewId(), string.Empty, source.ObjectType.ToString(), null, parent?.Id);
        yield return self;

        foreach(var item in Extractors.For(source.Arc).Extract(source.Arc, self))
            yield return item;
    }
}