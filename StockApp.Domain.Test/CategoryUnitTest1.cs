namespace StockApp.Domain.Test;

using StockApp.Domain.Entities;
using FluentAssertions;
using StockApp.Domain.Entities;
using Xunit;



public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name ");
        action.Should()
             .NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name ");
        action.Should()
            .Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name.Name is required");
    }

    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<StockApp.Domain.Validation.DomainExceptionValidation>();
    }
}