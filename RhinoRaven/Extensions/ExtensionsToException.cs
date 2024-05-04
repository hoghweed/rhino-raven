using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;

namespace RhinoRaven.Extensions;

public static class ExtensionsToException
{
    [Pure]
    public static bool IsFatal(this Exception ex)
    {
        return ex switch
        {
            OutOfMemoryException
            or ThreadAbortException
            or InvalidProgramException
            or AccessViolationException
            or AppDomainUnloadedException
            or BadImageFormatException
              => true,
            _ => false,
        };
    }

    public static string ToFormattedString(this Exception exception)
    {
        var messages = exception
          .GetAllExceptions()
          .Where(e => !string.IsNullOrWhiteSpace(e.Message))
          .Select(e => e.Message.Trim());
        string flattened = string.Join(Environment.NewLine + "    ", messages);
        return flattened;
    }

    private static IEnumerable<Exception> GetAllExceptions(this Exception exception)
    {
        yield return exception;

        if (exception is AggregateException aggregated)
        {
            foreach (var innerException in aggregated.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
            {
                yield return innerException;
            }
        }
        else if (exception.InnerException != null)
        {
            foreach (var innerException in exception.InnerException.GetAllExceptions())
            {
                yield return innerException;
            }
        }
    }

}

