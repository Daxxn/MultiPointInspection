using Caliburn.Micro;
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
		#endregion

		#region - Constructors
		public MainViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
		{
			_windowManager = windowManager;
			_eventAggregator = eventAggregator;
			_eventAggregator.Subscribe(this);
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
