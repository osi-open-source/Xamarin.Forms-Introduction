using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassicNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailClassicMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailClassicMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailClassicMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailClassicMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailClassicMasterMenuItem> MenuItems { get; set; }

            public MasterDetailClassicMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailClassicMasterMenuItem>(new[]
                {
                    new MasterDetailClassicMasterMenuItem { Id = 0, Title = "Page 1", TargetType = typeof(MainPage) },
                    new MasterDetailClassicMasterMenuItem { Id = 1, Title = "Page 2", TargetType = typeof(SecondPage) },
                    new MasterDetailClassicMasterMenuItem { Id = 2, Title = "Detail explanation", TargetType = typeof(MasterDetailClassicDetail) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}