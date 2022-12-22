using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using FluentAssertions.Common;

namespace FluentAssertions.Execution {

internal class CollectingAssertionStrategy : IAssertionStrategy
{
    private readonly List<string> failureMessages = new();

    /// <summary>
    /// Returns the messages for the assertion failures that happened until now.
    /// </summary>
    public IEnumerable<string> FailureMessages => failureMessages;

    /// <summary>
    /// Discards and returns the failure messages that happened up to now.
    /// </summary>
    public IEnumerable<string> DiscardFailures()
    {
        var discardedFailures = failureMessages.ToArray();
        failureMessages.Clear();
        return discardedFailures;
    }

    /// <summary>
    /// Will throw a combined exception for any failures have been collected.
    /// </summary>
    public void ThrowIfAny(IDictionary<string, object> context)
    {
        if (failureMessages.Any())
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Join(Environment.NewLine, failureMessages));

            if (context.Any())
            {
                foreach (KeyValuePair<string, object> pair in context)
                {
                    builder.AppendFormat(CultureInfo.InvariantCulture, "\nWith {0}:\n{1}", pair.Key, pair.Value);
                }
            }

            Services.ThrowException(builder.ToString());
        }
    }

    /// <summary>
    /// Instructs the strategy to handle a assertion failure.
    /// </summary>
    public void HandleFailure(string message)
    {
        failureMessages.Add(message);
    }
}
}