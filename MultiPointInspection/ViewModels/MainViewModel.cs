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
            RepairOrderList = new BindableCollection<RepairOrder>() {
                new RepairOrder()
                {
                    RepairOrderNumber = 123456,
                    Vehicle = new VehicleData()
                    {
                        VIN = "Test VIN 1",
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
                },

                new RepairOrder()
                {
                    RepairOrderNumber = 123457,
                    Vehicle = new VehicleData()
                    {
                        VIN = "Test VIN 2",
                        Year = 2009,
                        Make = "Toyota",
                        Model = "Camry",
                        Color = "grey"
                    },
                    Inspection = new Inspection()
                    {
                        Components = new List<Component>()
                    },
                    Repairs = new List<RepairAction>()
                    {
                        new RepairAction()
                        {
                            RepairName = "Replace front brake pads, resurface rotors.",
                            ActionID = 20,
                            Description = "Replace front brake pads, grease slide pins, replace brake hardware, resurface rotors."
                        }
                    },
                    Status = new RepairStatus()
                    {
                        Name = "Tech Working on vehicle",
                        ID = 2
                    }
                }
            };
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
