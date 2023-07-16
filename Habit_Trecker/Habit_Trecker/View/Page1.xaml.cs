using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Habit_Tracker.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Habit_Tracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private string TODO_LIST_PROP_NAME = "todos";

        private HabitViewModel _habitViewModel;
        public Page1()
        {
            InitializeComponent();
            _habitViewModel = new HabitViewModel();
            BindingContext = _habitViewModel;

            // Load todo list from the app properties
            if (Application.Current.Properties.ContainsKey(TODO_LIST_PROP_NAME))
            {
                var list = Application.Current.Properties[TODO_LIST_PROP_NAME].ToString();
                _habitViewModel.Deserialize(list);
            }

            _habitViewModel.PropertyChanged += _habitViewModel_PropertyChanged;
        }
        private void _habitViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = _habitViewModel.Serialize();
            Application.Current.Properties[TODO_LIST_PROP_NAME] = list;
        }
        private void Save()
        {
            var list = _habitViewModel.Serialize();
            Application.Current.Properties[TODO_LIST_PROP_NAME] = list;
        }

        public void OnDone(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _habitViewModel.CheckItem((Model.Habit)mi.CommandParameter);
            Save();
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _habitViewModel.DeleteItem((Model.Habit)mi.CommandParameter);
            Save();
        }

        private async Task NewItem()
        {
            string result = await DisplayPromptAsync("New item", "Please enter the title");
            if (result != null)
            {
                _habitViewModel.AddItem(result);
                Save();
            }
        }

        public void OnFabMenuClick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(
                    async () =>
                    {
                        await NewItem();
                    });

            });
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Save();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }
    }
}

        