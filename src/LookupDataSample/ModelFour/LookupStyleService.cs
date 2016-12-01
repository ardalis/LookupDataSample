using System.Collections.Generic;
using System.Linq;

namespace LookupDataSample.ModelFour
{
    public class LookupStyleService
    {
        private static List<Feature> _features = new List<Feature>()
        {
            new Feature() {Id = 1, Name = "Feature One", DefaultStyleId = 1},
            new Feature() {Id = 2, Name = "Feature Two", DefaultStyleId = 3}
        };

        private static List<FeatureStyle> _featureStyles = new List<FeatureStyle>()
        {
            new FeatureStyle() { Id = 1, FeatureId = 1, StyleId = 1},
            new FeatureStyle() { Id = 2, FeatureId = 1, StyleId = 2},
            new FeatureStyle() { Id = 3, FeatureId = 2, StyleId = 2},
            new FeatureStyle() { Id = 4, FeatureId = 2, StyleId = 3}
        };

        private static List<Style> _styles = new List<Style>()
        {
            new Style() {Id=1, Name = "Style A"},
            new Style() {Id=2, Name = "Style B"},
            new Style() {Id=3, Name = "Style C"}
        };

        public LookupDataViewModel ListStylesForFeature(int featureId)
        {
            var feature = _features.Single(f => f.Id == featureId);
            var styles = _featureStyles
                .Where(fs => fs.FeatureId == featureId)
                .Join(_styles, s => s.StyleId, s2 => s2.Id, (f, s) => s);

            var viewModel = new LookupDataViewModel();
            viewModel.DefaultItemId = feature.DefaultStyleId;
            viewModel.Items.AddRange(styles
                .Select(s => new LookupDataItem()
                {
                    Id = s.Id,
                    Name = s.Name
                }
                ));
            return viewModel;
        }
    }
}
