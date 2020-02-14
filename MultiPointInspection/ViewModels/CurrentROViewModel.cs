using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataModels;
using MultiPointInspection.EventModels;

namespace MultiPointInspection.ViewModels
{
    public class CurrentROViewModel : Screen, IHandle<ViewCurrentROTabEvent>
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private RepairOrder _currentRO;
        private BindableCollection<RepairAction> _repairDisplay;
        private RepairAction _selectedRepair;
        #endregion

        #region - Constructors
        public CurrentROViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        #endregion

        #region - Methods
        public void Handle(ViewCurrentROTabEvent message)
        {
            CurrentRepairOrder = message.RO;
            if (CurrentRepairOrder != null)
            {
                RepairDisplay = new BindableCollection<RepairAction>(CurrentRepairOrder.Repairs);
            }
        }
        #endregion

        #region - Properties
        public RepairOrder CurrentRepairOrder
        {
            get { return _currentRO; }
            set
            {
                _currentRO = value;
                NotifyOfPropertyChange(() => CurrentRepairOrder);
            }
        }

        public BindableCollection<RepairAction> RepairDisplay
        {
            get { return _repairDisplay; }
            set
            {
                _repairDisplay = value;
                NotifyOfPropertyChange(() => RepairDisplay);
            }
        }

        public RepairAction SelectedRepair
        {
            get { return _selectedRepair; }
            set
            {
                _selectedRepair = value;
                NotifyOfPropertyChange(() => SelectedRepair);
            }
        }
        #endregion
    }
}
