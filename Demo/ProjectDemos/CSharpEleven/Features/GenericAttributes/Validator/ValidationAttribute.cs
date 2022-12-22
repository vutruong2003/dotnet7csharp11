namespace CSharpEleven.Features.GenericAttributes;

internal interface IValidator
{
    
}

internal interface IValidator<T> : IValidator
{
    bool Validate(T data);
}

internal abstract class BaseValidator<T> : IValidator<T>
{
    public abstract bool Validate(T data);
}


class AddProductValidator : BaseValidator<Product>
{
    public override bool Validate(Product data)
    {
        return !string.IsNullOrEmpty(data.Name) && data.Age > 0;
    }
}

class UpdateProductValidator : BaseValidator<Product>
{
    public override bool Validate(Product data)
    {
        return data.Id.HasValue
            && (!string.IsNullOrEmpty(data.Name) || data.Age > 0);
    }
}

class MockProductValidate
{
    public bool Validate()
    {
        return true;
    }

    public bool Validate(Product data)
    {
        return data.Id.HasValue
            && (!string.IsNullOrEmpty(data.Name) || data.Age > 0);
    }
}

internal class MyValidationAttribute<T> : Attribute where T : IValidator, new()
{
    public T Validator { get; init;  }

    public MyValidationAttribute()
    {
        Validator = Activator.CreateInstance<T>();
    }
}