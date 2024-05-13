namespace Products.dtos
{
    public class AuthenticationDto(
        string expectedUserName,
        string expectedPassword,
        string userName,
        string password,
        int numberOfAttempts
        )
    {
        public string expectedUserName { get; private set; } = expectedUserName;
        public string expectedPassword { get; private set; } = expectedPassword;
        public string userName { get; private set; } = userName;
        public string password { get; private set; } = password;
        public int numberOfAttempts { get; private set; } = numberOfAttempts;
    }
}
