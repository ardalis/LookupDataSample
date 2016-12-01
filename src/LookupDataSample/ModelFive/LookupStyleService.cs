using System.Collections.Generic;
using System.Linq;

namespace LookupDataSample.ModelFive
{
    public class LookupStyleService
    {
        private static List<Feature> _features = new List<Feature>()
        {
            new Feature() {Id = 1, Name = "Feature One"},
            new Feature() {Id = 2, Name = "Feature Two"}
        };

        private static List<Style> _styles = new List<Style>()
        {
            new Style() {Id=1, Name = "Style A"},
            new Style() {Id=2, Name = "Style B"},
            new Style() {Id=3, Name = "Style C"}
        };

        static LookupStyleService()
        {
            var feature1 = _features.First();
            feature1.AddStyle(_styles.First());
            feature1.AddStyle(_styles.Skip(1).First());
            feature1.UpdateDefaultStyle(1);

            var feature2 = _features.Last();
            feature2.AddStyle(_styles.Skip(1).First());
            feature2.AddStyle(_styles.Last());
            feature2.UpdateDefaultStyle(3);
        }

        public LookupDataViewModel ListStylesForFeature(int featureId)
        {
            var feature = _features.Single(f => f.Id == featureId);

            var viewModel = new LookupDataViewModel();
            viewModel.DefaultItemId = feature.DefaultStyleId;
            viewModel.Items.AddRange(feature.Styles
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
