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

        private int _selectedView = 0;
        #endregion

        #region - Constructors
        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            MainViewModel = new MainViewModel(windowManager, eventAggregator);
            CurrentROViewModel = new CurrentROViewModel(windowManager, eventAggregator);
            InspectionViewModel = new InspectionViewModel(windowManager, eventAggregator);
            CreateRepairOrderViewModel = new CreateRepairOrderViewModel(windowManager, eventAggregator);

            ActivateItem(MainViewModel);
        }
        #endregion

        #region - Methods
        #region Tabs
        public void TabMainView(  )
        {
            ActivateItem(MainViewModel);
            SelectedView = 0;
        }

        public void TabCurrentView(  )
        {
            _eventAggregator.PublishOnUIThread(new ViewCurrentROTabEvent(MainViewModel.SelectedRepairOrder));
            ActivateItem(CurrentROViewModel);
            SelectedView = 1;
        }

        public void TabInspectionView(  )
        {
            _eventAggregator.PublishOnUIThread(new ViewInspectionTabEvent(MainViewModel.SelectedRepairOrder));
            ActivateItem(InspectionViewModel);
            SelectedView = 2;
        }

        public void CreateRO(  )
        {
            CreateRepairOrderViewModel.Reset();
            _windowManager.ShowWindow(CreateRepairOrderViewModel);
        }
        #endregion
        #endregion

        #region - Properties
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set
            {
                _mainViewModel = value;
            }
        }

        public CurrentROViewModel CurrentROViewModel
        {
            get { return _currentROViewModel; }
            set
            {
                _currentROViewModel = value;
            }
        }

        public InspectionViewModel InspectionViewModel
        {
            get { return _inspectionViewModel; }
            set
            {
                _inspectionViewModel = value;
            }
        }

        public CreateRepairOrderViewModel CreateRepairOrderViewModel
        {
            get { return _createRepairOrderViewModel; }
            set
            {
                _createRepairOrderViewModel = value;
            }
        }
        public int SelectedView
        {
            get { return _selectedView; }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    _selectedView = value;
                }
                else
                {
                    _selectedView = 0;
                    throw new Exception("Selected view index out of range.");
                }
                NotifyOfPropertyChange(( ) => SelectedView);
            }
        }
        #endregion
    }
}
