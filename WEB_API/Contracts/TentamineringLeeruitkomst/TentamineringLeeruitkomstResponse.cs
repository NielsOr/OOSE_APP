using WEB_API.Contracts.Leeruitkomst;

namespace WEB_API.Contracts.TentamineringLeeruitkomst
{
    public class TentamineringLeeruitkomstResponse
    {
        public int Id { get; set; }
        public string Beoordelingcriteria { get; set; }
        public LeeruitkomstResponse Leeruitkomst { get; set; }
    }
}
