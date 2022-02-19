namespace ExampleObjectCompositionWithoutInterface
{
    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // Write the data to the db...
        }
    }
}