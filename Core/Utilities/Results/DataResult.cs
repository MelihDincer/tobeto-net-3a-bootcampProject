namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, string message, bool success) : base(message, success)
        {
            Data = data;
        }
        public DataResult(T data, bool succes) : base(succes)
        {
            Data = data;
        }
    }
}
