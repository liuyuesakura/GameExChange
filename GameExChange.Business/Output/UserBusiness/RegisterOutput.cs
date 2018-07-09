namespace GameExChange.Business.Output.UserBusiness
{
    public class RegisterOutput:BaseOutput
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public RegisterOutput()
        {
            if (!this.IsSuccess)
            {
                this.Name = string.Empty;
                this.UserID = 0;
            }
        }
    }
}
