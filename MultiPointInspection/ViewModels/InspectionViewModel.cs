using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using DataModels;
using DataModels.Json;
using DataModels.Models;
using DataModels.Models.Enums;
using DataModels.Models.Interfaces;
using JsonControlLib;
using MultiPointInspection.EventModels;

namespace MultiPointInspection.ViewModels
{
    public class InspectionViewModel : Screen, IHandle<ViewInspectionTabEvent>
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

        private AddInspectElementViewModel AddInspectElement { get; set; }

        private RepairOrder _currentRepairOrder;

        public Inspection InspectionData { get; set; }

        private string _fileName;
        private Inspection _currentInspection;
        private BindableCollection<Inspect> _currentInspectionData;
        #endregion

        #region - Constructors
        public InspectionViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            CurrentInspection = new Inspection();
            CurrentInspectionData = new BindableCollection<Inspect>();
            #region Testing ONLY
            CurrentInspection = new Inspection()
            {
                Name = "Test",
                InspectionData = new List<Inspect>()
                {
                    new Inspect()
                    {
                        Title = "Front Brake pads",
                        Category = InspectionCategory.Brakes,
                        Description = "Measure front brake pad thickness",
                        Measurement = 10,
                        Result = Result.NA,
                        Specs = null
                    },
                    new Inspect()
                    {
                        Title = "Rear Brake pads",
                        Category = InspectionCategory.Brakes,
                        Description = "Measure rear brake pad thickness",
                        Measurement = 7,
                        Result = Result.Normal,
                        Specs = null
                    },
                    new Inspect()
                    {
                        Title = "Inspect Headlights",
                        Category = InspectionCategory.Lighting,
                        Description = "Inspect Headlights for proper operation.",
                        Measurement = 7,
                        Result = Result.NA,
                        Specs = null
                    },
                }
            };

            CurrentInspectionData = new BindableCollection<Inspect>( CurrentInspection.InspectionData );
            #endregion
        }
        #endregion

        #region - Methods
        #region Buttons
        public void SaveInspection(  )
        {
            JsonController.SaveJsonToFolder(Properties.Settings.Default.DefaultInspectionFolder, FileName, InspectionData);
        }
        public void OpenInspection(  )
        {
            CurrentInspection = JsonController.OpenJsonFile<Inspection>(Properties.Settings.Default.DefaultInspectionFolder, FileName);
            CurrentInspectionData = new BindableCollection<Inspect>(CurrentInspection.InspectionData);
            FileName = CurrentInspection.Name;
        }
        public void AddInspection(  )
        {
            AddInspectElement = new AddInspectElementViewModel(_windowManager, _eventAggregator);
            _windowManager.ShowDialog(AddInspectElement);
            Inspect temp = new Inspect()
            {

            };
        }
        public void RemoveInspection(  )
        {
            // Probably not possible to remove a selected item??
        }
        public void CompleteInspection(  )
        {
            CurrentInspection.InspectionData = CurrentInspectionData.ToList();
            _eventAggregator.PublishOnUIThread(new InspectionCompletedEvent(CurrentInspection));
        }
        #endregion

        #region Event Messages
        /// <summary>
        /// Doesnt work properly. more testing needed. The checkboxes dont update after the selection.
        /// </summary>
        public void InspectionResult( Inspect box, Result result, dynamic good, dynamic fair, dynamic normal, dynamic poor, dynamic bad, dynamic na )
        {
            if (result == Result.Good)
            {
                good = true;

                fair = false;
                normal = false;
                poor = false;
                bad = false;
                na = false;
            }
            else if (result == Result.Fair)
            {
                good = false;

                fair = true;

                normal = false;
                poor = false;
                bad = false;
                na = false;
            }
            else if (result == Result.Normal)
            {
                good = false;
                fair = false;

                normal = true;

                poor = false;
                bad = false;
                na = false;
            }
            else if (result == Result.Poor)
            {
                good = false;
                fair = false;
                normal = false;

                poor = true;

                bad = false;
                na = false;
            }
            else if (result == Result.Bad)
            {
                good = false;
                fair = false;
                normal = false;
                poor = false;

                bad = true;

                na = false;
            }
            else if (result == Result.NA)
            {
                good = false;
                fair = false;
                normal = false;
                poor = false;
                bad = false;

                na = true;
            }

            box.Result = result;
            NotifyOfPropertyChange(( ) => box);
            //MessageBox.Show(box.ToString() + result);
        }

        #endregion
        public void Handle(ViewInspectionTabEvent message)
        {
            if (message.SelectedRO != null)
            {
                CurrentInspection = message.SelectedRO.Inspection;
                CurrentInspectionData = new BindableCollection<Inspect>(CurrentInspection.InspectionData);
            }
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
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                NotifyOfPropertyChange(( ) => FileName);
            }
        }

        public Inspection CurrentInspection
        {
            get { return _currentInspection; }
            set
            {
                _currentInspection = value;
                NotifyOfPropertyChange(( ) => CurrentInspection);
            }
        }
        public BindableCollection<Inspect> CurrentInspectionData
        {
            get { return _currentInspectionData; }
            set
            {
                _currentInspectionData = value;
                NotifyOfPropertyChange(( ) => CurrentInspectionData);
            }
        }

        
        #endregion
    }
}
