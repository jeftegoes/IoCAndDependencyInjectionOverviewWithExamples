namespace ExampleObjectCompositionWithDependencyInjection
{
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;

        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            _dataAccess.Store(userName, password);
        }
    }
}