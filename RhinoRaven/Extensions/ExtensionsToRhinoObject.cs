using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Rhino.DocObjects;
using Rhino.Geometry;
using RhinoRaven.Model;
using RhinoRaven.Model.Extractors;

namespace RhinoRaven.Extensions
{
    public static class ExtensionsToRhinoObject
    {
        public static IEnumerable<ObjectRef> GetObjectsRefHierarchy(this RhinoObject[] items)
        {
            // var idGenerator = new Random();
            // return items.SelectMany(item => FlattenHierarchy(item, () => idGenerator.Next(1000, 10000), null)).ToArray();
            return items.SelectMany(item => item.GetObjectRefHierarchy()).ToArray();
        }

        public static IEnumerable<ObjectRef> GetObjectRefHierarchy(this RhinoObject item) {
            return Extractors.For(item).Extract(item.Geometry);
        }
    }
}

