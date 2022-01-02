namespace WEB_API.Contracts.Leeruitkomst
{
    public class CreateLeeruitkomstRequest
    {
        public int EvlId { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}