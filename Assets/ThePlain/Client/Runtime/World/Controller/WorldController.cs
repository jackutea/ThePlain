using UnityEngine;
using ThePlain.Infra.Facades;
using ThePlain.World.Facades;

namespace ThePlain.World.Controller {

    public class WorldController {

        WorldContext worldContext;
        WorldDomain worldDomain;

        public WorldController() {
            worldContext = new WorldContext();
            worldDomain = new WorldDomain();
        }

        public void Init(InfraContext infraContext) {

            var worldStateDomain = worldDomain.WorldStateDomain;
            var fieldDomain = worldDomain.FieldDomain;
            var roleLogicDomain = worldDomain.RoleLogicDomain;
            var roleRendererDomain = worldDomain.RoleRendererDomain;

            worldStateDomain.Inject(infraContext, worldContext, worldDomain);
            fieldDomain.Inject(infraContext, worldContext);
            roleLogicDomain.Inject(infraContext, worldContext);
            roleRendererDomain.Inject(infraContext, worldContext);

            infraContext.EventCenter.OnStartGameHandle += async () => {
                await worldStateDomain.EnterGame();
            };

        }

        public void FixedTick() {

        }

        public void Tick() {

            var worldStateDomain = worldDomain.WorldStateDomain;
            worldStateDomain.Tick();

        }

    }

}