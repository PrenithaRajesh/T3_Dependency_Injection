// A new instance is created every time the service is requested
namespace backend.Services{
    public class TransientCounter: ICounter{
        private int _cnt = 1;

        public int Get(){
            return _cnt;
        }

        public void Increment(){
            _cnt++;
        }
    }
}