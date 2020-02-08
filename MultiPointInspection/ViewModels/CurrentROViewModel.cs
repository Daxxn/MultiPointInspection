using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MultiPointInspection.ViewModels
{
    public class CurrentROViewModel : Screen
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;
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

        #endregion

        #region - Properties

        #endregion
    }
}
