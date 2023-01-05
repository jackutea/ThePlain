using System.Collections.Generic;
using ThePlain.World.Entities;

namespace ThePlain.World {

    public class FieldRepo {

        Dictionary<ulong, FieldEntity> all;

        public FieldRepo() {
            all = new Dictionary<ulong, FieldEntity>();
        }

        public void Add(FieldEntity fieldEntity) {
            all.Add(FieldEntity.GetKey(fieldEntity.Chapter, fieldEntity.Level), fieldEntity);
        }

        public bool TryGet(int chapter, int level, out FieldEntity fieldEntity) {
            var key = FieldEntity.GetKey(chapter, level);
            return all.TryGetValue(key, out fieldEntity);
        }

        public void Remove(int chapter, int level) {
            var key = FieldEntity.GetKey(chapter, level);
            all.Remove(key);
        }

    }
}