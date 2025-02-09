using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class CounterController : ControllerBase{
        private readonly ScopedCounter _scopedCounter;
        private readonly TransientCounter _transientCounter;
        private readonly SingletonCounter _singletonCounter;

        public CounterController(ScopedCounter scopedCounter, TransientCounter transientCounter, SingletonCounter singletonCounter){
            _scopedCounter = scopedCounter;
            _transientCounter = transientCounter;
            _singletonCounter = singletonCounter;
        }

        [HttpGet("getall")]
        public CounterResponseDTO GetAllCounters(){
            return new CounterResponseDTO{
                Scoped = _scopedCounter.Get(),
                Transient = _transientCounter.Get(),
                Singleton = _singletonCounter.Get()
            };
        }

        [HttpPost("incrementall")]
        public void IncrementAll(){
            _scopedCounter.Increment();
            _transientCounter.Increment();
            _singletonCounter.Increment();
        }
    }
}