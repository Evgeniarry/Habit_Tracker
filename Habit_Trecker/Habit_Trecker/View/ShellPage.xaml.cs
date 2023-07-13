using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Habit_Tracker.View
{
    public partial class ShellPage : Shell
    {
        public ShellPage()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StatisticPage), typeof(StatisticPage));
        }
    }
}