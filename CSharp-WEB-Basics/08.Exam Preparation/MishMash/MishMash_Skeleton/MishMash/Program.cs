using System.Threading.Tasks;
using SUS.MvcFramework;

namespace MishMashWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp(), 3011);
        }
    }
}
