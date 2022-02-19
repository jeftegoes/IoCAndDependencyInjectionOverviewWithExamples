namespace ExampleObjectCompositionWithoutInterface
{
    public class Business
    {
        public void SignUp(string userName, string password)
        {
            var dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }
}