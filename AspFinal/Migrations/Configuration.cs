namespace AspFinal.Migrations
{
    using AspFinal.Models.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspFinal.Models.AspFinalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspFinal.Models.AspFinalDbContext context)
        {
            try
            {
                if (!context.PersonDetails.Any())
                {
                    context.PersonDetails.AddRange(new[]
                {
                        new PersonDetails
                        {
                                Name = "Cavid Mehdi-bayli",
                                Email = "javidnm@code.edu.az",
                                Phone = "+994504178989",
                                Age = 18,
                                CareerLevel ="Web Developer",
                                Degree="Junioe",
                                Experience = "1 years",
                                Fax = "+994504178989",
                                Location = "Baku",
                                MediaUrl ="",
                                Website = "cmgroup.az",
                        }
                    });
                }

                if (!context.Admin.Any())
                {
                    context.Admin.AddRange(new[]
                    {
                        new Admin
                        {
                                Email ="javidnm@code.edu.az",
                                 Password = "cavid123",
                                 CreatedDate=DateTime.Now
                        }
                    });
                }


                if (!context.Skills.Any())
                {
                    context.Skills.AddRange(new[]
                {
                        new Skills
                        {
                                Name = "C#",
                        },
                        new Skills
                        {
                                Name = "ASP.Net",
                        },
                        new Skills
                        {
                                Name = "Java-Script",
                        },
                        new Skills
                        {
                                Name ="JQuery",
                        },
                        new Skills
                        {
                                Name = "HTML5",
                        },
                        new Skills
                        {
                                Name = "CSS3",
                        }
                    });
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new[]
                {
                        new Categories
                        {
                                Name = "Web Developer",
                        },
                        new Categories
                        {
                                Name = "Frontend Developer",
                        },
                        new Categories
                        {
                                Name = "Backend Developer",
                        },
                        new Categories
                        {
                                Name = "Designer",
                        },
                        new Categories
                        {
                                Name ="Coder",
                        },
                        new Categories
                        {
                                Name = "System Adminstration",
                        },
                        new Categories
                        {
                                Name = "Help Desk",
                        }
                    });
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
