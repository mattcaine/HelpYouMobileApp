using Xamarin.Forms;
using System.Diagnostics;
using System;

namespace HelpYou.Pages
{
    public partial class FairfieldSW416Group2Page : ContentPage
    {
        public FairfieldSW416Group2Page()
        {
            InitializeComponent();
            SetUIText();
        }

        private void SetUIText()
        {
            Title = ApplicationResources.HomeButtonText;
            WelcomeLabel.Text = ApplicationResources.WelcomeLabelText;
            CourseButton.Text = ApplicationResources.CourseButtonText;
            LocationButton.Text = ApplicationResources.LocationButtonText;
            PostButton.Text = ApplicationResources.PostButtonText;
        }

        //Determines what button was clicked and opens a new page
        async private void OnButtonClick(object sender, EventArgs args)
        {
            Button ClickedButton = (Button)sender;
            if (ClickedButton.ClassId.Equals("CourseButton"))
            {
                await Navigation.PushAsync(new CoursePage());
            }
            else if (ClickedButton.ClassId.Equals("LocationButton"))
            {
                await Navigation.PushAsync(new LocationPage());
            }
            else if (ClickedButton.ClassId.Equals("PostButton"))
            {
                await Navigation.PushAsync(new PostPage());
            }
            else
            {
                Debug.WriteLine("Button with Id '" + ClickedButton.ClassId + "' was not expected.");
            }
        }
    }
}