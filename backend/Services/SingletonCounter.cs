// One instance is shared across the entire app
namespace backend.Services{
    public class SingletonCounter: ICounter{
        private int _cnt = 1;

        public int Get(){
            return _cnt;
        }

        public void Increment(){
            _cnt++;
        }
    }
}