using System;
using Xamarin.Forms;

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
            int c = await App.DB.GetDaysCount();
            c += await App.DB.GetHabitCount();
            if (c != 0)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}