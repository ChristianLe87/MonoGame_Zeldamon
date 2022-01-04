using System;
namespace Shared
{
    public interface IAutoDestroy
    {
        int timeToDestroy { get; }
        int actualTime { get; set; }
        bool isAlive { get; set; }
    }
}
