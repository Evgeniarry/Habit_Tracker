using System;
using Xamarin.Forms;

namespace Habit_Tracker
{
	public partial class HelloPage : ContentPage
	{
		public HelloPage ()
		{
            InitializeComponent ();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }

    }
}