namespace ExampleObjectCompositionWithDependencyInjection
{
    public class UserInterface : IUserInterface
    {
        private readonly IBusiness _business;

        public UserInterface(IBusiness business)
        {
            _business = business;
        }

        public void Getdate()
        {
            Console.WriteLine("Enter your username:");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            _business.SignUp(userName, password);
        }
    }
}