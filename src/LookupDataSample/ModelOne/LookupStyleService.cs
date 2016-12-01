using System.Collections.Generic;
using System.Linq;

namespace LookupDataSample.ModelOne
{
    public class LookupStyleService
    {
        private static List<Style> _styles = new List<Style>()
        {
            new Style() {FeatureId = 1, Id=1, IsDefault = true, Name = "Style A"},
            new Style() {FeatureId = 1, Id=2, IsDefault = false, Name = "Style B"},
            new Style() {FeatureId = 1, Id=3, IsDefault = false, Name = "Style C"},
            new Style() {FeatureId = 2, Id=4, IsDefault = false, Name = "Style D"},
            new Style() {FeatureId = 2, Id=5, IsDefault = true, Name = "Style E"},

        };
        public List<Style> ListStylesForFeature(int featureId)
        {
            return _styles
                .Where(s => s.FeatureId == featureId)
                .ToList();
        } 
    }
}
