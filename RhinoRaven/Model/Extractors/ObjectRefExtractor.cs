using System;
using System.Collections.Generic;

namespace RhinoRaven.Model.Extractors;

public abstract class ObjectRefExtractor<TTarget> : IObjectRefExtractor
{
    public Type TargetType { get; private set; } = typeof(TTarget);

    public IEnumerable<ObjectRef> Extract(object source) =>
        ExtractFrom((TTarget)source, null);

    public IEnumerable<ObjectRef> Extract(object source, ObjectRef parent) => 
        ExtractFrom((TTarget)source, parent);

    protected string NewId() => Guid.NewGuid().ToString("N");

    protected abstract IEnumerable<ObjectRef> ExtractFrom(TTarget source, ObjectRef? parent);
}