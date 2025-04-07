using FluentValidation;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Validators.Unit
{
    public class AddUnitValidator : AbstractValidator<AddUnitDto>
    {
        #region Fields

        #endregion

        #region Constructors
        public AddUnitValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title is Required")
                .NotEmpty().WithMessage("Title must be not empty")
                .MaximumLength(255).WithMessage("Title length must be less than 255");
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description is Required")
                .NotEmpty().WithMessage("Description must be not empty")
                .MaximumLength(255).WithMessage("Description length must be less than 255");

        }

        private void ApplyCustomValidationRules()
        {
        }

        #endregion
    }
}
