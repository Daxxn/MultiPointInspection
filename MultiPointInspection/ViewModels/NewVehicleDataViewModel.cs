using Caliburn.Micro;
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
		#region Buttons
		public async Task SearchVIN( )
		{
			if (VINInput.Length == 17)
			{
				VINJsonModel newVin = await VINController.LoadVIN(VINInput);
				VINInput = newVin.SearchCriteria;
			}
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
		#endregion
	}
}
