using Caliburn.Micro;
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
        #endregion

        #region - Constructors
        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            _mainViewModel = new MainViewModel(windowManager, eventAggregator);
            _currentROViewModel = new CurrentROViewModel(windowManager, eventAggregator);
            _inspectionViewModel = new InspectionViewModel(windowManager, eventAggregator);

            ActivateItem(MainViewModel);
        }
        #endregion

        #region - Methods
        #region Tabs
        public void TabMainView()
        {
            ActivateItem(MainViewModel);
        }

        public void TabCurrentView()
        {
            ActivateItem(CurrentROViewModel);
        }

        public void TabInspectionView()
        {
            ActivateItem(InspectionViewModel);
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
        #endregion
    }
}
