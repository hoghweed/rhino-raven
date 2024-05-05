using System;
using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class MeshExtractor : GeometryExtractor<Mesh>
{
    protected override IEnumerable<GeometryBase> ExtractFrom(Mesh source)
    {
        //return source.Vertices.AsEnumerable();
        throw new NotImplementedException();
    }
}

