using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LookupDataSample.ModelFive
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultStyleId { get; private set; }

        private List<FeatureStyle> _featureStyles = new List<FeatureStyle>();

        public List<Style> Styles { get; set; }

        public void AddStyle(Style style)
        {
            if (_featureStyles.Any(s => s.StyleId == style.Id)) return;
            _featureStyles.Add(new FeatureStyle() {FeatureId = this.Id, StyleId = style.Id});
        }

        public void UpdateDefaultStyle(int styleId)
        {
            if (!_featureStyles.Any(fs => fs.StyleId == styleId)) return; // or throw
            DefaultStyleId = styleId;
        }
    }
}
