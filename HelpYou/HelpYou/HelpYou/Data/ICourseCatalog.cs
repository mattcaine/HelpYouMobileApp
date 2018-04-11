using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace HelpYou.Data
{
   public interface ICourseCatalog<T>
    {
        bool AddCourse(T course);
        bool UpdateCourse(string OriginalId, T course);
        bool DeleteCourse(string id);
        T GetCourseDetail(string id);
        ObservableCollection<T> GetAllCourses();
    }
}
