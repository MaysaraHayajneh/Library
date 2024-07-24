namespace Library.IEmailSend
{
    public interface IEmailService
    {
        public void SendEmail(string jobType, string startTime);
    }
}
