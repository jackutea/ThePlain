using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Infra.Facades;
using ThePlain.World.Facades;

namespace ThePlain.World.Domain {

    internal class WorldStateDomain {

        InfraContext infraContext;
        WorldContext worldContext;
        WorldDomain worldDomain;

        internal WorldStateDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext, WorldDomain worldDomain) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
            this.worldDomain = worldDomain;
        }

        internal async Task EnterGame() {

            var fieldDomain = worldDomain.FieldDomain;
            var roleLogicDomain = worldDomain.RoleLogicDomain;
            var roleRendererDomain = worldDomain.RoleRendererDomain;

            await fieldDomain.Spawn(1, 1);

            var pos = Vector3.up * 5;
            var roleLogic = roleLogicDomain.Spawn(pos);
            var roleRenderer = roleRendererDomain.Spawn(roleLogic.ID, pos);

            var stateEntity = worldContext.StateEntity;
            stateEntity.isInit = true;
            stateEntity.isPause = false;
            stateEntity.ownerRoleID = roleLogic.ID;

        }

        internal void Tick() {

            var stateEntity = worldContext.StateEntity;
            if (!stateEntity.isInit || stateEntity.isPause) {
                return;
            }

            bool has = worldContext.RoleLogicRepo.TryGet(stateEntity.ownerRoleID, out var ownerRole);
            if (!has) {
                Debug.LogError("Owner Role Not Found");
                return;
            }

            // Process Input
            var inputCom = ownerRole.InputCom;
            var input = infraContext.InputCore;
            var inputGetter = input.Getter;

            Vector2 moveAxis;
            if (inputGetter.GetPressing(InputKeyCollection.MOVE_FWD)) {
                moveAxis.y = 1;
            } else if (inputGetter.GetPressing(InputKeyCollection.MOVE_BWD)) {
                moveAxis.y = -1;
            } else {
                moveAxis.y = 0;
            }
            if (inputGetter.GetPressing(InputKeyCollection.MOVE_LEFT)) {
                moveAxis.x = -1;
            } else if (inputGetter.GetPressing(InputKeyCollection.MOVE_RIGHT)) {
                moveAxis.x = 1;
            } else {
                moveAxis.x = 0;
            }
            inputCom.moveAxis = moveAxis;

            if (inputGetter.GetPressing(InputKeyCollection.JUMP)) {
                inputCom.isJumping = true;
            } else {
                inputCom.isJumping = false;
            }

            // Process Logic
            var roleLogicDomain = worldDomain.RoleLogicDomain;
            roleLogicDomain.Move(ownerRole);

            // Process Renderer
            var roleRendererDomain = worldDomain.RoleRendererDomain;
            roleRendererDomain.Sync(ownerRole);

        }

    }

}