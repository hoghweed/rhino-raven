using System.Collections.Generic;

namespace RhinoRaven.Model.Extractors;

public class NamedPrimitiveExtractor : ObjectRefExtractor<object>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(object source, ObjectRef? parent)
    {
        yield return new ObjectRef(NewId(), string.Empty, source.GetType().Name, null, parent?.Id);
    }
} 