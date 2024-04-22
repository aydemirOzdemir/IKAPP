using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionValueObjects;

public sealed record PermissionTime
{
    private readonly PermissionRule rules;
    public PermissionTime(DateTime startedDate, DateTime finishedDate, byte dayCount)
    {
        rules = new();
        rules.StartedDateCanNotBeEmpty(startedDate);
        StartedDate = startedDate;
        rules.FinishedDateCanNotBeEmpty(finishedDate);
        FinishedDate = finishedDate;
        rules.DayCountCanNotBeEmpty(dayCount);
        DayCount = dayCount;
    }
    public DateTime StartedDate { get; private set; }
    public DateTime FinishedDate { get;private set; }
    public byte DayCount { get; private set; }
}
