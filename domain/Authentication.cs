using Products.dtos;

namespace Products.domain
{

    public class Authentication(AuthenticationDto input)
    {
        public AuthenticationDto input = input;

        public void login()
        {
            bool invalidUserName = input.userName != input.expectedUserName;
            bool invalidPassword = input.password != input.expectedPassword;

            int maxNumberAttempts = 2;
            bool exceededNumberOfAttempts = input.numberOfAttempts >= maxNumberAttempts;

            bool invalidCredentials = invalidUserName || invalidPassword;

            if (invalidCredentials) throw new Exception(exceededNumberOfAttempts ? "Exceeded number of attempts" : "Invalid credentials");
            
        }
    }
}
