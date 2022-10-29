using Auto.InternalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.InternalLib;

public class ErrorOrNot<TValue> : IErrorOrNot
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;

    private static readonly Error NoFirstError = Error.Unexpected(
        code: "ErrorOr.NoFirstError",
        description: "First error cannot be retrieved from a successful ErrorOr.");

    private static readonly Error NoErrors = Error.Unexpected(
        code: "ErrorOr.NoErrors",
        description: "Error list cannot be retrieved from a successful ErrorOr.");

    /// <summary>
    /// Gets a value indicating whether the state is error.
    /// </summary>
    public bool IsError { get; }

    /// <summary>
    /// Gets the list of errors.
    /// </summary>
    public List<Error> Errors => IsError ? _errors! : new List<Error> { NoErrors };

    /// <summary>
    /// Creates an <see cref="ErrorOr{TValue}"/> from a list of errors.
    /// </summary>
    public static ErrorOrNot<TValue> From(List<Error> errors)
    {
        return errors;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public TValue Value => _value!;

    /// <summary>
    /// Gets the first error.
    /// </summary>
    public Error FirstError
    {
        get
        {
            if (!IsError)
            {
                return NoFirstError;
            }

            return _errors![0];
        }
    }

    private ErrorOrNot(Error error)
    {
        _errors = new List<Error> { error };
        IsError = true;
    }

    private ErrorOrNot(List<Error> errors)
    {
        _errors = errors;
        IsError = true;
    }

    private ErrorOrNot(TValue value)
    {
        _value = value;
        IsError = false;
    }

    /// <summary>
    /// Creates an <see cref="ErrorOr{TValue}"/> from a value.
    /// </summary>
    public static implicit operator ErrorOrNot<TValue>(TValue value)
    {
        return new ErrorOrNot<TValue>(value);
    }

    /// <summary>
    /// Creates an <see cref="ErrorOr{TValue}"/> from an error.
    /// </summary>
    public static implicit operator ErrorOrNot<TValue>(Error error)
    {
        return new ErrorOrNot<TValue>(error);
    }

    /// <summary>
    /// Creates an <see cref="ErrorOr{TValue}"/> from a list of errors.
    /// </summary>
    public static implicit operator ErrorOrNot<TValue>(List<Error> errors)
    {
        return new ErrorOrNot<TValue>(errors);
    }

    /// <summary>
    /// Creates an <see cref="ErrorOr{TValue}"/> from a list of errors.
    /// </summary>
    public static implicit operator ErrorOrNot<TValue>(Error[] errors)
    {
        return new ErrorOrNot<TValue>(errors.ToList());
    }

    // public void Switch(Action<TValue> onValue, Action<List<Error>> onError)
    // {
    //     if (IsError)
    //     {
    //         onError(Errors);
    //         return;
    //     }

    //     onValue(Value);
    // }

    // public void SwitchFirst(Action<TValue> onValue, Action<Error> onFirstError)
    // {
    //     if (IsError)
    //     {
    //         onFirstError(FirstError);
    //         return;
    //     }

    //     onValue(Value);
    // }

    public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<List<Error>, TResult> onError)
    {
        if (IsError)
        {
            return onError(Errors);
        }

        return onValue(Value);
    }

    public TResult MatchFirst<TResult>(Func<TValue, TResult> onValue, Func<Error, TResult> onFirstError)
    {
        if (IsError)
        {
            return onFirstError(FirstError);
        }

        return onValue(Value);
    }
}

public static class ErrorOr
{
    public static ErrorOrNot<TValue> From<TValue>(TValue value)
    {
        return value;
    }
}