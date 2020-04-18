namespace VirtualPharmaRep.Data.CustomObjects
{
    public class EntityValidationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public EntityValidationResult(bool isSuccess, string message)
        {
	        IsSuccess = isSuccess;
            Message = message;
        }
    }
}
