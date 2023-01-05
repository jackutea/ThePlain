using UnityEngine;
using ThePlain.Infra.Facades;

namespace ThePlain.World.Controller {

    public class WorldController {

        public WorldController() { }

        public void Init(InfraContext infraContext) {

            infraContext.EventCenter.OnStartGameHandle += () => {
                infraContext.AssetCore.Setter.LoadWorldScene(1, 1);

                infraContext.AssetCore.Getter.TryGetWorldAsset("entity_role", out var go);
                var entity = GameObject.Instantiate(go);
            };

        }
        
    }
}