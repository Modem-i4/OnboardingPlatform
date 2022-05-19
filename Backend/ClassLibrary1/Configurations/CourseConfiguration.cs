using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class CourseConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "C# is the most beautiful language!",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/C_Sharp_wordmark.svg/120px-C_Sharp_wordmark.svg.png",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec est felis, interdum eu est vitae, mattis lacinia mi." +
                    " Donec nulla dui, luctus at molestie quis, commodo in lectus. In vitae accumsan metus, in ornare diam. Duis a nibh odio."
                },
                new Course
                {
                    Id = 2,
                    Name = "Mono is a free and open-source .NET Framework-compatible software framework.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b4/Mono_project_logo.svg/81px-Mono_project_logo.svg.png",
                    Description = "When Microsoft first announced their .NET Framework in June 2000 it was described as, and in December of that year the underlying Common Language Infrastructure was published as an open standard," +
                    " opening up the potential for independent implementations. Miguel de Icaza of Ximian believed that .NET"
                },
                new Course
                {
                    Id = 3,
                    Name = "Xamarin is a Microsoft-owned San Francisco-based software company founded.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Xamarin-logo.svg/330px-Xamarin-logo.svg.png",
                    Description = "With a C#-shared codebase, developers can use Xamarin tools to write native Android, iOS, and Windows apps with native user interfaces and share code across multiple platforms, including Windows, macOS, and Linux." +
                    "According to Xamarin, over 1.4 million developers were using Xamarin's products in 120 countries around the world as of April 2017.[5]"
                });
        }
    }
}
