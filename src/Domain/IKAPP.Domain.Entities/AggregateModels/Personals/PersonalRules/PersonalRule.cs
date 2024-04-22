using IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;
using IKAPP.Domain.Entities.AggregateModels.Personals.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalRules;

public class PersonalRule
{
    public Task FirstNameCanNotBeEmpty(string value)
    {
        if (value == null)
        
            throw new FirstNameCanNotBeEmptyException("İsim  Alanı Boş Bırakılamaz");
        foreach (char item in value)
        {
            if (int.TryParse(item.ToString(), out _))
                throw new FirstNameCanNotBeEmptyException("İsim numerik karakterlerden oluşamaz");
        }
          
        
        return Task.CompletedTask;
    }
    public Task LastNameCanNotBeEmpty(string value)
    {
        if (value == null) 
            throw new LastNameCanNotBeEmptyException("Soyisim  Alanı Boş Bırakılamaz");
        foreach (char item in value)
        {
            if (int.TryParse(item.ToString(), out _))
                throw new LastNameCanNotBeEmptyException("Soyisim  numerik karakterlerden oluşamaz");
        }
        
        return Task.CompletedTask;
    }
    public Task FirstNameGreatherThan2LessThan20(string value)
    {
        if (value.Length<2 ||value.Length>20)
        {
            throw new FirstNameGreatherThan2LessThan20Exception("İsim  Uzunluğu iki harften daha az ve yirmi harften daha fazla olamaz. ");
        }
        return Task.CompletedTask;
    }
    public Task LastNameGreatherThan2LessThan20(string value)
    {
        if (value.Length < 2 || value.Length > 20)
        {
            throw new LastNameGreatherThan2LessThan20Exception("Soyisim  Uzunluğu iki harften daha az ve yirmi harften daha fazla olamaz. ");
        }
        return Task.CompletedTask;
    }
    public Task IdentityNumberCanNotBeEmpty(string value)
    {
        if (value == null)

            throw new IdentityNumberCanNotBeEmptyException("T.C. Kimlik  Alanı Boş Bırakılamaz");
     
        return Task.CompletedTask;
    }
    public Task IdentityNumberLengthMustBe11(string value)
    {
        if (value.Length != 11 || !value.All(char.IsDigit))

            throw new IdentityNumberLengthMustBe11Exception("T.C. Kimlik  Alanı 11 Karakter ve Tüm Karakterler Numeric  Olmalıdır.");

        return Task.CompletedTask;
    }
    public Task IdentityNumberMustBeValid(string value)
    {
        if (value[0] == '0')
            throw new IdentityNumberMustBeValidException("T.C. Kimlik  Numarası 0 ile Başlamamalıdır.");

        int[] digits = new int[11];
        for (int i = 0; i < 11; i++)
        {
            digits[i] = int.Parse(value[i].ToString());
        }

        // 1, 3, 5, 7, 9. hanelerin toplamı
        int oddSum = 0;
        for (int i = 0; i < 9; i += 2)
        {
            oddSum += digits[i];
        }

        // 2, 4, 6, 8. hanelerin toplamı
        int evenSum = 0;
        for (int i = 1; i < 9; i += 2)
        {
            evenSum += digits[i];
        }

        // Kontrol mekanizması
        int tenthDigit = (oddSum * 7 - evenSum) % 10;
        if (tenthDigit != digits[9])
            throw new IdentityNumberMustBeValidException("T.C. Kimlik  Numarası Doğru Değildir.");

        int totalSum = 0;
        for (int i = 0; i < 10; i++)
        {
            totalSum += digits[i];
        }

        int lastDigit = totalSum % 10;
        if (lastDigit != digits[10])
            throw new IdentityNumberMustBeValidException("T.C. Kimlik  Numarası Doğru Değildir.");
        return Task.CompletedTask;
    }
    public Task GenderCanNotBeEmpty(Gender? value)
    {
        if (value == null)
        {
            throw new GenderCanNotBeEmptyException("Cinsiyeti Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task StartDateOfWorkRule(DateTime? value)
    {
        if (value == null)

            throw new StartDateOfWorkException("İşe Başlama Tarihi  Alanı Boş Bırakılamaz");


        return Task.CompletedTask;
    }
    public Task BirthDateRules(DateTime? value)
    {
        if (value == null)

            throw new BirthDateException("İşe Başlama Tarihi  Alanı Boş Bırakılamaz");
        if (value < DateTime.Today.AddYears(-90))
            throw new BirthDateException("Personel 90 yaşından küçük olmalıdır");
        if (value > DateTime.Today.AddYears(-18))
            throw new BirthDateException("Personel 18 yaşından büyük olmalıdır");

        return Task.CompletedTask;
    }
    public Task AddressCanNotBeEmpty(string? value)
    {
        if (value == null)
        {
            throw new AddressCanNotBeEmptyException("Adres Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task PlaceOfBirthCanNotBeEmpty(string? value)
    {
        if (value == null)
        {
            throw new AddressCanNotBeEmptyException("Doğum Yeri Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task VocationIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new VocationException("Meslek Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task CompanyIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new CompanyException("Şirket Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task DepartmantIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new DepartmantException("Şirket Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task VocationCanNotBeEmpty(Vocation? value)
    {
        if (value == null)
        {
            throw new VocationException("Meslek Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task DepartmantCanNotBeEmpty(Department? value)
    {
        if (value == null)
        {
            throw new DepartmantException("Departman Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task CompanyCanNotBeEmpty(Company? value)
    {
        if (value == null)
        {
            throw new CompanyException("şirket Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
}
