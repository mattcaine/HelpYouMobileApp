using System;
using System.Collections.ObjectModel;
using HelpYou.Data;
using Xamarin.Forms;

namespace HelpYou.Pages
{
    public partial class CoursePage : ContentPage
    {
        private ICourseCatalog<Course> LocalCourseCatalog = (Application.Current as App).LocalCourseCatalog;

        public CoursePage()
        {
            InitializeComponent();
            SetUIText();

            CourseList.ItemTapped += (sender, args) =>
            {
                EditCourse(sender, args);
            };
        }

        private void SetUIText()
        {
            Title = ApplicationResources.CourseButtonText;
            CourseList.ItemsSource = LocalCourseCatalog.GetAllCourses();
            AddCourseButton.Text = ApplicationResources.AddCourseButtonText;
        }

        private void AddCourse(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditCoursePage(null));
        }

        private void EditCourse(object sender, Xamarin.Forms.ItemTappedEventArgs args)
        {
            Navigation.PushAsync(new EditCoursePage((Course)args.Item));
        }
    }
}