﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.ValidationsAttributes
{
    public class Indicator : Attribute, IClientModelValidator
    {

        public Indicator()
        {

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add($"data-indicator-{context.ModelMetadata.PropertyName}", "");
        }

    }
}
