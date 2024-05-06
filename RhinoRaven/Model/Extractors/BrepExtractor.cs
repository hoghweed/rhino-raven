using System;
using System.Linq;
using System.Collections.Generic;
using Rhino.Geometry;

namespace RhinoRaven.Model.Extractors;

public class BrepExtractor : ObjectRefExtractor<Brep>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(Brep source, ObjectRef? parent)
    {
        var self = new ObjectRef(NewId(), string.Empty, source.ObjectType.ToString(), null, parent?.Id);
        yield return self;

        foreach (var item in source.Faces.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
        foreach (var item in source.Surfaces.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
        foreach (var item in source.Curves2D.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
        foreach (var item in source.Curves3D.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
        foreach (var item in source.Vertices.SelectMany(it => Extractors.For(it.Location).Extract(it.Location, self)))
            yield return item;
        foreach (var item in source.Edges.SelectMany(it => Extractors.For(it).Extract(it, self)))
            yield return item;
    }
}

