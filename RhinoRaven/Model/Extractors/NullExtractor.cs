using System.Collections.Generic;
using System.Linq;

namespace RhinoRaven.Model.Extractors;

public class NullExtractor : ObjectRefExtractor<object>
{
    protected override IEnumerable<ObjectRef> ExtractFrom(object source, ObjectRef? parent)
    {
        return Enumerable.Empty<ObjectRef>();
    }
}



