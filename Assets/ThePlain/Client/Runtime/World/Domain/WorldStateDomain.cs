using System.Threading.Tasks;
using UnityEngine;
using GameArki.FPEasing;
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

            var cameraCore = infraContext.CameraCore;
            var cameraSetter = cameraCore.SetterAPI;
            cameraSetter.Follow_SetInit_Current(roleRenderer.transform, new Vector3(0, 3.5f, -8), EasingType.Immediate, 0, EasingType.Linear, 1f);
            cameraSetter.LookAt_SetInit_Current(roleRenderer.transform, Vector3.zero);

            var stateEntity = worldContext.StateEntity;
            stateEntity.isInit = true;
            stateEntity.isPause = false;
            stateEntity.ownerRoleID = roleLogic.ID;

        }

        internal void Tick(float dt) {

            var stateEntity = worldContext.StateEntity;
            if (!stateEntity.isInit || stateEntity.isPause) {
                return;
            }

            var roleLogicDomain = worldDomain.RoleLogicDomain;
            var roleRendererDomain = worldDomain.RoleRendererDomain;
            var cameraDomain = worldDomain.CameraDomain;

            var roleRepo = worldContext.RoleLogicRepo;
            var allRole = roleRepo.GetAll();
            foreach (var role in allRole) {

                // Process Input
                if (role.ID == stateEntity.ownerRoleID) {
                    roleLogicDomain.RecordOwnerInput(role);
                    cameraDomain.RotateCamera(role.InputCom.cameraRotAxis);
                }

                // Process Logic
                roleLogicDomain.Move(dt, role);
                roleLogicDomain.Jump(role);
                roleLogicDomain.Falling(dt, role);

                // Process Renderer
                roleRendererDomain.Sync(role);

            }

        }

    }

}