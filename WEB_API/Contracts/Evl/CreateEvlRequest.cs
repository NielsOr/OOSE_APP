namespace WEB_API.Contracts.Evl
{
    public class CreateEvlRequest
    {
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public string Eindkwalificaties { get; set; }
    }
}