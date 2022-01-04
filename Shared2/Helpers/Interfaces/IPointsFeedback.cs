using System;
namespace Shared
{
    public interface IPointsFeedback : IEntity, IAutoDestroy
    {
        MoneyText text { get; }
    }
}
