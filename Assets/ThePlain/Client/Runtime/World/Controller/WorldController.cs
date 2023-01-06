using UnityEngine;
using ThePlain.Infra.Facades;
using ThePlain.World.Facades;

namespace ThePlain.World.Controller {

    public class WorldController {

        InfraContext infraContext;
        WorldContext worldContext;
        WorldDomain worldDomain;

        public WorldController() {
            worldContext = new WorldContext();
            worldDomain = new WorldDomain();
        }

        public void Inject(InfraContext infraContext) {
            
            this.infraContext = infraContext;
            
            var worldStateDomain = worldDomain.WorldStateDomain;
            var fieldDomain = worldDomain.FieldDomain;
            var roleLogicDomain = worldDomain.RoleLogicDomain;
            var roleRendererDomain = worldDomain.RoleRendererDomain;
            var physicsDomain = worldDomain.PhysicsDomain;
            var cameraDomain = worldDomain.CameraDomain;

            worldStateDomain.Inject(infraContext, worldContext, worldDomain);
            fieldDomain.Inject(infraContext, worldContext);
            roleLogicDomain.Inject(infraContext, worldContext);
            roleRendererDomain.Inject(infraContext, worldContext);
            physicsDomain.Inject(infraContext, worldContext);
            cameraDomain.Inject(infraContext, worldContext);
        }

        public void Init() {

            infraContext.EventCenter.OnStartGameHandle += async () => {
                var worldStateDomain = worldDomain.WorldStateDomain;
                await worldStateDomain.EnterGame();
            };

        }

        public void FixedTick() {

        }

        public void Tick(float dt) {

            var worldStateDomain = worldDomain.WorldStateDomain;
            worldStateDomain.Tick(dt);

        }

    }

}