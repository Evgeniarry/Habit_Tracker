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
            
            labelDate.Text = DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("ru"));
        }
        List<Habit> hab;
        protected override async void OnAppearing()
        {
            hab = await App.DB.GetHabitsAsync();

            habitsCollection.ItemsSource = hab;
        }
        
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());  
        }

        int selectedCount = 0;
        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            DayModel model = new DayModel();
            //Habit habit = (Habit)((Switch)sender).BindingContext;
            Switch switch1 = (Switch)sender;
            //switch1.BindingContext.
            //habit = (Habit)sender;
            //AddDaySwitch

            //var habs = (Habit)BindingContext;
            
            if (switch1.IsToggled)
            {
                model.Day = DateTime.Now.Day;
                model.Month = DateTime.Now.Month;
                //habs.IsSelected = true;
                //model.HabitID = habit.ID;
                await App.DB.SaveDayAsync(model);
                //await App.DB.GetHabitAsync();
                selectedCount++;
            }
            else
            {
                //habs.IsSelected = false;
                selectedCount--;
            }
            //await App.DB.SaveHabitAsync(habs);
            await DisplayAlert("mess", selectedCount.ToString(), "ok");
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null) 
            {
                Habit habit = (Habit)e.CurrentSelection.FirstOrDefault();
                //habit.IsSelected = true;
                //await App.DB.SaveHabitAsync(habit);
                await Navigation.PushAsync(new EditPage(habit.ID));
            }
            //Habit habit = (Habit)e.CurrentSelection.FirstOrDefault();
            //if (habit.IsSelected == true)
            //{
            //    habit.IsSelected = false;
            //}
            //else
            //    habit.IsSelected = true;
            //await App.DB.SaveHabitAsync(habit);
        }
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Page1());
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var b = (Button)sender;

        //    var v = b.CommandParameter as 
        //    var ob = v;

        //   if (ob != null)
        //   {

        //    // retrieve the value from the ‘ob’ and continue your work.

        //   }
        //}
    }
}
//private void checkBox_CheckChanged(object sender, CheckedChangedEventArgs e)
//{
//    var checkbox = (CheckBox)sender;

//    var ob = checkbox.BindingContext as <Habit>;

//    if (ob != null)
//        Habit habit = (Habit)((CheckBox)sender).BindingContext;
//    if (habit.Togg)
//    {
//        selectedCount++;
//    }
//    else
//    {
//        selectedCount--;
//    }


//}
