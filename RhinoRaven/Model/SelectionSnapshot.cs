using Rhino;
using Rhino.UI;
using RhinoRaven.Model.Extractors;
using RhinoRaven.Model.Persisters;
using System;
using System.Linq;

namespace RhinoRaven.Model;

public class SelectionSnapshot
{
	private readonly IPersister _persister;
	private readonly ISelectionExtractor _extractor;

	public SelectionSnapshot(IPersister persister, ISelectionExtractor extractor)
	{
		_persister = persister;
		_extractor = extractor;
		_extractor.Extract();
	}

	public string Name { get; private set; } = Guid.NewGuid().ToString();
	public DateTime Date { get; private set; } = DateTime.Now;

	public OperationResult Save()
	{
		_persister.Store(this);
		return OperationResult.AsSuccess();
	}
}

