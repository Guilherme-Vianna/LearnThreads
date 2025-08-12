namespace LearnThreads
{
    public class QueueService : IQueueService
    {
        public int Counter { get; set; } = 0;
        public Task CounterTask;
        public object Locker = new();
        public bool IsRunning = false;

        public QueueService()
        {
            CounterTask = new Task(() =>
            {
                while (true)
                {
                    if (IsRunning)
                    {
                        lock (Locker)
                        {
                            Task.Delay(1000);
                            Counter++;
                            Console.WriteLine("Counter is now: " + Counter);
                        }
                    }
                    else
                    {
                        Task.Delay(1000);
                        Console.WriteLine("Counter is paused");
                    }
                }
            });
            CounterTask.Start();
        }
        public void Start()
        {
            lock (Locker)
            {
                IsRunning = true;
            }
        }

        public void Stop()
        {
            lock (Locker)
            {
                IsRunning = false;
            }
        }
    }

    public interface IQueueService
    {
        public void Start();
        public void Stop();
    }
}
