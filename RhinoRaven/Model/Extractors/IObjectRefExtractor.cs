using System;
using System.Collections.Generic;

namespace RhinoRaven.Model.Extractors;

public interface IObjectRefExtractor
{
    Type TargetType { get; }

    IEnumerable<ObjectRef> Extract(object source);
    IEnumerable<ObjectRef> Extract(object source, ObjectRef parent);
}



