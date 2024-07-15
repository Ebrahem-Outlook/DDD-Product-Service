namespace Products.Domain.Core.BaseType.Result;

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; set; }

    public bool IsFailer => !IsSuccess;

    public Error Error { get; set; }

    public static Result Success() => new Result(true, Error.None);

    public static Result Failer(Error error) => new Result(false, error);
}
