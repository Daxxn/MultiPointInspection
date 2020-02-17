using Caliburn.Micro;
using MultiPointInspection.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiPointInspection.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private MainViewModel _mainViewModel;
        private CurrentROViewModel _currentROViewModel;
        private InspectionViewModel _inspectionViewModel;
        private CreateRepairOrderViewModel _createRepairOrderViewModel;
        #endregion

        #region - Constructors
        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            MainModel = new MainViewModel(windowManager, eventAggregator);
            CurrentROModel = new CurrentROViewModel(windowManager, eventAggregator);
            InspectionModel = new InspectionViewModel(windowManager, eventAggregator);
            CreateRepairOrderModel = new CreateRepairOrderViewModel(windowManager, eventAggregator);

            ActivateItem(MainModel);
        }
        #endregion

        #region - Methods
        #region Tabs
        public void TabMainView()
        {
            ActivateItem(MainModel);
        }

        public void TabCurrentView()
        {
            _eventAggregator.PublishOnUIThread(new ViewCurrentROTabEvent(MainModel.SelectedRepairOrder));
            ActivateItem(CurrentROModel);
        }

        public void TabInspectionView()
        {
            _eventAggregator.PublishOnUIThread(new ViewInspectionTabEvent(MainModel.SelectedRepairOrder));
            ActivateItem(InspectionModel);
        }

        public void CreateRO(  )
        {
            _windowManager.ShowWindow(CreateRepairOrderModel);
        }
        #endregion
        #endregion

        #region - Properties
        public MainViewModel MainModel
        {
            get { return _mainViewModel; }
            set
            {
                _mainViewModel = value;
            }
        }

        public CurrentROViewModel CurrentROModel
        {
            get { return _currentROViewModel; }
            set
            {
                _currentROViewModel = value;
            }
        }

        public InspectionViewModel InspectionModel
        {
            get { return _inspectionViewModel; }
            set
            {
                _inspectionViewModel = value;
            }
        }

        public CreateRepairOrderViewModel CreateRepairOrderModel
        {
            get { return _createRepairOrderViewModel; }
            set
            {
                _createRepairOrderViewModel = value;
            }
        }
        #endregion
    }
}
