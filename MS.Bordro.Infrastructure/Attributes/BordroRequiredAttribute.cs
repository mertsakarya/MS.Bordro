using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BordroRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        private static readonly IResourceService ResourceService = DependencyResolver.Current.GetService<IResourceService>();
        private const string ErrorMessageKeyName = "RequiredErrorMessage";

        public BordroRequiredAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = base.IsValid(value, validationContext);
            if (validationResult != null && !string.IsNullOrEmpty(validationResult.ErrorMessage))
                validationResult.ErrorMessage = ErrorMessage;
            return validationResult;
        }

        protected string PropertyName { get; private set; }

        public new string ErrorMessage { get { return ResourceService.ResourceValue(PropertyName, ErrorMessageKeyName) ?? "*"; } }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRequiredRule(ErrorMessage);
        }
    }
}
