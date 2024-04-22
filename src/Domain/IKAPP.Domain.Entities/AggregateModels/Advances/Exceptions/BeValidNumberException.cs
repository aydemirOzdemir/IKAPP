﻿using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;

public class BeValidNumberException : BaseException
{
    public BeValidNumberException(string message) : base(message)
    { }
}
