using System.Collections.Generic;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MishMashWebApp
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //serviceCollection.Add<IUsersService, UsersService>();
            //serviceCollection.Add<IRepositoriesService, RepositoriesService>();
            //serviceCollection.Add<ICommitsService, CommitsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            //new ApplicationDbContext().Database.Migrate();
        }
    }
}
