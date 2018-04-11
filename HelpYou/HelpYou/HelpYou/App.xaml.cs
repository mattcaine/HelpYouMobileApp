using HelpYou.Data;
using Xamarin.Forms;

namespace HelpYou
{
    public partial class App : Application
    {
        //TODO Finish implementing device storage via SQLite
        public ICourseCatalog<Course> LocalCourseCatalog = new LocalSQLCourseCatalog();
        //public ICourseCatalog<Course> LocalCourseCatalog = new TestCourseCatalog();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FairfieldSW416Group2Page());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}