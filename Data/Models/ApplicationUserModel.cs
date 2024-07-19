﻿using _2Good2EatBackendStore.Data.Entities;

namespace _2Good2EatBackendStore.Data.Models
{
    public class ApplicationUserModel
    {   
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed {  get; set; }
        public string FirstName   { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
   
    }


    public static class ApplicationUserExtensionMethods
    {
        public static ApplicationUserModel MapToModel(this ApplicationUser entity)
        {
            return new ApplicationUserModel
            {
                Id  = entity.Id,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                EmailConfirmed = entity.EmailConfirmed,
                FirstName = entity.FirstName,
                LastName = entity.LastName,

            };
        }

        public static ApplicationUser MapToEntity(this ApplicationUserModel model)
        {
            return new ApplicationUser
            {
                Id = model.Id,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                EmailConfirmed = model.EmailConfirmed,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };
        }

    }
}
