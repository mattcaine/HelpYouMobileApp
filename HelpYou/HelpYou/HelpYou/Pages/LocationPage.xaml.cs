using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelpYou.Pages
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
            SetUIText();
        }

        private void SetUIText()
        {
            Title = ApplicationResources.LocationButtonText;
        }
    }
}