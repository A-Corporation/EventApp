namespace EventApp.Models
{
    public class Sponsor
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string NameSort => Name[0].ToString().ToUpper();
    }
}