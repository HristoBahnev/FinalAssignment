using FinalAssignment.CountryApi;

namespace FinalAssignment
{
    public class Store
    {
        public string StoreName { get; set; }
        public Country Location { get; set; }
        public List<string> AssignedTypes { get; set; }
        public decimal Income { get; set; }
    }
}
