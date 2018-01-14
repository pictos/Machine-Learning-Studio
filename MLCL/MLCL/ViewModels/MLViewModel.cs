using MLCL.Model;
using MLCL.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;

namespace MLCL.ViewModels
{
    public class MLViewModel : BaseViewModel
    {
        #region Propriedades
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); ServicoCommand.ChangeCanExecute(); EnviarCommand.ChangeCanExecute(); }
        }


        private string _relativeCompactness;

        public string RelativeCompactness
        {
            get { return _relativeCompactness; }
            set { _relativeCompactness = value; OnPropertyChanged(); }
        }

        private string _surfaceArea;

        public string SurfaceArea
        {
            get { return _surfaceArea; }
            set { _surfaceArea = value;OnPropertyChanged(); }
        }

        private string _wallArea;

        public string WallArea
        {
            get { return _wallArea; }
            set { _wallArea = value; OnPropertyChanged(); }
        }

        private string _roofArea;

        public string RoofArea
        {
            get { return _roofArea; }
            set { _roofArea = value; OnPropertyChanged(); }
        }

        private string _overallHeight;

        public string OverallHeight
        {
            get { return _overallHeight; }
            set { _overallHeight = value;OnPropertyChanged(); }
        }

        private string _orientation;

        public string Orientation
        {
            get { return _orientation; }
            set { _orientation = value; OnPropertyChanged(); }
        }

        private string _glazingArea;

        public string GlazingArea
        {
            get { return _glazingArea; }
            set { _glazingArea = value; OnPropertyChanged(); }
        }

        private string _glazingAreaDistribution;

        public string GlazingAreaDistribution
        {
            get { return _glazingAreaDistribution; }
            set { _glazingAreaDistribution = value; OnPropertyChanged(); }
        }

        private string _heatingLoad;

        public string HeatingLoad
        {
            get { return _heatingLoad; }
            set { _heatingLoad = value; OnPropertyChanged(); }
        }

        private string _pontos;

        public string Pontos
        {
            get { return _pontos; }
            set { _pontos = value; OnPropertyChanged(); }
        }

        RespostaString Resposta;
        MLModelo ml;
        Inputs _inputs;
        ObservableCollection<Input1> _input1 { get; set; }
        MLService mLService;
#endregion
        public Command ServicoCommand { get; }
        public Command EnviarCommand { get; }

        public MLViewModel()
        {
            mLService = new MLService();
            _input1 = new ObservableCollection<Input1>();
            
            EnviarCommand = new Command(async () => await ExecuteEnviarCommand(), () => !IsBusy);
            ServicoCommand = new Command(async () => await ExecuteServicoCommand(), () => !IsBusy);
        }

        async Task ExecuteEnviarCommand()
        {
            _input1.Add(new Input1
            {
                RelativeCompactness = RelativeCompactness,
                Orientation = Orientation,
                SurfaceArea = SurfaceArea,
                WallArea = WallArea,
                RoofArea = RoofArea,
                OverallHeight = OverallHeight,
                GlazingArea = GlazingArea,
                GlazingAreaDistribution = GlazingAreaDistribution,
                HeatingLoad = HeatingLoad
            });
            _inputs = new Inputs(_input1);
            ml = new MLModelo(_inputs);
            Resposta = await mLService.MLServico(ml);
            await ExibeResultado(Resposta);
        }

        async Task ExecuteServicoCommand()
        {
            Resposta = await mLService.MLServicoExemploAsync();
          await  ExibeResultado(Resposta);
        }

        async Task ExibeResultado(RespostaString respostaString)
        {
            var seila = respostaString.Results.Output1;

            foreach (var item in seila)
            {
                await DisplayAlert("Resultado", $"O valor de Cooling Load : {item.ScoredLabels}","Ok");
            }

        }
    }
}
