using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class PolyCurveExtractor : ObjectRefExtractor<PolyCurve>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(PolyCurve source, ObjectRef? parent)
    {
        var self = new ObjectRef(NewId(), string.Empty, source.ObjectType.ToString(), null, parent?.Id);
        yield return self;

        foreach (var item in source.DuplicateSegments().SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;

    }
} 
