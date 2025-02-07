using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase{
        private readonly ScopedCounter _scopedCounter;
        private readonly TransientCounter _transientCounter;
        private readonly SingletonCounter _singletonCounter;

        public CounterController(ScopedCounter scopedCounter, TransientCounter transientCounter, SingletonCounter singletonCounter){
            _scopedCounter = scopedCounter;
            _transientCounter = transientCounter;
            _singletonCounter = singletonCounter;
        }

        [HttpGet("scoped")]
        public int GetScoped(){
            return _scopedCounter.Get();
        }

        [HttpGet("transient")]
        public int GetTransient(){
            return _transientCounter.Get();
        }

        [HttpGet("singleton")]
        public int GetSingleton(){
            return _singletonCounter.Get();
        }

        [HttpPost("scoped")]
        public int IncrementScoped(){
            _scopedCounter.Increment();
            return _scopedCounter.Get();
        }

        [HttpPost("transient")]
        public int IncrementTransient(){
            _transientCounter.Increment();
            return _transientCounter.Get();
        }

        [HttpPost("singleton")]
        public int IncrementSingleton(){
            _singletonCounter.Increment();
            return _singletonCounter.Get();
        }

    }
}