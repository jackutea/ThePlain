using UnityEngine;
using ThePlain.World.Entities;
using ThePlain.World.Facades;
using ThePlain.Infra.Facades;
using ThePlain.World.Service;

namespace ThePlain.World.Domain {

    internal class RoleLogicDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal RoleLogicDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

        internal RoleLogicEntity Spawn(Vector3 pos) {

            var factory = worldContext.Factory;
            var assetCore = infraContext.AssetCore;
            var role = factory.CreateRoleLogic(assetCore);

            role.RB.position = pos;

            var idService = worldContext.IDService;
            var id = idService.PickRoleID();
            role.SetID(id);

            var repo = worldContext.RoleLogicRepo;
            repo.Add(role);

            return role;

        }

        internal void Move(RoleLogicEntity role) {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            role.MoveByInput(cameraForward, cameraRight);
        }

    }

}