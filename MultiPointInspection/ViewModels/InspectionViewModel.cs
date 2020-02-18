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
using MultiPointInspection.EventModels;

namespace MultiPointInspection.ViewModels
{
    public class InspectionViewModel : Screen, IHandle<ViewInspectionTabEvent>
    {
        #region - Fields
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;

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
            InspectionData = new Inspection()
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
        public void CompleteInspection(  )
        {
            CurrentInspection.InspectionData = CurrentInspectionData.ToList();
            _eventAggregator.PublishOnUIThread(new InspectionCompletedEvent(CurrentInspection));
        }
        #endregion

        #region Event Messages
        public void InspectionResult( dynamic box, Result result, ActionExecutionContext data_1 )
        {
            MessageBox.Show(box.ToString() + result);
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
