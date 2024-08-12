namespace ExampleObjectCompositionWithDependencyInjection
{
    public class BusinessV2 : IBusiness
    {
        private readonly IDataAccess _dataAccess;

        public BusinessV2(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            // (...)
        }
    }
}