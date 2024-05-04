using System;
namespace RhinoRaven.Model.Persisters
{
    public interface IPersister
	{
		OperationResult Store(SelectionSnapshot snapshot);
	}
}

