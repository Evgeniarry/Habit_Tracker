using Habit_Tracker.Model;
using Habit_Tracker.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Habit_Tracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Load();
        }
        protected override async void OnAppearing()
        {
            habitsCollection.ItemsSource = await App.DB.GetHabitsAsync();
        }
        public void Load()
        {
            labelDate.Text = DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("ru"));
            //labelDate.Text = s[0].ToString().ToUpper() + s.Substring(1);
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());  
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null) 
            {
                Habit habit = (Habit)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(EditPage.ItemID)}=" +
                    $"{habit.ID.ToString()}");
                //await DisplayAlert(habit.Name, habit.Description, "OK");
                //await Navigation. ($"{nameof(AddHabit)}?{nameof(AddHabit.ItemID)}={habit.ID.ToString()}"); 
            }
        }
    }
}
