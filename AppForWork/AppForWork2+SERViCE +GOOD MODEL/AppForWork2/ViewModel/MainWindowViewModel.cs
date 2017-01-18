using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AppForWork2.Model;
using Cars.Vehicles;
using CarStationService;
using Prism.Commands;

namespace AppForWork2.ViewModel
{

    public sealed class MainWindowViewModel:INotifyPropertyChanged

    {
        // ReSharper disable once MemberCanBePrivate.Global
        public ApplicationModel Model { get; }

        public MainWindowViewModel()
        {
            this.Model = new ApplicationModel();

            this.SetListenerOnModel();
        }

        #region DelegateCommand

        //USED SINGLETONE

        #region Delegate Command fields
        private DelegateCommand newVehicleCommand;
        private DelegateCommand dellAllFromXmlCommand;
        private DelegateCommand saveVehicleCommand;
        private DelegateCommand removeSelectedVehicleCommand;
        private DelegateCommand<ExtendedVehicle> repareVehicleCommand;
        #endregion

        #region Delegate Command Property
        public DelegateCommand NewVehicleCommand
            => this.newVehicleCommand ?? (this.newVehicleCommand = new DelegateCommand(this.Model.NewVehicle));

        public DelegateCommand DellAllFromXMLCommand
            => this.dellAllFromXmlCommand ?? (this.dellAllFromXmlCommand = new DelegateCommand(this.Model.RemoveAllVehicles, this.CanRemoveAll));

        public DelegateCommand SaveVehicleCommand
            => this.saveVehicleCommand ?? (this.saveVehicleCommand = new DelegateCommand(this.Model.Save, this.CanSave));

        public DelegateCommand RemoveSelectedVehicleCommand
            => this.removeSelectedVehicleCommand ?? (this.removeSelectedVehicleCommand = new DelegateCommand(this.Model.RemoveSelectedVehicle, this.CanRemove));

        public DelegateCommand<ExtendedVehicle> RepareVehicleCommand
            => this.repareVehicleCommand ?? (this.repareVehicleCommand = new DelegateCommand<ExtendedVehicle>(this.Model.RepairVehicle));
        #endregion

        #endregion

        #region CanExecute
        public bool CanSave()
        {
            bool result = (!this.Model.SelectedVehicle?.IsItemSaved) ?? false;
            return result;
        } //returns true if selected vehicle isn't saved and != null

        public bool CanRemove()
        {
            bool result = this.Model.SelectedVehicle != null;
            return result;
        } //returns true if selected vehicle != null

        public bool CanRemoveAll()
        {
            bool result = this.Model.CarStation?.Vehicles?.Any() ?? false;
            return result;
        } //returns true if selected vehicle != null
        #endregion

        #region Methods
        private void SetListenerOnModel()
        {
            if (this.Model!=null)
            {
                (this.Model as INotifyPropertyChanged).PropertyChanged -= this.ModelChanged;
                (this.Model as INotifyPropertyChanged).PropertyChanged += this.ModelChanged;
            }
        }

        private void ModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.Model.SelectedVehicle))
            {
                this.SaveVehicleCommand.RaiseCanExecuteChanged();
                this.RemoveSelectedVehicleCommand.RaiseCanExecuteChanged();
                this.DellAllFromXMLCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region INotifyPropertyCanged Implemented
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}