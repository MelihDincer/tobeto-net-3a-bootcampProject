namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(string message, bool success) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
    }
}
