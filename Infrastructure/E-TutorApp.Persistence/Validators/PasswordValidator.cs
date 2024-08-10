using E_TutorApp.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Persistence.Validators
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if(password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Password Contains Username",
                    Description = "Password may not contains to username !"
                });
            }
            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Password Contains Email",
                    Description = "Password may not contains to Email !"
                });
            }
            //if (password.ToLower() == user.Address.ToLower())
            //{
            //    errors.Add(new IdentityError()
            //    {
            //        Code = "Password Contains Address",
            //        Description = "Password may not contains to Address"
            //    });
            //}

            if(errors.Count == 0) return Task.FromResult(IdentityResult.Success);
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }
}
