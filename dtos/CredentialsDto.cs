namespace Products.dtos
{
    public class CredentialsDto
    {
        public string userName { get; private set; }
        public string password { get; private set; }

        public CredentialsDto(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
