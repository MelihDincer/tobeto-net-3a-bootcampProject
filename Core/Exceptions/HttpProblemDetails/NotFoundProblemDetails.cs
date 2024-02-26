using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Exceptions.HttpProblemDetails
{
    public class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Title = "Not Found";
            Detail = detail;
            Status = StatusCodes.Status404NotFound;
            Type = "http://tobeto.com/probs/notfound";
        }
    }
}