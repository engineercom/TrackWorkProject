using Microsoft.EntityFrameworkCore;
using TrackWorkProject.WebUI.Entities;

namespace TrackWorkProject.WebUI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Check if the database is already seeded
                if (!context.Directorates.Any())
                {
                    context.Directorates.AddRange(
                        new Directorate { Name = "IT Department" },
                        new Directorate { Name = "HR Department" },
                        new Directorate { Name = "Finance Department" }
                    );
                    context.SaveChanges();
                }
               
               
                if (!context.Duties.Any())
                { 
                context.Duties.AddRange(
                    new Duty { Name = "Software Development", DirectorateId = context.Directorates.FirstOrDefault(d => d.Name == "IT Department")!.Id },
                    new Duty { Name = "Recruitment", DirectorateId = context.Directorates.FirstOrDefault(d => d.Name == "HR Department")!.Id },
                    new Duty { Name = "Budgeting", DirectorateId = context.Directorates.FirstOrDefault(d => d.Name == "Finance Department")!.Id }
                );
                    context.SaveChanges();

                }
                if (!context.Personels.Any())
                {
                    context.Personels.AddRange(
                        new Personel { FullName = "John Doe" },
                        new Personel { FullName = "Jane Smith" },
                        new Personel { FullName = "Alice Johnson" }

                    );
                    context.SaveChanges();
                }
                if (!context.PersonelDuties.Any())
                {
                    context.PersonelDuties.AddRange(
                        new PersonelDuty { PersonelId = context.Personels.FirstOrDefault(p => p.FullName == "John Doe")!.Id, DutyId = context.Duties.FirstOrDefault(d => d.Name == "Software Development")!.Id },
                        new PersonelDuty { PersonelId = context.Personels.FirstOrDefault(p => p.FullName == "Jane Smith")!.Id, DutyId = context.Duties.FirstOrDefault(d => d.Name == "Recruitment")!.Id },
                        new PersonelDuty { PersonelId = context.Personels.FirstOrDefault(p => p.FullName == "Alice Johnson")!.Id, DutyId = context.Duties.FirstOrDefault(d => d.Name == "Budgeting")!.Id },
                        new PersonelDuty { PersonelId = context.Personels.FirstOrDefault(p => p.FullName == "John Doe")!.Id, DutyId = context.Duties.FirstOrDefault(d => d.Name == "Budgeting")!.Id }
                        );
                    context.SaveChanges();
                }
                // Seed initial data here
                // Example: context.Users.Add(new ApplicationUser { ... });

               
            }
        }
    }
}
