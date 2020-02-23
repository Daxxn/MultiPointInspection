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

		private int _errorCode = 10;
		private string _errorDisplay;
		private bool _notSearching = true;
        #endregion

        #region - Constructors
        public NewVehicleDataViewModel( IWindowManager windowManager, IEventAggregator eventAggregator )
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
			Vehicle = new VehicleData();
        }
		#endregion

		#region - Methods
		public void Reset(  )
		{
			Vehicle = new VehicleData();
			VINInput = null;
			YearInput = 0;
			MakeInput = null;
			ModelInput = null;
			ColorInput = null;
		}
		#region Buttons
		public async void SearchVIN( )
		{
			// Dads VIN : KMHD84LF3HU153568
			// Jasons VIN : JHMGE8H52DC071704
			// Jasons BAD VIN : JHZGE8H52DC071704
			if (VINInput.Length == 17)
			{
				NotSearching = false;
				VINJsonModel inputVINData = await VINController.LoadVIN(VINInput);

				ErrorCode = ParseError(inputVINData.Results[ 4 ].Value);
				if (ErrorCode == 0)
				{
					VINParser parser = new VINParser();
					parser.VINData = inputVINData;
					Vehicle.RawData = parser.ParseVINResults();
					Vehicle.ConvertRawData();

					UpdateVehicle();
				}

				NotSearching = true;
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

		private int ParseError( string errorVariable )
		{
			bool success = Int32.TryParse(errorVariable[0].ToString(), out int errorOut);
			return (success) ? errorOut : 100;
		}

		private void UpdateVehicle(  )
		{
			YearInput = Vehicle.ModelYear;
			MakeInput = Vehicle.Make;
			ModelInput = Vehicle.Model;
			ColorInput = Vehicle.Color;
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
			}
		}

		public int ErrorCode
		{
			get { return _errorCode; }
			set
			{
				_errorCode = value;
				NotifyOfPropertyChange(( ) => ErrorCode);
				NotifyOfPropertyChange(( ) => ErrorDisplay);
			}
		}

		public string ErrorDisplay
		{
			get
			{
				if (ErrorCode == 10)
				{
					return "";
				}
				else if (ErrorCode == 0)
				{
					return "No Errors";
				}
				else if (ErrorCode == 1)
				{
					return "VIN Checksum didnt match any known VINs in database.";
				}
				else
				{
					return "Unknown Error";
				}
			}
		}

		public bool NotSearching
		{
			get { return _notSearching; }
			set
			{
				_notSearching = value;
				NotifyOfPropertyChange(( ) => NotSearching);
			}
		}
		#endregion
	}
}
