using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Habit_Tracker.Model;

namespace Habit_Tracker
{
	public partial class HelloPage : ContentPage
	{
		public HelloPage ()
		{
			InitializeComponent ();
            Load();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public async void Load()
        {
            List<DayModel> list = await App.DB.GetDaysAsync(0);
            int c = await App.DB.GetDaysCount();
            c += await App.DB.GetHabitCount();
            if (c != 0)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}