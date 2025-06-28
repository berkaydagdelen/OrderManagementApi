 

namespace OrderManagementApi.DTO.Base
{
    public class BaseResponse
    {
        public bool State { get; set; }
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
        public void GenerateSuccessResponse()
        {
            this.State = true;
        }

        public void GenerateSuccessResponse(string message)
        {
            this.State = true;
            this.Message = message;
        }

        public void GenerateErrorResponse(string errorMessage)
        {
            this.State = false;
            this.ErrorMessage = errorMessage;
    
        }

       
    }
}
