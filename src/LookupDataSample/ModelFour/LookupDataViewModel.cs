using System.Collections.Generic;

namespace LookupDataSample.ModelFour
{
    public class LookupDataViewModel
    {
        public int Id { get; set; }
        public int DefaultItemId { get; set; }
        public int? SelectedItemId { get; set; }
        public List<LookupDataItem> Items = new List<LookupDataItem>(); 
    }
}