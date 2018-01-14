using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MLCL.Model
{

    public class RespostaString
    {
        public Results Results { get; set; }
    }

    public class Results
    {
        //public Output1[] Output1 { get; set; }
        public ObservableCollection<Output1> Output1 { get; set; }
    }

    public class Output1
    {
        [JsonProperty("Relative Compactness")]
        public string RelativeCompactness { get; set; }
        [JsonProperty("Surface Area")]
        public string SurfaceArea { get; set; }
        [JsonProperty("Wall Area")]
        public string WallArea { get; set; }
        [JsonProperty("Roof Area")]
        public string RoofArea { get; set; }
        [JsonProperty("Overall Height")]
        public string OverallHeight { get; set; }
        [JsonProperty("Orientation")]
        public string Orientation { get; set; }
        [JsonProperty("Glazing Area")]
        public string GlazingArea { get; set; }
        [JsonProperty("Glazing Area Distribution")]
        public string GlazingAreaDistribution { get; set; }
        [JsonProperty("Heating Load")]
        public string HeatingLoad { get; set; }
        [JsonProperty("Cooling Load")]
        public string CoolingLoad { get; set; }
        [JsonProperty("Scored Labels")]
        public string ScoredLabels { get; set; }
    }



}
