using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Rhino.DocObjects;
using RhinoRaven.Model;
using RhinoRaven.Model.Extractors;

namespace RhinoRaven.Extensions
{
	public static class ExtensionsToRhinoObject
	{
        public static IEnumerable<ObjectRef> GetHierarchy(this RhinoObject[] items) {
            var idGenerator = new Random();
            return items.SelectMany(item => FlattenHierarchy(item, () => idGenerator.Next(1000, 10000), null)).ToArray();
        }

        private static IEnumerable<ObjectRef> FlattenHierarchy(RhinoObject source, Func<int> idGenerator, string? parentId)
        {
            var extractor = Extractors.For(source.Geometry);

            var newId = idGenerator().ToString();
            yield return new ObjectRef(
                Id: newId,
                Name: source.Name,
                ObjectType: source.ObjectType.ToString(),
                ObjectId: source.Id.ToString(),
                ParentId: parentId?.ToString()
            );

            var subObjects = source.GetSubObjects();

            if (!subObjects.Any())
                yield break;

            foreach (var child in subObjects.SelectMany(sub => FlattenHierarchy(sub, idGenerator, newId)))
            {
                yield return child;
            }
        }

/*        private static IEnumerable<ObjectRef> FlattenHierarchy(RhinoObject source, Guid? parentId)
        {
            Debug.WriteLine(source.ToJSON(new Rhino.FileIO.SerializationOptions() { WriteRenderMeshes = true }));
            yield return new ObjectRef(source.Id, source.Name, source.ObjectType, parentId);
            var subObjects = source.GetSubObjects();

            if (!subObjects.Any())
                yield break;

            foreach (var child in subObjects.SelectMany(sub => FlattenHierarchy(sub, source.Id)))
            {
                yield return child;
            }
        }
*/

        public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> source,
            Func<T, IEnumerable<T>> GetChildren)
        {
            return source
                .SelectMany(c => GetChildren(c).Flatten(GetChildren))
                .Concat(source);
        }
    }
}

