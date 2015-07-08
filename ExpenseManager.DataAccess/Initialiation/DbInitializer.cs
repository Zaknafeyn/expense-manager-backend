using System;
using System.Collections.Generic;
using System.Data.Entity;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.DataAccess.Initialiation
{
    public class DbInitializer : DropCreateDatabaseAlways<ExpenseManagerContext>
    //    public class DbInitializer : DropCreateDatabaseIfModelChanges<ExpenseManagerContext>
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
                HasCar = true,
                CarName = "Test car name",
                PasswordHash = "5b37040e6200edb3c7f409e994076872"
            });

            context.Profiles.Add(new Profile
            {
                Id = 2,
                Email = "test2@gmail.com",
                Name = "Andrey",
                Login = "test2@gmail.com",
                HasCar = false,
                PasswordHash = "3c4f419e8cd958690d0d14b3b89380d3"
            });

            context.Profiles.Add(new Profile
            {
                Id = 3,
                Email = "admin@test.com",
                Name = "Admin",
                Login = "admin@test.com",
                HasCar = false,
                PasswordHash = "5b37040e6200edb3c7f409e994076872"
            });

            context.Profiles.Add(new Profile
            {
                Id = 4,
                Email = "manager@test.com",
                Name = "Manager",
                Login = "manager@test.com",
                HasCar = false,
                PasswordHash = "ad5c2c75bd08bbf326ace2a8addf1e05"
            });

            context.Profiles.Add(new Profile
            {
                Id = 5,
                Email = "user@test.com",
                Name = "User",
                Login = "user@test.com",
                HasCar = false,
                PasswordHash = "1460318498c1f53bb880ce2e6d9ef64b"
            });
        }

        private void SeedTournaments(ExpenseManagerContext context)
        {
            var year = 2010;
            var tournamentsList = new List<Tournament>();
            tournamentsList.AddRange(new List<Tournament>
            {
                new Tournament
                {
                    Name = "ZChU'2010",
                    Place = "Lutsk",
                    Year = year,
                    StartDate = new DateTime(year, 3, 20 ),
                    EndDate = new DateTime(year, 3, 22 ),
                },
                new Tournament
                {
                    Name = "BBG'2010",
                    Place = "Brest",
                    Year = year,
                    StartDate = new DateTime(year, 5, 20 ),
                    EndDate = new DateTime(year, 5, 22 ),
                },
                new Tournament
                {
                    Name = "PChU'2010",
                    Place = "Odessa",
                    Year = year,
                    StartDate = new DateTime(year, 7, 20 ),
                    EndDate = new DateTime(year, 7, 22 ),
                },
                new Tournament
                {
                    Name = "OChU'2010",
                    Place = "Lvov",
                    Year = year,
                    StartDate = new DateTime(year, 9, 20 ),
                    EndDate = new DateTime(year, 9, 22 ),
                }});

            year = 2011;
            tournamentsList.AddRange(new List<Tournament>
            { 
                new Tournament
                {
                    Name = "ZChU'2011",
                    Place = "Lutsk",
                    Year = year,
                    StartDate = new DateTime(year, 3, 20 ),
                    EndDate = new DateTime(year, 3, 22 ),
                },
                new Tournament
                {
                    Name = "BBG'2011",
                    Place = "Brest",
                    Year = year,
                    StartDate = new DateTime(year, 5, 20 ),
                    EndDate = new DateTime(year, 5, 22 ),
                },
                new Tournament
                {
                    Name = "PChU'2011",
                    Place = "Ilyechevsk",
                    Year = year,
                    StartDate = new DateTime(year, 7, 20 ),
                    EndDate = new DateTime(year, 7, 22 ),
                },
                new Tournament
                {
                    Name = "OChU'2011",
                    Place = "Ivano-Frankivsk",
                    Year = year,
                    StartDate = new DateTime(year, 9, 20 ),
                    EndDate = new DateTime(year, 9, 22 ),
                }
            });

            year = 2012;
            tournamentsList.AddRange(new List<Tournament>
            {
                new Tournament
                {
                    Name = "ZChU'2012",
                    Place = "Lutsk",
                    Year = year,
                    StartDate = new DateTime(year, 3, 20 ),
                    EndDate = new DateTime(year, 3, 22 ),
                },
                new Tournament
                {
                    Name = "BBG'2012",
                    Place = "Brest",
                    Year = year,
                    StartDate = new DateTime(year, 5, 20 ),
                    EndDate = new DateTime(year, 5, 22 ),
                },
                new Tournament
                {
                    Name = "PChU'2012",
                    Place = "Ilyechevsk",
                    Year = year,
                    StartDate = new DateTime(year, 7, 20 ),
                    EndDate = new DateTime(year, 7, 22 ),
                },
                new Tournament
                {
                    Name = "OChU'2012",
                    Place = "Kyiv",
                    Year = year,
                    StartDate = new DateTime(year, 9, 20 ),
                    EndDate = new DateTime(year, 9, 22 ),
                }
            });

            context.Tournaments.AddRange(tournamentsList);
        }
    }
}