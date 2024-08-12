namespace ExampleObjectCompositionWithoutInterface
{
    public class UserInterface
    {
        public void Getdate()
        {
            Console.WriteLine("Enter your username:");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            // IBusiness business = new Business();
            IBusiness business = new Business();
            business.SignUp(userName, password);
        }
    }
}