namespace MoltenCore
{
    public class ApplicationExceptionCode : ApplicationException
    {
        public ApplicationExceptionCode(ExceptionCode exceptionCode)
        {
            Code = exceptionCode;
        }

        public ApplicationExceptionCode(ExceptionCode exceptionCode, string? message) : base(message)
        {
            Code = exceptionCode;
        }

        public ApplicationExceptionCode(ExceptionCode exceptionCode, string? message, Exception? innerException) : base(message, innerException)
        {
            Code = exceptionCode;
        }

        public ExceptionCode Code { get; }
    }

    public enum ExceptionCode
    {
        NotFound,
    }
}

