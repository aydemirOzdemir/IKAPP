using IKAPP.Domain.Entities.AggregateModels.Personals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Services.PersonalService;

public interface IPersonalService
{
    Task<string> ConvertToEnglish(string input);
    Task<string> MakeUserName(Personal input);
    Task<string> MakeEmail(Personal input, string mailTarz);


    Task PasswordResetAsync(string email);

    Task UpdatePasswordAsync(string userId, string newPassword);
}
