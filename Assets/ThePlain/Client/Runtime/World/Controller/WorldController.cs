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

            var fieldDomain = worldDomain.FieldDomain;
            var roleLogicDomain = worldDomain.RoleLogicDomain;
            var roleRendererDomain = worldDomain.RoleRendererDomain;
            fieldDomain.Inject(infraContext, worldContext);
            roleLogicDomain.Inject(infraContext, worldContext);
            roleRendererDomain.Inject(infraContext, worldContext);

            infraContext.EventCenter.OnStartGameHandle += async () => {

                await fieldDomain.Spawn(1, 1);

                var pos = Vector3.up * 5;
                var role = roleLogicDomain.Spawn(pos);
                _ = roleRendererDomain.Spawn(pos);

                var stateEntity = worldContext.StateEntity;
                stateEntity.isInit = true;
                stateEntity.isPause = false;
                stateEntity.ownerRoleID = role.ID;

            };

        }

        public void FixedTick() {

        }

        public void Tick(InfraContext infraContext) {

            var stateEntity = worldContext.StateEntity;
            if (!stateEntity.isInit || stateEntity.isPause) {
                return;
            }

            // Process Input
            var input = infraContext.InputCore;
            var inputGetter = input.Getter;
            if (inputGetter.GetPressing(InputKeyCollection.MOVE_FWD)) {
                Debug.Log("Move FWD");
            }

            // Process Logic

            // Process Renderer

        }

    }

}