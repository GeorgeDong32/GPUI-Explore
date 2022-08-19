using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using GPUI_UWPTS.Core.Models;
using GPUI_UWPTS.Core.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using MicaForUWP.Media;
using GPUI_UWPTS.Services;


namespace GPUI_UWPTS.Views
{
    public sealed partial class DataPage : Page, INotifyPropertyChanged
    {

        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        private List<BackgroundSource> BackgroundSources = new List<BackgroundSource>()
        {
            MicaForUWP.Media.BackgroundSource.Backdrop,
            MicaForUWP.Media.BackgroundSource.HostBackdrop,
            MicaForUWP.Media.BackgroundSource.MicaBackdrop,
        };

        public DataPage()
        {
            InitializeComponent();
            Loaded += DataPage_Loaded;
        }

        private async void DataPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetListDetailsDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (ListDetailsViewControl.ViewState == ListDetailsViewState.Both)
            {
                Selected = SampleItems.FirstOrDefault();
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
