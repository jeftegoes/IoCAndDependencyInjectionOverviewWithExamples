namespace ExampleObjectCompositionWithoutInterface
{
    public class Business : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            var dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }
}