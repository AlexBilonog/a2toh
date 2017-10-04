using FRS.Common;
using FRS.DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel
{
    public static class SeedData
    {
        public static void Apply(DbContext context)
        {
            context.AddOrUpdateSeed(null,
                new User
                {
                    Id = 1,
                    Password = "AG8YFAuDP5RVRnZAYSJoNlSyLJ4DgUtAQ2RJYqR/y1Ivo/aZqKCadksGUsO1kZ1yRQ==",
                    Email = "em_admin@evolvice.de",
                    FirstName = "Admin",
                    LastName = "Admin"
                },
                new User
                {
                    Id = 2,
                    Password = "AAnZGvZ/4Sh1bTFReQiV5BfC2ZxSIfZLizWTI2PCDRsOVdD/KN1KCE3wuzTOc5hP3A==",
                    Email = "restuser@evolvice.de",
                    FirstName = "RestUser",
                    LastName = "RestUser"
                });
        }
    }
}
