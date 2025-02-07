// A new instance is created per http request
namespace backend.Services{
    public class ScopedCounter: ICounter{
        private int _cnt = 1;

        // public int GetCounter() => _count;
        public int Get(){
            return _cnt;
        }

        public void Increment(){
            _cnt++;
        }
    }
}