namespace Dev.Domain.Abstraction;

public class Result<TDto> where TDto : IResult
{
    private Result(TDto data, int statusCode)
    {
        Data = data;
        IsNotSuccessfull = false;
        StatusCode = statusCode;
    }

    private Result(int statusCode)
    {
        IsNotSuccessfull = true;
        StatusCode = statusCode;
    }

    private Result(int statusCode, string errorCode, string errorMessage)
    {
        IsNotSuccessfull = true;
        StatusCode = statusCode;
        Errors = new(){
        {errorCode, errorMessage}
       };
    }

    private Result(int statusCode, Dictionary<string, string> errors)
    {
        IsNotSuccessfull = true;
        StatusCode = statusCode;
        Errors = errors;
    }


    public TDto Data { get; }
    public bool IsNotSuccessfull { get; }
    public int StatusCode { get; }
    public Dictionary<string, string> Errors { get; set; }

    public static Result<TDto> Success(TDto data, int statusCode)
    => new(data, statusCode);

    public static Result<TDto> Success(int statusCode)
    => new(statusCode);

    public static Result<TDto> Failed(int statusCode, string errorCode, string errorMessage)
    => new(statusCode, errorCode, errorMessage);

    public static Result<TDto> Failed(int statusCode, Dictionary<string, string> errors)
    => new(statusCode, errors);
}

public class NoContentDto : IResult;