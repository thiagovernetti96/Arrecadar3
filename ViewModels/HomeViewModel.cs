using Arrecadar3.Models;

namespace Arrecadar3.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Campanha> Campanhas { get; set; }
        public IEnumerable<Ong> Ongs { get; set; }
    }
}
