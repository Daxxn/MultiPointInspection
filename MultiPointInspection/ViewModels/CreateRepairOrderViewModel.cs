using Caliburn.Micro;
using DataModels;
using DataModels.Models;
using MultiPointInspection.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiPointInspection.ViewModels
{
    public class CreateRepairOrderViewModel : Conductor<object>
	{
		#region - Fields & Properties
		private Random RND { get; set; }
		private IWindowManager _windowManager;
		private IEventAggregator _eventAggregator;


		public NewVehicleDataViewModel NewVehicleDataViewModel { get; set; }
		public NewRepairsViewModel NewRepairsViewModel { get; set; }

		private bool _enableInspection;
		private int _RONumber;
		private RepairOrder _newRO;
		#endregion

		#region - Constructors
		public CreateRepairOrderViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
		{
			_windowManager = windowManager;
			_eventAggregator = eventAggregator;
			_eventAggregator.Subscribe(this);

			NewRepairsViewModel = new NewRepairsViewModel(windowManager, eventAggregator);
			NewVehicleDataViewModel = new NewVehicleDataViewModel(windowManager, eventAggregator);
			RND = new Random();
			NewRO = new RepairOrder();

			ActivateItem(NewVehicleDataViewModel);
		}
		#endregion

		#region - Methods
		public void Reset(  )
		{
			NewRO = new RepairOrder();
			RONumber = 0;
			NewVehicleDataViewModel.Reset();
			NewRepairsViewModel.Reset();
		}
		#region Buttons
		public void GenerateRONumber(  )
		{
			RONumber = RND.Next(100000, 999999);
		}

		public void ViewVehicleData(  )
		{
			ChangeActiveItem(NewVehicleDataViewModel, false);
		}

		public void ViewRepairsData(  )
		{
			ChangeActiveItem(NewRepairsViewModel, false);
		}
		public void CreateRepairOrder(  )
		{
			_eventAggregator.PublishOnUIThread(new CreateROEvent(new RepairOrder()
			{
				RepairOrderNumber = RONumber,
				Vehicle = new VehicleData()
				{
					VIN = NewVehicleDataViewModel.VINInput,
					ModelYear = NewVehicleDataViewModel.YearInput,
					Make = NewVehicleDataViewModel.MakeInput,
					Model = NewVehicleDataViewModel.ModelInput
				},
				Inspection = EnableInspection ? new Inspection() : null,
				Repairs = NewRepairsViewModel.Repairs.ToList(),
				Status = new RepairStatus()
			})
			);
			TryClose();
		}
		#endregion
		#endregion

		#region - Full Properties
		public RepairOrder NewRO
		{
			get { return _newRO; }
			set
			{
				_newRO = value;
				NotifyOfPropertyChange(( ) => NewRO);
			}
		}
		public bool EnableInspection
		{
			get { return _enableInspection; }
			set
			{
				_enableInspection = value;
				NotifyOfPropertyChange(( ) => EnableInspection);
			}
		}
		public int RONumber
		{
			get { return _RONumber; }
			set
			{
				_RONumber = value;
				NotifyOfPropertyChange(( ) => RONumber);
			}
		}
		#endregion
	}
}
