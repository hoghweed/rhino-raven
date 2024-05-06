using System.Collections.Generic;
using System.Linq;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class GeometryRefExtractor : ObjectRefExtractor<GeometryBase>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(GeometryBase source, ObjectRef? parent)
    {
        yield return new ObjectRef(NewId(), null, source.ObjectType.ToString(), null, parent?.Id);
    }
}

