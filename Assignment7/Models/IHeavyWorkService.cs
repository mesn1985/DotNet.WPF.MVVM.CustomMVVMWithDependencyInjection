using System;

namespace Assignment7.Models
{

    public interface IHeavyWorkService
    {
        Boolean isWorking { get; }
        void start3HeavyTasks(Action<string> statusUpdateCallback);
    }

}