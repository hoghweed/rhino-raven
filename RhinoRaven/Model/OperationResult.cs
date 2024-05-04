using System;
using Rhino.Commands;
using RhinoRaven.Extensions;

namespace RhinoRaven.Model;

public enum ResultKind { Success, Failure, Error }

public class OperationResult
{
    private object? _result;

    public ResultKind Kind { get; private set; }
    public string Message { get; private set; } = string.Empty;

    public TResult? Get<TResult>() where TResult : class {
        return _result as TResult;
    }

    public static OperationResult AsSuccess() {
        return AsSuccess<object>(null);
    }

    public static OperationResult AsSuccess<TResult>(TResult? result) where TResult : class
    {
		return new OperationResult() { Kind = ResultKind.Success, _result = result };
	}

    public static OperationResult AsFailure(string message) {
        return new OperationResult() { Kind = ResultKind.Failure, Message = message };
    }

    public static OperationResult AsError(Exception exception) {
        return new OperationResult()
        {
            Kind = ResultKind.Error,
            Message = exception.ToFormattedString(),
            _result = exception
        };
    }
}
