using System;
using System.Collections.Generic;
using Rhino.DocObjects;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public interface IGeometryExtractor
{
    Type TargetType { get; }

    IEnumerable<GeometryBase> Extract(RhinoObject source);
}
