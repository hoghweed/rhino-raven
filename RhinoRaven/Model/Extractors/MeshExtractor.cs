using System;
using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class MeshExtractor : ObjectRefExtractor<Mesh>
{
    protected IEnumerable<ObjectRef> ExtractFrom(Mesh source)
    {
        //   return source.Normals.AsEnumerable<GeometryBase>()
        //        .Concat(source.Edges.AsEnumerable<GeometryBase>())
        //        .Concat(source.Curves3D.AsEnumerable<GeometryBase>());
        throw new NotImplementedException();
    }

    protected override IEnumerable<ObjectRef> ExtractFrom(Mesh source, ObjectRef? parent)
    {
        throw new NotImplementedException();
    }
}

