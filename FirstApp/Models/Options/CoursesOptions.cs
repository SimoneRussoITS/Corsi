namespace FirstApp.Models.Options
{
    using System.Collections.Generic;
    
    public partial class CoursesOptions
    {
        public Courses Courses { get; set; }
    }

    public partial class Courses
    {
        public CoursesOrderOptions Order { get; set; }

        public long PerPage { get; set; }
    }

    public partial class CoursesOrderOptions
    {
        public string By { get; set; }

        public bool Ascending { get; set; }

        public List<string> Allow { get; set; }
    }
}
