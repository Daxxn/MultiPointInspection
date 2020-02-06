using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        public MainViewModel mainViewModel { get; set; }

        #region Constructors
        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            mainViewModel = new MainViewModel(windowManager, eventAggregator);

            ActivateItem(mainViewModel);
        }
        #endregion
    }
}
