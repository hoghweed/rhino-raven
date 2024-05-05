using System;
using System.Linq;
using Rhino.DocObjects;
using Rhino.Geometry;
using System.Collections.Generic;

namespace RhinoRaven.Model.Extractors;

public static class Extractors
{
    private static readonly Dictionary<Type, Lazy<IGeometryExtractor>> extractors = new()
    {
        { typeof(Brep), new Lazy<IGeometryExtractor>(() => new BrepExtractor())},
        { typeof(Mesh), new Lazy<IGeometryExtractor>(() => new MeshExtractor())}
    };

    public static IGeometryExtractor For(GeometryBase target) {
        return extractors[target.GetType()].Value;
    }
}

