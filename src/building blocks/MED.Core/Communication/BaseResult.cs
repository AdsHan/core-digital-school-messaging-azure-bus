using FluentValidation.Results;
using System;

namespace MED.Core.Communication
{
    public class BaseResult
    {
        public ValidationResult ValidationResult { get; set; }
        public Guid id { get; set; }

        public BaseResult()
        {
            ValidationResult = new ValidationResult();
            id = Guid.Empty;
        }

    }
}