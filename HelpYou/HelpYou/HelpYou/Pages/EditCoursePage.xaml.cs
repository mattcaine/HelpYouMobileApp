using System;
using System.Diagnostics;
using Xamarin.Forms;
using HelpYou.Data;
using System.Collections.Generic;

namespace HelpYou.Pages
{
    public partial class EditCoursePage : ContentPage
    {
        private ICourseCatalog<Course> LocalCourseCatalog = (Application.Current as App).LocalCourseCatalog;
        private String Action;
        private String OriginalId;
        private Course CurrentCourse;
        private CourseDays CurrentCourseDays;

        public EditCoursePage()
        {
            InitializeComponent();
            Action = "Add";
            CurrentCourseDays = new CourseDays();
            SetUIText();
        }
            
        public EditCoursePage(Course EditCourse)
        {
            InitializeComponent();
            CurrentCourseDays = new CourseDays();
            if (EditCourse == null)
            {
                Action = "Add";
                CurrentCourse = new Course();
            }
            else
            {
                Action = "Edit";
                CurrentCourse = EditCourse;
                OriginalId = EditCourse.Id;
                if (CurrentCourse.Days.Length > 0)
                {
                    if (CurrentCourse.Days.Contains(","))
                    {
                        foreach (string DayId in CurrentCourse.Days.Split(','))
                        {
                            CurrentCourseDays.SetSelectedValue(int.Parse(DayId), true);
                        }
                    }
                    else
                    {
                        CurrentCourseDays.SetSelectedValue(int.Parse(CurrentCourse.Days), true);
                    }
                }
            }
            SetUIText();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CurrentCourse.Days = CurrentCourseDays.GetSelectedDaysToString();
            SetUIText();
        }

        private void SetUIText()
        {
            if (Action.Equals("Add"))
            {
                Title = ApplicationResources.AddCourseButtonText;
                ProcessCourseButton.Text = ApplicationResources.AddNewCourseButtonText;
                DeleteCourseButton.IsVisible = false;
            }
            else
            {
                Title = ApplicationResources.ViewEditText;
                ProcessCourseButton.Text = ApplicationResources.EditCourseButtonText;
                DeleteCourseButton.Text = ApplicationResources.DeleteCourseButtonText;
                DeleteCourseButton.IsVisible = true;

                this.FindByName<Entry>("CourseId").Text = CurrentCourse.Id;
                this.FindByName<Entry>("CourseName").Text = CurrentCourse.Name;
                this.FindByName<Entry>("CourseBuilding").Text = CurrentCourse.Building;
                this.FindByName<Entry>("CourseRoom").Text = CurrentCourse.Room;
                this.FindByName<TimePicker>("CourseStartTime").Time = DateTime.Parse(CurrentCourse.StartTime).TimeOfDay;
                this.FindByName<TimePicker>("CourseEndTime").Time = DateTime.Parse(CurrentCourse.EndTime).TimeOfDay;
            }
            this.FindByName<Button>("CourseDays").Text = GetDayButtonText();
        }

        private void ProcessCourse(object sender, EventArgs args)
        {
            if (string.IsNullOrWhiteSpace(this.FindByName<Entry>("CourseId").Text))
            {
                DisplayAlert(ApplicationResources.ErrorTitle, ApplicationResources.ErrorEmptyIdMessage, ApplicationResources.OkText);
            }
            else if (string.IsNullOrWhiteSpace(this.FindByName<Entry>("CourseName").Text))
            {
                DisplayAlert(ApplicationResources.ErrorTitle, ApplicationResources.ErrorEmptyNameMessage, ApplicationResources.OkText);
            }
            else if (this.FindByName<Button>("CourseDays").Text.Equals("Select Days"))
            {
                DisplayAlert(ApplicationResources.ErrorTitle, ApplicationResources.ErrorSelectDayMessage, ApplicationResources.OkText);
            }
            else if (string.IsNullOrWhiteSpace(this.FindByName<TimePicker>("CourseStartTime").ToString()))
            {
                DisplayAlert(ApplicationResources.ErrorTitle, ApplicationResources.ErrorEmptyStartTimeMessage, ApplicationResources.OkText);
            }
            else if (string.IsNullOrWhiteSpace(this.FindByName<TimePicker>("CourseEndTime").ToString()))
            {
                DisplayAlert(ApplicationResources.ErrorTitle, ApplicationResources.ErrorEmptyEndTimeMessage, ApplicationResources.OkText);
            }
            else
            {
                Course NewCourse = new Course
                {
                    Id = this.FindByName<Entry>("CourseId").Text,
                    Name = this.FindByName<Entry>("CourseName").Text,
                    Building = this.FindByName<Entry>("CourseBuilding").Text,
                    Room = this.FindByName<Entry>("CourseRoom").Text,
                    Days = CurrentCourseDays.GetSelectedDaysToString(),
                    StartTime = this.FindByName<TimePicker>("CourseStartTime").Time.ToString(),
                    EndTime = this.FindByName<TimePicker>("CourseEndTime").Time.ToString()
                };

                if (Action.Equals("Add"))
                {
                    LocalCourseCatalog.AddCourse(NewCourse);
                }
                else
                {
                    LocalCourseCatalog.UpdateCourse(OriginalId, NewCourse);
                }
                Navigation.PopAsync();
            }
        }

        private async void DeleteCourse(object sender, EventArgs args)
        {
            var answer = await DisplayAlert(ApplicationResources.DeleteConfirmationTitle, ApplicationResources.DeleteConfirmationMessage, ApplicationResources.YesText, ApplicationResources.NoText);
            if (answer)
            {
                LocalCourseCatalog.DeleteCourse(OriginalId);
                await Navigation.PopAsync();
            }
        }

        private async void SelectDays(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DaysPage(ref CurrentCourseDays));
        }

        private string GetDayButtonText()
        {
            string SelectedDays = "";
            if (string.IsNullOrEmpty(CurrentCourse.Days))
            {
                return ApplicationResources.SelectDaysButtonText;
            }

            Debug.WriteLine("CurrentCourse.Days = '" + CurrentCourse.Days + "'");
            if (CurrentCourse.Days.Length > 0)
            {
                if (CurrentCourse.Days.Contains(","))
                {
                    foreach (string DayId in CurrentCourse.Days.Split(','))
                    {
                        if (string.IsNullOrEmpty(SelectedDays))
                        {
                            SelectedDays = CurrentCourseDays.GetName(int.Parse(DayId));
                        }
                        else
                        {
                            SelectedDays = SelectedDays + ", " + CurrentCourseDays.GetName(int.Parse(DayId));
                        }
                    }
                }
                else
                {
                    SelectedDays = CurrentCourseDays.GetName(int.Parse(CurrentCourse.Days));
                }
            }

            if (string.IsNullOrEmpty(SelectedDays))
            {
                SelectedDays = ApplicationResources.SelectDaysButtonText;
            }

            return SelectedDays;
        }
    }
}