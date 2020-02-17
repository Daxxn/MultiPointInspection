using Caliburn.Micro;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.ViewModels
{
    public class NewRepairsViewModel : Screen
    {
        #region - Fields & Properties
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private RepairAction  _selectedAction;
        private BindableCollection<RepairAction> _repairs;

        private string _repairName;
        private string _repairDescription;
        #endregion

        #region - Constructors
        public NewRepairsViewModel( IWindowManager windowManager, IEventAggregator eventAggregator )
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            Repairs = new BindableCollection<RepairAction>();
        }
        #endregion

        #region - Methods
        public void Reset(  )
        {
            RepairName = null;
            RepairDescription = null;
            Repairs = new BindableCollection<RepairAction>();
            SelectedAction = null;
        }
        #region Buttons
        public void AddRepair(  )
        {
            Repairs.Add(new RepairAction()
                {
                    RepairName = RepairName,
                    Description = RepairDescription,
                    ActionID = Repairs.Count + 1
                }
            )
            ;
        }

        public void RemoveRepair(  )
        {
            Repairs.Remove(SelectedAction);

            ResetIndex();
        }

        private void ResetIndex( )
        {
            for (int i = 0; i < Repairs.Count; i++)
            {
                Repairs[ i ].ActionID = i + 1;
            }
            Refresh();
        }
        #endregion
        #endregion

        #region - Full Properties
        public BindableCollection<RepairAction> Repairs
        {
            get { return _repairs; }
            set
            {
                _repairs = value;
                NotifyOfPropertyChange(( ) => Repairs);
            }
        }
        public string RepairName
        {
            get { return _repairName; }
            set
            {
                _repairName = value;
                NotifyOfPropertyChange(( ) => RepairName);
            }
        }

        public string RepairDescription
        {
            get { return _repairDescription; }
            set
            {
                _repairDescription = value;
                NotifyOfPropertyChange(( ) => RepairDescription);
            }
        }
        public RepairAction SelectedAction
        {
            get { return _selectedAction; }
            set
            {
                _selectedAction = value;
                NotifyOfPropertyChange(( ) => SelectedAction);
            }
        }
        #endregion
    }
}
