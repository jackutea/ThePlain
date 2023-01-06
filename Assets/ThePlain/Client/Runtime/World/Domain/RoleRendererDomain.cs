using UnityEngine;
using ThePlain.World.Entities;
using ThePlain.World.Facades;
using ThePlain.Infra.Facades;
using ThePlain.World.Service;

namespace ThePlain.World.Domain {

    internal class RoleRendererDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal RoleRendererDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

        internal RoleRendererEntity Spawn(int id, Vector3 pos) {

            var factory = worldContext.Factory;
            var assetCore = infraContext.AssetCore;
            var role = factory.CreateRoleRenderer(assetCore);

            role.transform.position = pos;

            var idService = worldContext.IDService;
            role.SetID(id);

            var repo = worldContext.RoleRendererRepo;
            repo.Add(role);

            return role;

        }

        internal void Sync(RoleLogicEntity roleLogic) {

            var id = roleLogic.ID;
            var has = worldContext.RoleRendererRepo.TryGet(id, out var roleRenderer);
            if (!has) {
                Debug.LogError("RoleRenderer Not Found");
                return;
            }

            var rb = roleLogic.RB;
            roleRenderer.transform.position = rb.position;

        }

    }

}