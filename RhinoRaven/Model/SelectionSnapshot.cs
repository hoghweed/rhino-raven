using Rhino.DocObjects;
using RhinoRaven.Model.Persisters;
using System;
using System.Collections.Generic;

namespace RhinoRaven.Model;

public record ObjectRef(string Id, string? Name, string ObjectType, string? ObjectId, string? ParentId);

public class SelectionSnapshot
{
	private readonly IPersister _persister;

	public SelectionSnapshot(string sourceName, string sourcePath, IPersister persister, IEnumerable<ObjectRef> source)
	{
		_persister = persister;
		Selection = source;
		SourceName = sourceName;
		SourcePath = sourcePath;
	}

	public string SourceName { get; private set; }
    public string SourcePath { get; private set; }
    public string Id { get; private set; } = Guid.NewGuid().ToString();
	public DateTime Date { get; private set; } = DateTime.Now;
	public IEnumerable<ObjectRef> Selection { get; private set; }

	public OperationResult Save()
	{
		return _persister.Store(this);
	}
}

