﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Infrastructure.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BordroRangeAttribute : RangeAttribute, IClientValidatable
    {
        private static readonly IResourceService ResourceService = DependencyResolver.Current.GetService<IResourceService>();
        private const string ErrorMessageKeyName = "RangeErrorMessage";
        private const string MaximumName = "Maximum";
        private const string MinimumName = "Minimum";

        public BordroRangeAttribute(string propertyName)
            : base(0,1)
        {
            PropertyName = propertyName;
        }

        public new int Maximum
        {
            get
            {
                int i;
                return int.TryParse(ResourceService.ConfigurationValue(PropertyName, MaximumName), out i) ? i : int.MaxValue;
            }
        }

        public new int Minimum
        {
            get
            {
                int i;
                return int.TryParse(ResourceService.ConfigurationValue(PropertyName, MinimumName), out i) ? i : int.MinValue;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int i;
            var v = (value == null) ? "" : value.ToString();
            return int.TryParse(v, out i) ? (i >= Minimum && i <= Maximum ? null : new ValidationResult(ErrorMessage)) : new ValidationResult(ErrorMessage);
        }

        public string PropertyName { get; private set; }

        public new string ErrorMessage { get { return String.Format(ResourceService.ResourceValue(PropertyName, ErrorMessageKeyName) ?? "({0} - {1})", Minimum, Maximum); } }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRangeRule(ErrorMessage, Minimum, Maximum);
        }
    }
}
