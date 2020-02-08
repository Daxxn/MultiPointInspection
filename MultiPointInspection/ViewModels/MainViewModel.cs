using Caliburn.Micro;
using MultiPointInspection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.ViewModels
{
    public class MainViewModel : Screen
	{
        #region - Fields & Properties
        private IWindowManager _windowManager;
		private IEventAggregator _eventAggregator;

        private RepairOrderModel _repairOrderModel;
		#endregion

		#region - Constructors
		public MainViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
		{
			_windowManager = windowManager;
			_eventAggregator = eventAggregator;
			_eventAggregator.Subscribe(this);
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties
        public RepairOrderModel RepairOrderModel
        {
            get { return _repairOrderModel; }
            set
            {
                _repairOrderModel = value;
                NotifyOfPropertyChange(() => RepairOrderModel);
            }
        }
		#endregion
	}
}
