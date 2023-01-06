using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Infra.Facades;

namespace ThePlain.Infra.Controller {

    public class InfraController {

        InfraContext infraContext;

        public InfraController() { }

        public void Inject(InfraContext infraContext) {
            this.infraContext = infraContext;
        }

        public async Task Init(Canvas canvas) {

            var ui = infraContext.UI;
            ui.Inject(canvas);
            await ui.Init();

            var asset = infraContext.AssetCore;
            await asset.Init();

            var input = infraContext.InputCore;
            input.Setter.Bind(InputKeyCollection.MOVE_FWD, KeyCode.W);
            input.Setter.Bind(InputKeyCollection.MOVE_BWD, KeyCode.S);
            input.Setter.Bind(InputKeyCollection.MOVE_LEFT, KeyCode.A);
            input.Setter.Bind(InputKeyCollection.MOVE_RIGHT, KeyCode.D);
            input.Setter.Bind(InputKeyCollection.JUMP, KeyCode.Space);

            var cameraCore = infraContext.CameraCore;
            cameraCore.Initialize(Camera.main);
            cameraCore.SetterAPI.SpawnByMain(1);

        }

        public void LateTick(float dt) {

            var cameraCore = infraContext.CameraCore;
            cameraCore.Tick(dt);
        }

    }

}