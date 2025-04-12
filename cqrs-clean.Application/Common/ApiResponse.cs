using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Common;

public class ApiResponse
{
    public bool Success { get; }
    public int StatusCode { get; }
    public string Message { get; }

    protected ApiResponse(bool success, int statusCode, string message)
    {
        Success = success;
        StatusCode = statusCode;
        Message = message;
    }

    public static ApiResponse SuccessResponse(string message = "Success", int statusCode = 200)
        => new(success: true, statusCode, message);

    public static ApiResponse FailureResponse(string message, int statusCode = 400)
        => new(success: false, statusCode, message);
}

public class ApiResponse<T> : ApiResponse
{
    public T Data { get; }

    public ApiResponse(T data, bool success = true, int statusCode = 200, string message = "Success")
        : base(success, statusCode, message)
    {
        Data = data;
    }

    public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200)
        => new(data, true, statusCode, message);

    public static ApiResponse<T> Failure(string message, int statusCode = 400)
        => new(default!, false, statusCode, message);
}

public class ApiResponseList<T> : ApiResponse
{
    public IReadOnlyList<T> Data { get; }

    public ApiResponseList(IEnumerable<T> data, bool success = true, int statusCode = 200, string message = "Success")
        : base(success, statusCode, message)
    {
        Data = data.ToList();
    }

    public static ApiResponseList<T> Success(IEnumerable<T> data, string message = "Success", int statusCode = 200)
        => new(data, true, statusCode, message);

    public static ApiResponseList<T> Failure(string message, int statusCode = 400)
        => new(Enumerable.Empty<T>(), false, statusCode, message);
}
