using System;
namespace Shared
{
    public interface IAutoDestroy
    {
        int timeToDestroy { get; }
        bool isAlive { get; }
    }
}
