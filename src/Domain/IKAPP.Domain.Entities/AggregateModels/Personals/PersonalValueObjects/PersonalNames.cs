using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalValueObjects;

public sealed record PersonalNames
{
    private readonly PersonalRule rules;

    public PersonalNames(string firstName,string? secondName,string lastName,string? secondLastName)
    {
        rules =new() ;
        rules.FirstNameCanNotBeEmpty(firstName) ;
        rules.FirstNameGreatherThan2LessThan20(firstName);
        FirstName=firstName ;
        rules.LastNameCanNotBeEmpty(lastName) ;
        rules.LastNameGreatherThan2LessThan20(lastName);
        LastName=lastName ;
        SecondName=secondName ;
        SecondLastName=secondLastName ;

    }
    public string FirstName { get;private set; } 
    public string? SecondName { get;private set; }
    public string LastName { get;private set; } 
    public string? SecondLastName { get;private set; }
}
