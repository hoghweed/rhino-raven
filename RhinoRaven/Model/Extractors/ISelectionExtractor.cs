using System;

namespace RhinoRaven.Model.Extractors;

public interface ISelectionExtractor
{
	OperationResult Extract();
}