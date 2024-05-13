using Products.domain;
using Products.dtos;
using Products.services;
using Products.utils;

namespace Products.useCases
{
    public class LoginUseCase
    {
        private string getExpectedPasswordFromFile()
        {
            string folderName = "temp";
            string fileName = "password.txt";
            FileService fileService = new();

            return fileService.read(folderName, fileName);
        }

        private string getPassword()
        {
            HidePassword hidePassword = new();
            string password = "";

            return hidePassword.run(password);
        }

        private CredentialsDto getCredentials()
        { 
            Console.Write("Usuário: ");
            string userName = Console.ReadLine();

            Console.Write("Senha: ");
            string password = this.getPassword();

            return new CredentialsDto(userName, password);
        }

        private void closeProgram()
        {
            Console.WriteLine("Programa finalizado!");
            Environment.Exit(0);  
        }

        public void run()
        {
            string expectedUserName = "hamilton";
            string expectedPassword = this.getExpectedPasswordFromFile();
            int numberOfAttempts = 1;

            bool authenticationFlowInProcessing = true;
            while (authenticationFlowInProcessing)
            {
                try
                {
                    CredentialsDto credentials = this.getCredentials();
                    AuthenticationDto authenticationData = new(expectedUserName, expectedPassword, credentials.userName, credentials.password, numberOfAttempts);
                    Authentication authentication = new(authenticationData);

                    authentication.login();
                    Console.WriteLine("\nAutenticacao ACEITA!\n");
                    authenticationFlowInProcessing = false;
                }
                catch (Exception exception)
                {
                    bool exceededNumberOfAttempts = exception.Message == "Exceeded number of attempts";
                    if (exceededNumberOfAttempts)
                    {
                        Console.WriteLine("\nAutenticacao RECUSADA! Acesso NEGADO!\n");
                        authenticationFlowInProcessing = false;
                        this.closeProgram();
                    };

                    bool invalidCredentials = exception.Message == "Invalid credentials";
                    if (invalidCredentials)
                    {
                        numberOfAttempts++;
                        Console.Write("\nAutenticacao RECUSADA! Voce tem mais 1 tentativa. Tentar novamente? (s/n): ");

                        bool rejectSecondAttempt = Console.ReadLine() != "s" ;
                        if(rejectSecondAttempt) this.closeProgram();

                    };
                }
         
            }
        }
    }
   
}
