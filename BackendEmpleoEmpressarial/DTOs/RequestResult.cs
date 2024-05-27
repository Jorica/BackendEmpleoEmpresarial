namespace BackendCRUD.DTOs;

public sealed class RequestResult<T>
{
    public bool IsSuccessful { get; set; }

    public bool IsError { get; set; }

    public string ErrorMessage { get; set; }

    public IEnumerable<string> Messages { get; set; }

    public T Result { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public object Extended { get; set; }

    public RequestResult() { }

    internal RequestResult(bool isSuccessful, bool isError, string errorMessage, IEnumerable<string> messages, T result)
    {
        IsSuccessful = isSuccessful;
        IsError = isError;
        ErrorMessage = errorMessage;
        Messages = messages;
        Result = result;
    }

    public static RequestResult<T> CreateSuccessful(T result, IEnumerable<string> messages)
    {
        return new RequestResult<T>(isSuccessful: true, isError: false, null, messages, result);
    }

    public static RequestResult<T> CreateUnsuccessful(IEnumerable<string> messages)
    {
        return new RequestResult<T>(isSuccessful: false, isError: false, null, messages, default(T));
    }

    public static RequestResult<T> CreateError(string errorMessage)
    {
        return new RequestResult<T>(isSuccessful: false, isError: true, errorMessage, null, default(T));
    }

}

