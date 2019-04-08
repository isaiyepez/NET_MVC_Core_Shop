using Shop.Web2.Data;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(DataContext context) : base(context)
    {
    }
}