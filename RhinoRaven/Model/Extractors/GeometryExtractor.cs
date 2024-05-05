using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.DocObjects;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public abstract class GeometryExtractor<TTarget> : IGeometryExtractor
    where TTarget : class
{
    public Type TargetType { get; private set; } = typeof(TTarget);

    public IEnumerable<GeometryBase> Extract(RhinoObject source) =>
        source != null ? ExtractFrom(source.Geometry as TTarget) : Enumerable.Empty<GeometryBase>();

    protected abstract IEnumerable<GeometryBase> ExtractFrom(TTarget source);
}
