using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelpYou.Pages
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            SetUIText();
        }

        private void SetUIText()
        {
            Title = ApplicationResources.PostButtonText;
        }
    }
}