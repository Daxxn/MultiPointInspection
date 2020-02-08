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
    public class InspectionViewModel : Screen, IHandle<ViewInspectionTabEvent>
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private RepairOrder _currentRepairOrder;
        #endregion

        #region - Constructors
        public InspectionViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        #endregion

        #region - Methods
        public void Handle(ViewInspectionTabEvent message)
        {
            CurrentRepairOrder = message.SelectedRO;
        }
        #endregion

        #region - Properties
        public RepairOrder CurrentRepairOrder
        {
            get { return _currentRepairOrder; }
            set
            {
                _currentRepairOrder = value;
            }
        }
        #endregion
    }
}
