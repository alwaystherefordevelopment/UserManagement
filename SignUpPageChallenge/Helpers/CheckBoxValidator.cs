﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.UI.Helpers
{
    public class CheckBoxValidator : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-checkbox", ErrorMessage);
        }

        public override bool IsValid(object value)
        {
            return (bool)value;

            //if ((bool)value == true)
            //    return true;
            //else
            //    return false;
        }
    }
}
