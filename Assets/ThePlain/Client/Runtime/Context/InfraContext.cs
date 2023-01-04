using GameArki.FreeInput;
using GameArki.TripodCamera;

namespace ThePlain {

    public class InfraContext {

        FreeInputCore inputCore;
        public FreeInputCore InputCore => inputCore;

        TCCore tcCore;
        public TCCore TCCore => tcCore;

        public InfraContext() {
            inputCore = new FreeInputCore();
            tcCore = new TCCore();
        }

    }

}