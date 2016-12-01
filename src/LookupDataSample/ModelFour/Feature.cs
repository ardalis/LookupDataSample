namespace LookupDataSample.ModelFour
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultStyleId { get; set; } // how do you make sure this style belongs to this feature?
    }
}
