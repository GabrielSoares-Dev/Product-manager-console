namespace Products.utils
{
    public class HidePassword
    {
        public string run(string password)
        {
            ConsoleKeyInfo keyStroke;

            do
            {
                keyStroke = Console.ReadKey(true);

                bool isNotBackspace = keyStroke.Key != ConsoleKey.Backspace;
                bool isNotEnter = keyStroke.Key != ConsoleKey.Enter;

                if (isNotBackspace && isNotEnter)
                {
                    password += keyStroke.KeyChar;
                    Console.Write("*");
                }

                bool isBackspace = keyStroke.Key == ConsoleKey.Backspace;
                bool notEmpty = password.Length > 0;
               
                if (isBackspace && notEmpty)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }

            } while (keyStroke.Key != ConsoleKey.Enter);
         

            return password;
        }
    }
}
