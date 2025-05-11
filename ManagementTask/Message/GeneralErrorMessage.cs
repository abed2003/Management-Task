namespace ManagementTask.Message
{
    public class GeneralErrorMessage
    {
        public string ErrorType { get; set; }
        public string Message { get; set; }

        public GeneralErrorMessage(string  ErrorType ,  string Message)
        {
                this.ErrorType = ErrorType;
                this.Message = Message;
        }
       public GeneralErrorMessage() { }
    }
}
