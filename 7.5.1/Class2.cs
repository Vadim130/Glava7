using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace _7._5._1
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
        public IObservable<string> GetStringWithTimeout(string url)
        {
            return _httpService.GetString(url).Timeout(TimeSpan.FromSeconds(1));
        }
    }
    class SuccessHttpServiceStub : IHttpService
    {
        public IObservable<string> GetString(string url)
        {
            return Observable.Return("stub");
        }
    }
}
