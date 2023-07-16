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
            List<Habit>hab = await App.DB.GetHabitsAsync();
            int c = hab.Count;
            if (c != 0)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}