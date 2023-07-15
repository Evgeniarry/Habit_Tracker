using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Habit_Tracker.Model;
using Habit_Tracker.View;

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
            List<Habit> hab = await App.DB.GetHabitsAsync();
            int c = hab.Count;
            if (c != 0)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}