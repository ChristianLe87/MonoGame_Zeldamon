using System;
namespace Shared
{
    public interface IPointsFeedback : IEntity, IAutoDestroy
    {
        Text text { get; }
    }
}
