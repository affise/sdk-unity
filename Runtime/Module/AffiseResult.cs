#nullable enable

namespace AffiseAttributionLib.Module
{
    public class AffiseResult<T>
    {
        public static AffiseResult<T> Success(T value) => new AffiseSuccess<T>(value);
        public static AffiseResult<T> Failure(string error) => new AffiseFailure<T>(error);

        public bool IsSuccess => this is AffiseSuccess<T>;
        public bool IsFailure => !IsSuccess;
        
        public T AsSuccess => ((this as AffiseSuccess<T>)!).Value;
        
        public string AsFailure => (this as AffiseFailure<T>)?.Error ?? "";
    }

    internal class AffiseSuccess<T> : AffiseResult<T>
    {
        public T Value { get; }

        public AffiseSuccess(T value)
        {
            Value = value;
        }
    }
    
    internal class AffiseFailure<T> : AffiseResult<T>
    {
        public string Error { get; }

        public AffiseFailure(string error)
        {
            Error = error;
        }
    }
}