using System.Collections.Generic;
using ThePlain.World.Entities;

namespace ThePlain.World {

    public class RoleLogicRepo {

        Dictionary<int, RoleLogicEntity> all;

        public RoleLogicRepo() {
            all = new Dictionary<int, RoleLogicEntity>();
        }

        public void Add(RoleLogicEntity roleLogicEntity) {
            all.Add(roleLogicEntity.ID, roleLogicEntity);
        }

        public bool TryGet(int id, out RoleLogicEntity roleLogicEntity) {
            return all.TryGetValue(id, out roleLogicEntity);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public IEnumerable<RoleLogicEntity> GetAll() {
            return all.Values;
        }

    }
}