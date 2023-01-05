using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Infra.Facades;

namespace ThePlain.Infra.Controller {

    public class InfraController {

        public InfraController() {}

        public async Task Init(Canvas canvas, InfraContext infraContext) {

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

        }

    }

}