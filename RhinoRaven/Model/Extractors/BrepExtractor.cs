using System;
using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class BrepExtractor : GeometryExtractor<Brep>
{
    protected override IEnumerable<GeometryBase> ExtractFrom(Brep source)
    {
        return source.Faces.AsEnumerable();
    }
}

