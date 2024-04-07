using UserManagement.Domains.Interfaces;

namespace UserManagement.Infrastructures.Exceptions
{
    public class ErrorResponse : IErrorResponse
    {
        public string Message { get; set; } = "An unexpected error occurred.";
    }
}