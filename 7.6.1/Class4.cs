using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace _7._6._1
{
    public interface IHttpService
    {
        IObservable<string> GetString(string url);
    }
    public class MyTimeoutClass
    {
        private readonly IHttpService _httpService;
        public MyTimeoutClass(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public IObservable<string> GetStringWithTimeout(string url,
        IScheduler scheduler = null)
        {
            return _httpService.GetString(url)
            .Timeout(TimeSpan.FromSeconds(1), scheduler ??
            Scheduler.Default);
        }
    }
    internal class SuccessHttpServiceStub : IHttpService
    {
        public IScheduler Scheduler { get; set; }
        public TimeSpan Delay { get; set; }
        public IObservable<string> GetString(string url)
        {
            return Observable.Return("stub")
            .Delay(Delay, Scheduler);
        }
    }

}
