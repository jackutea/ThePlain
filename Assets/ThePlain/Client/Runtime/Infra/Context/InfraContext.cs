using GameArki.FreeInput;
using GameArki.TripodCamera;
using UIRenderer;
using ThePlain.Asset;

namespace ThePlain {

    public class InfraContext {

        FreeInputCore inputCore;
        public FreeInputCore InputCore => inputCore;

        TCCore tcCore;
        public TCCore TCCore => tcCore;

        UICore ui;
        public UICore UI => ui;

        AssetCore assetCore;
        public AssetCore AssetCore => assetCore;

        public InfraContext() {
            inputCore = new FreeInputCore();
            tcCore = new TCCore();
            ui = new UICore();
            assetCore = new AssetCore();
        }

    }

}