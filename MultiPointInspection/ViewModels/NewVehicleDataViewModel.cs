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

		private int[] _errorCode = new int[] { 10 };
		private int _errorBackground = 0;
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
			// Dads VIN : KMHD84LF3HU153568
			// Jasons VIN : JHMGE8H52DC071704
			// Jasons BAD VIN : JHZGE8H52DC071704
			if (VINInput.Length == 17)
			{
				NotSearching = false;

				Vehicle = await VehicleData.RequestVINAsync(VINInput);
				ErrorCodes = Vehicle.ErrorCode;

				UpdateVehicle();

                #region OLD
                //VINJsonModel inputVINData = await VINController.LoadVIN(VINInput);

                //ErrorCode = ParseError(inputVINData.Results[ 4 ].Value);
                //if (ErrorCode == 0)
                //{
                //	VINParser parser = new VINParser();
                //	parser.VINData = inputVINData;
                //	Vehicle.RawData = parser.ParseVINResults();
                //	Vehicle.ConvertRawData();

                //	UpdateVehicle();
                //}
                #endregion

                NotSearching = true;
			}
		}

		private int ParseError( string errorVariable )
		{
			bool success = Int32.TryParse(errorVariable[0].ToString(), out int errorOut);
			return (success) ? errorOut : 100;
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

		public int[] ErrorCodes
		{
			get { return _errorCode; }
			set
			{
				_errorCode = value;
				NotifyOfPropertyChange(( ) => ErrorCodes);
				NotifyOfPropertyChange(( ) => ErrorDisplay);
				NotifyOfPropertyChange(( ) => ErrorBackground);
			}
		}

		public string ErrorDisplay
		{
			get
			{
				string output = "";
				foreach (var error in ErrorCodes)
				{
					if (error == 10)
					{
						output += "\n";
					}
					else if (error == 0)
					{
						output += "No Errors\n";
					}
					else if (error == 1)
					{
						output += "VIN Checksum didnt match any known VINs in database. Possibly an Off-Road Vehicle.\n";
					}
					else if (error == 6)
					{
						output += "Incomplete VIN. Some data wont be filled in.\n";
					}
					else if (error == 400)
					{
						output += "Incorrect Letters entered, such as 'I', 'O', or 'Q'.\n";
					}
					else if (error == 7)
					{
						output += "Manufacturer is not registered with NHTSA.\n";
					}
					else
					{
						output += "Unknown Error\n";
					}
				}
				return output;
			}
		}

		public int ErrorBackground
		{
			get
			{
				int output = 0;

				
				if (ErrorCodes[0] == 10)
				{
					return 0;
				}
				else if (ErrorCodes[0] == 0)
				{
					return 0;
				}
				else if (ErrorCodes[0] == 1)
				{
					return 1;
				}
				else if (ErrorCodes[0] == 6)
				{
					return 1;
				}
				else if (ErrorCodes[0] == 400)
				{
					return 2;
				}
				
				return output;
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
