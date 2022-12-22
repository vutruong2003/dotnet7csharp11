namespace CSharpEleven.Features.GenericAttributes.Decorator;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class DecorateAttribute<T> : Attribute where T : IAction
{
}
