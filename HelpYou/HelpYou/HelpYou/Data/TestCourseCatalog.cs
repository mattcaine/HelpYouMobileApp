using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace HelpYou.Data
{
  public class TestCourseCatalog
    {
        ObservableCollection<Course> courses = new ObservableCollection<Course>();

        public TestCourseCatalog()
        {
            courses.Add(new Course
            {
                Id = "SW400",
                Name = "Intro to Software",
                Building = "Bannow",
                Room = "201a",
                Days = "1,3",
                StartTime = "09:00:00",
                EndTime = "10:15:00"
            });
            courses.Add(new Course
            {
                Id = "SW410",
                Name = "Advanced Software Engineering",
                Building = "Bannow",
                Room = "310",
                Days = "2,4",
                StartTime = "13:00:00",
                EndTime = "15:30:00"
            });
            courses.Add(new Course
            {
                Id = "SW499",
                Name = "Data Mining",
                Building = "Bannow",
                Room = "246",
                Days = "3",
                StartTime = "17:30:00",
                EndTime = "21:00:00"
            });
        }

        public bool AddCourse(Course course)
        {
            courses.Add(course);
            return true;
        }

        public bool DeleteCourse(string id)
        {
            List<Course> CoursesToRemove = FindCourseById(id);

            foreach (Course CourseToRemove in CoursesToRemove)
            {
                courses.Remove(CourseToRemove);
                Debug.WriteLine("Removing course with Id '" + id + "'");
            }

            return true;
        }

        public ObservableCollection<Course> GetAllCourses()
        {
            return courses;
        }

        public Course GetCourseDetail(string Id)
        {
            return courses.FirstOrDefault(c => c.Id == Id);
        }

        public bool UpdateCourse(String OriginalId, Course course)
        {
            List<Course> CoursesToRemove = FindCourseById(OriginalId);

            foreach (Course CourseToRemove in CoursesToRemove)
            {
                courses.Remove(CourseToRemove);
                Debug.WriteLine("Removing course with Id '" + OriginalId + "'");
            }
            courses.Add(course);

            return true;
        }

        private List<Course> FindCourseById(String Id)
        {
            return courses.Where(c => c.Id == Id).ToList();
        }
    }
}