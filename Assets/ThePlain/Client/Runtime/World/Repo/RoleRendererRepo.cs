using System.Collections.Generic;
using ThePlain.World.Entities;

namespace ThePlain.World {

    public class RoleRendererRepo {

        Dictionary<int, RoleRendererEntity> all;

        public RoleRendererRepo() {
            all = new Dictionary<int, RoleRendererEntity>();
        }

        public void Add(RoleRendererEntity roleRendererEntity) {
            all.Add(roleRendererEntity.ID, roleRendererEntity);
        }

        public bool TryGet(int id, out RoleRendererEntity roleRendererEntity) {
            return all.TryGetValue(id, out roleRendererEntity);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

    }
}