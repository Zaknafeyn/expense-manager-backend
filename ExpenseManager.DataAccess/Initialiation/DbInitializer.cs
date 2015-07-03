using System.Collections.Generic;
using System.Data.Entity;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.DataAccess
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ExpenseManagerContext>
    {
        protected override void Seed(ExpenseManagerContext context)
        {
            SeedProfiles(context);
            SeedTournaments(context);

            context.SaveChanges();
        }

        private void SeedProfiles(ExpenseManagerContext context)
        {
            context.Profiles.Add(new Profile
            {
                Id = 1,
                Email = "test@gmail.com",
                Name = "Andrey",
                Login = "test@gmail.com",
                HasCar = true
            });

            context.Profiles.Add(new Profile
            {
                Id = 2,
                Email = "test2@gmail.com",
                Name = "Andrey",
                Login = "test2@gmail.com",
                HasCar = false
            });

            context.Profiles.Add(new Profile
            {
                Id = 3,
                Email = "admin@test.com",
                Name = "Admin",
                Login = "admin@test.com",
                HasCar = false
            });

            context.Profiles.Add(new Profile
            {
                Id = 4,
                Email = "manager@test.com",
                Name = "Manager",
                Login = "manager@test.com",
                HasCar = false
            });

            context.Profiles.Add(new Profile
            {
                Id = 5,
                Email = "user@test.com",
                Name = "User",
                Login = "user@test.com",
                HasCar = false
            });
        }

        private void SeedTournaments(ExpenseManagerContext context)
        {
            var tournamentsList = new List<Tournament>
            {
                new Tournament
                {
                    Name = "ZChU'2010",
                    Place = "Lutsk",
                    Year = 2010
                },
                new Tournament
                {
                    Name = "BBG'2010",
                    Place = "Brest",
                    Year = 2010
                },
                new Tournament
                {
                    Name = "PChU'2010",
                    Place = "Odessa",
                    Year = 2010
                },
                new Tournament
                {
                    Name = "OChU'2010",
                    Place = "Lvov",
                    Year = 2010
                },
                new Tournament
                {
                    Name = "ZChU'2011",
                    Place = "Lutsk",
                    Year = 2011
                },
                new Tournament
                {
                    Name = "BBG'2011",
                    Place = "Brest",
                    Year = 2011
                },
                new Tournament
                {
                    Name = "PChU'2011",
                    Place = "Ilyechevsk",
                    Year = 2011
                },
                new Tournament
                {
                    Name = "OChU'2011",
                    Place = "Ivano-Frankivsk",
                    Year = 2011
                },
                new Tournament
                {
                    Name = "ZChU'2021",
                    Place = "Lutsk",
                    Year = 2012
                },
                new Tournament
                {
                    Name = "BBG'2012",
                    Place = "Brest",
                    Year = 2012
                },
                new Tournament
                {
                    Name = "PChU'2012",
                    Place = "Ilyechevsk",
                    Year = 2012
                },
                new Tournament
                {
                    Name = "OChU'2012",
                    Place = "Kyiv",
                    Year = 2012
                },
            };

            context.Tournaments.AddRange(tournamentsList);
        }
    }
}