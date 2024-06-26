﻿using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseRules;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses;

public class Expense : BaseEntityForBusiness, IAggregateRoot
{
    private readonly ExpenseRule rules;

    private Expense(ExpenseDTO expenseDTO) : base(expenseDTO.Id, new(expenseDTO.Name))
    {
        rules = new();
        TotalAmount = new(expenseDTO.TotalAmount);
        rules.CurrencyCanNotBeEmpty(expenseDTO.Currency);
        Currency = expenseDTO.Currency;
        rules.PersonalIdCanNotBeEmpty(expenseDTO.PersonalId);
        PersonalId = expenseDTO.PersonalId;
        rules.DocumantationCanNotBeEmpty(expenseDTO.Documantation);
        Documantation = expenseDTO.Documantation;
        rules.TypeofExpenseCanNotBeEmpty(expenseDTO.TypeofExpense);
        TypeofExpense = expenseDTO.TypeofExpense;
        CompanyId = expenseDTO.CompanyId;
        Personal = expenseDTO.Personal;
        Company = expenseDTO.Company;
        UpdateEntityForBusiines(expenseDTO.RequestDate, expenseDTO.DateofReply, expenseDTO.StatusofApproval);


    }
    public TotalAmount TotalAmount { get; private set; }
    public Currency Currency { get; private set; }
    public TypeofExpenses TypeofExpense { get; private set; }
    public string Documantation { get; private set; }
    public string PersonalId { get; private set; }
    public string? CompanyId { get; private set; }
    public Personal Personal { get; private set; }
    public Company? Company { get; private set; }
    public static Expense CreateExpense(ExpenseDTO expenseDTO)
    {
        Expense expense = new(expenseDTO);
        expense.UpdateBaseEntiy(null, DateTime.Now, null, Enums.Status.Added, null); 
        return expense;
    } 

    public ExpenseDTO CreateExpenseDTO() => new()
    {
        Id = this.Id,
        RequestDate = this.RequestDate,
        Name = this.Name.Value,
        DateofReply = this.DateofReply,
        StatusofApproval = this.StatusofApproval,
        TotalAmount = this.TotalAmount.Value,
        Currency = this.Currency,
        TypeofExpense = this.TypeofExpense,
        Documantation = this.Documantation,
        PersonalId = this.PersonalId,
        Personal = this.Personal,
        Company = this.Company,
    };
    public static IEnumerable<ExpenseDTO> CreateExpenseDTOs(IEnumerable<Expense> expenses)
    {
        List<ExpenseDTO> expenseDTOs = new List<ExpenseDTO>();
        foreach (Expense expense in expenses)
            expenseDTOs.Add(new ExpenseDTO()
            {
                Id = expense.Id,
                RequestDate = expense.RequestDate,
                Name = expense.Name.Value,
                DateofReply = expense.DateofReply,
                StatusofApproval = expense.StatusofApproval,
                TotalAmount = expense.TotalAmount.Value,
                Currency = expense.Currency,
                TypeofExpense = expense.TypeofExpense,
                Documantation = expense.Documantation,
                PersonalId = expense.PersonalId,
                Personal = expense.Personal,
                Company = expense.Company,
            });
        return expenseDTOs;
    }
    public Task SoftDeleteExpense()
    {

        UpdateDeleteDate(DateTime.Now);
        UpdateBaseEntiy(null, null, null, Enums.Status.Deleted, null);
        return Task.CompletedTask;
    }
    public Task UpdateExpense(ExpenseUpdateDTO expenseUpdateDTO)
    {
        TotalAmount = new(expenseUpdateDTO.TotalAmount);
        Currency = expenseUpdateDTO.Currency;
        TypeofExpense=expenseUpdateDTO.TypeofExpenses;
        Documantation = expenseUpdateDTO.Documantation;
      
        UpdateBaseEntiy(null, null, expenseUpdateDTO.Id, Enums.Status.Modified, DateTime.Now);
        return Task.CompletedTask;
    }

}
