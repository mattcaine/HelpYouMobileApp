using System;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using SQLite;
using System.Linq;

namespace HelpYou.Data
{
    public class LocalSQLCourseCatalog : ICourseCatalog<Course>
    {
        ObservableCollection<Course> courses = new ObservableCollection<Course>();
        SQLiteConnection Database { get; }
        public static string RootPath { get; set; } = string.Empty;

        public LocalSQLCourseCatalog()
        {
            var DatabasePath = Path.Combine(RootPath, "FairfieldSW416Group2.db");
            Database = new SQLiteConnection(DatabasePath, true);
            Database.CreateTable<Course>();

            foreach (Course SingleCourse in Database.Table<Course>().ToList())
            {
                courses.Add(SingleCourse);
            }
        }

        public bool AddCourse(Course course)
        {
            Database.Insert(course);
            courses.Add(course);
            return true;
        }

        public bool DeleteCourse(string id)
        {
            List<Course> CoursesToRemove = FindCourseById(id);

            foreach (Course CourseToRemove in CoursesToRemove)
            {
                Database.Delete(CourseToRemove);
                courses.Remove(CourseToRemove);
                Debug.WriteLine("Removing course with Id '" + id + "'");
            }

            return true;
        }

        public ObservableCollection<Course> GetAllCourses()
        {
            return courses;
        }

        public Course GetCourseDetail(string id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateCourse(String OriginalId, Course course)
        {
            List<Course> CoursesToRemove = FindCourseById(OriginalId);

            foreach (Course CourseToRemove in CoursesToRemove)
            {
                Database.Delete(CourseToRemove);
                courses.Remove(CourseToRemove);
                Debug.WriteLine("Removing course with Id '" + OriginalId + "'");
            }
            Database.Insert(course);
            courses.Add(course);

            return true;
        }

        private List<Course> FindCourseById(String id)
        {
            return courses.Where(c => c.Id == id).ToList();
        }
    }
}