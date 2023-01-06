using GameArki.FreeInput;
using GameArki.TripodCamera;
using UIRenderer;
using ThePlain.Asset;

namespace ThePlain.Infra.Facades {

    public class InfraContext {

        FreeInputCore inputCore;
        public FreeInputCore InputCore => inputCore;

        TCCore cameraCore;
        public TCCore CameraCore => cameraCore;

        UICore ui;
        public UICore UI => ui;

        AssetCore assetCore;
        public AssetCore AssetCore => assetCore;

        InfraEventCenter eventCenter;
        public InfraEventCenter EventCenter => eventCenter;

        public InfraContext() {
            inputCore = new FreeInputCore();
            cameraCore = new TCCore();
            ui = new UICore();
            assetCore = new AssetCore();
            eventCenter = new InfraEventCenter();
        }

    }

}