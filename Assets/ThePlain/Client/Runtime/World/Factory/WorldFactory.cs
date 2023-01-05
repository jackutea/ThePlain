using System.Threading.Tasks;
using UnityEngine;
using ThePlain.World.Entities;
using ThePlain.Asset;

namespace ThePlain.World {

    public class WorldFactory {

        public WorldFactory() {}

        // ==== Field ====
        public async Task<FieldEntity> CreateField(AssetCore assetCore, int chapter, int level) {
            var scene = await assetCore.Setter.LoadWorldScene(chapter, level);
            FieldEntity entity = new FieldEntity();
            entity.Ctor(scene, chapter, level);
            return entity;
        }

        // ==== Role ====
        public RoleLogicEntity CreateRoleLogic(AssetCore assetCore) {
            bool has = assetCore.Getter.TryGetWorldAsset("entity_role_logic", out var go);
            if (!has) {
                return null;
            }
            var entity = GameObject.Instantiate(go).GetComponent<RoleLogicEntity>();
            entity.Ctor();
            return entity;
        }

        public RoleRendererEntity CreateRoleRenderer(AssetCore assetCore) {
            bool has = assetCore.Getter.TryGetWorldAsset("entity_role_renderer", out var go);
            if (!has) {
                return null;
            }
            var entity = GameObject.Instantiate(go).GetComponent<RoleRendererEntity>();
            entity.Ctor();
            return entity;
        }

    }

}