using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assignment7.Extensions;

namespace Assignment7.Models
{

    public class HeavyWorkService : IHeavyWorkService
    {
        private readonly Random _random = new Random();
        public Boolean isWorking { get; private set; } = false;

        public async void start3HeavyTasks(Action<string> statusUpdateCallback)
        {
            WorkIsStarted(statusUpdateCallback);
            CancellationTokenSource source = new CancellationTokenSource();
            Task.Run(async () =>
                     {
                         await Task.Delay(8_000, source.Token);
                         statusUpdateCallback("still Working");
                     });
            await Task.WhenAll(HeavyWorkAsync(3, 10_001));
            source.Cancel();
            WorkIsDone(statusUpdateCallback);
        }
        private IEnumerable<Task> HeavyWorkAsync(int noOfTasks, int maxTimeForTaskToComplete)
        {
            for (int i = 0; i < noOfTasks; i++)
                yield return Task.Run(() => { _random.makeThreadSleepForMaximal(maxTimeForTaskToComplete); });
        }
        private void WorkIsDone(Action<string> statusUpdateCallback)
        {
            statusUpdateCallback("Work Is done");
            isWorking = false;
        }
        private void WorkIsStarted(Action<string> statusUpdateCallback)
        {
            statusUpdateCallback("Working");
            isWorking = true;
        }

    }
}
