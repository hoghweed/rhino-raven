using System;
using System.Linq;
using Rhino.DocObjects;
using Rhino.Geometry;
using System.Collections.Generic;

namespace RhinoRaven.Model.Extractors;

public static class Extractors
{
    private static readonly Dictionary<Type, Lazy<IObjectRefExtractor>> extractors;
    private static readonly NullExtractor nullExtractor;

    static Extractors()
    {
        nullExtractor = new NullExtractor();
        var geometryRefExtractor = new Lazy<IObjectRefExtractor>(() => new GeometryRefExtractor());
        var namedPrimitiveExtractor = new Lazy<IObjectRefExtractor>(() => new NamedPrimitiveExtractor());
        extractors = new()
        {
            { typeof(Arc), namedPrimitiveExtractor},
            { typeof(Brep), new Lazy<IObjectRefExtractor>(() => new BrepExtractor())},
            { typeof(BrepEdge), geometryRefExtractor},
            { typeof(BrepFace), new Lazy<IObjectRefExtractor>(() => new BrepFaceExtractor())},
            { typeof(BrepLoop), geometryRefExtractor},
            { typeof(Line), namedPrimitiveExtractor},
            { typeof(Polyline), namedPrimitiveExtractor},
            { typeof(Curve), geometryRefExtractor},
            { typeof(ArcCurve), new Lazy<IObjectRefExtractor>(() => new ArcCurveExtractor())},
            { typeof(PolyCurve), new Lazy<IObjectRefExtractor>(() => new PolyCurveExtractor())},
            { typeof(PolylineCurve), geometryRefExtractor},
            { typeof(Circle), namedPrimitiveExtractor},
            { typeof(Surface), geometryRefExtractor},
            { typeof(Point), namedPrimitiveExtractor},
            { typeof(Point3d), namedPrimitiveExtractor},
        };
    }

    public static IObjectRefExtractor For(RhinoObject target) => For(target.Geometry.GetType());

    public static IObjectRefExtractor For<TTarget>(TTarget target) => For(typeof(TTarget));

    private static IObjectRefExtractor For(Type target)
    {
        return extractors.ContainsKey(target)
            ? extractors[target].Value
            : nullExtractor;
    }
}

