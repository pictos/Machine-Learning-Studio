using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MLCL.Model
{
    public class MLModelo
    {
        [JsonProperty("Inputs")]
        public Inputs Inputs { get; set; }
        [JsonProperty("GlobalParameters")]
        public Globalparameters GlobalParameters { get; set; }

        public MLModelo(Inputs inputs) => Inputs = inputs;
    }

    public class Inputs
    {
        [JsonProperty("input1")]
        public ObservableCollection<Input1> Input1 { get; set; }
        //public Input1[] Input1 { get; set; }

        public Inputs(ObservableCollection<Input1> input1) => Input1 = input1;
    }

    public class Input1
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
    }

    public class Globalparameters
    {
    }


}
