


namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountries();
            await CheckCategories();
        }

        private async Task CheckCategories()
        { 
            if(!_context.Categories.Any() )
            {
                _context.Categories.Add(new Shared.Entities.Category { Name  = "Electronica" } );
                _context.Categories.Add(new Shared.Entities.Category { Name = "Rock" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Pop" });
                _context.Categories.Add(new Shared.Entities.Category { Name = "Jazz" });
                await _context.SaveChangesAsync();
            }    
        }

        private async Task CheckCountries()
        {
            if( !_context.Countries.Any() )
            {
                _context.Countries.Add(new Shared.Entities.Country { Name = "Mexico" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Peru" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Venezuela" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Brasil" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Ecueador" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Colombia" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
