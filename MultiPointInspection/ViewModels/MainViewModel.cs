using Caliburn.Micro;
using DataModels;
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

		private BindableCollection<RepairOrder> _repairOrderList;
		private RepairOrder _selectedRepairOrder;
		#endregion

		#region - Constructors
		public MainViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
		{
			_windowManager = windowManager;
			_eventAggregator = eventAggregator;
			_eventAggregator.Subscribe(this);

            RepairOrderList = new BindableCollection<RepairOrder>();

            #region TESTING
            RepairOrderList.Add(new RepairOrder()
            {
                RepairOrderNumber = 123456,
                Vehicle = new VehicleData()
                {
                    VIN = "VIN Test",
                    Year = 2018,
                    Make = "Toyota",
                    Model = "RAV4"
                },
                Inspection = new Inspection()
                {
                    Components = new List<Component>()
                    {
                        new Component("Brakes"),
                        new Component("Tread Depth"),
                        new Component("Engine Filter")
                    },

                },
                Status = new RepairStatus()
                {
                    Name = "In Progress",
                    ID = 1
                },
                Repairs = new List<RepairAction>()
                {
                    new RepairAction()
                    {
                        RepairName = "Oil change and tire rotate.",
                        ActionID = 10,
                        Description = "Replace engine oil and filter, rotate tires, check tire pressure, and complete multipoint inspection."
                    }
                }
            });
            #endregion
        }
        #endregion

        #region - Methods

        #endregion

        #region - Full Properties
        public BindableCollection<RepairOrder> RepairOrderList
        {
            get { return _repairOrderList; }
            set
            {
				_repairOrderList = value;
                NotifyOfPropertyChange(() => RepairOrderList);
            }
        }

		public RepairOrder SelectedRepairOrder
        {
			get { return _selectedRepairOrder; }
			set
			{
				_selectedRepairOrder = value;
				NotifyOfPropertyChange(() => SelectedRepairOrder);
			}
		}
		#endregion
	}
}
