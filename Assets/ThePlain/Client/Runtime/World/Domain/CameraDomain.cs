using UnityEngine;
using ThePlain.World.Facades;
using ThePlain.Infra.Facades;

namespace ThePlain.World.Domain {

    internal class CameraDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal CameraDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

        internal void RotateCamera(Vector2 cameraRotAxis) {
            var cameraCore = infraContext.CameraCore;
            var cameraSetter = cameraCore.SetterAPI;
            cameraSetter.Round_Current(cameraRotAxis);
        }
        
    }
}