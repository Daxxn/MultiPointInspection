using Caliburn.Micro;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VINDecoderLib;

namespace MultiPointInspection.ViewModels
{
    public class NewVehicleDataViewModel : Screen
    {
        #region - Fields & Properties
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private string _vinInput;
        private int _yearInput;
        private string _makeInput;
        private string _modelInput;
        private string _colorInput;

		private VehicleData _vehicle;
        #endregion

        #region - Constructors
        public NewVehicleDataViewModel( IWindowManager windowManager, IEventAggregator eventAggregator )
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
		#endregion

		#region - Methods
		public void Reset(  )
		{
			VINInput = null;
			YearInput = 0;
			MakeInput = null;
			ModelInput = null;
			ColorInput = null;
		}

        private void UpdateVehicle()
        {
            VINInput = Vehicle.VIN;
            YearInput = Vehicle.ModelYear;
            MakeInput = Vehicle.Make;
            ModelInput = Vehicle.Model;
            ColorInput = Vehicle.Color;
        }
		#region Buttons
		public async void SearchVIN( )
		{
			if (VINInput.Length == 17)
			{
                Vehicle = new VehicleData();
				VINJsonModel inputVINData = await VINController.LoadVIN(VINInput);
				Vehicle.VIN = inputVINData.SearchCriteria;
				VINParser parser = new VINParser();
				parser.VINData = inputVINData;
				Vehicle.RawData = parser.ParseVINResults();
				Vehicle.ConvertRawData();

                UpdateVehicle();
			}
		}

		public void ParseVIN( VINJsonModel vinData )
		{
			VINParser parser = new VINParser()
			{
				VINData = vinData
			};
			Vehicle.RawData = parser.ParseVINResults();
			Vehicle.ConvertRawData();
		}
		#endregion
		#endregion

		#region - Full Properties
		public string VINInput
		{
			get { return _vinInput; }
			set
			{
				_vinInput = value;
				NotifyOfPropertyChange(( ) => VINInput);
			}
		}

		public int YearInput
		{
			get { return _yearInput; }
			set
			{
				_yearInput = value;
				NotifyOfPropertyChange(( ) => YearInput);
			}
		}

		public string MakeInput
		{
			get { return _makeInput; }
			set
			{
				_makeInput = value;
				NotifyOfPropertyChange(( ) => MakeInput);
			}
		}

		public string ModelInput
		{
			get { return _modelInput; }
			set
			{
				_modelInput = value;
				NotifyOfPropertyChange(( ) => ModelInput);
			}
		}

		public string ColorInput
		{
			get { return _colorInput; }
			set
			{
				_colorInput = value;
				NotifyOfPropertyChange(( ) => ColorInput);

			}
		}

		public VehicleData Vehicle
		{
			get { return _vehicle; }
			set
			{
				_vehicle = value;
                NotifyOfPropertyChange(() => Vehicle);
			}
		}
		#endregion
	}
}
