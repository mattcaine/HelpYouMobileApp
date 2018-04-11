using System;
using System.Diagnostics;
using HelpYou.Data;
using Xamarin.Forms;

namespace HelpYou.Pages
{
    public partial class DaysPage : ContentPage
    {
        private CourseDays CurrentCourseDays;

        public DaysPage(ref CourseDays coursedays)
        {
            InitializeComponent();
            CurrentCourseDays = coursedays;
            SetUIText();
        }

        private void SetUIText()
        {
            Title = ApplicationResources.CourseButtonText;
            SelectDaysButton.Text = ApplicationResources.SelectButtonText;
            DaysList.ItemsSource = CurrentCourseDays.GetDays();
        }

        private void SelectDays(object sender, EventArgs args)
        {

            Navigation.PopAsync();
        }

        private void DeSelectListView(object sender, ItemTappedEventArgs args)
        {
            if (args.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}