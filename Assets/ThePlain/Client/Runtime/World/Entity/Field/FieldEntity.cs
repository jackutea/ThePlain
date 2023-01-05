using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ThePlain.World.Entities {

    public class FieldEntity {

        int chapter;
        public int Chapter => chapter;

        int level;
        public int Level => level;

        SceneInstance sceneInstance;
        public SceneInstance SceneInstance => sceneInstance;

        public FieldEntity() {}

        public void Ctor(SceneInstance sceneInstance, int chapter, int level) {
            this.sceneInstance = sceneInstance;
            this.chapter = chapter;
            this.level = level;
        }

        public static ulong GetKey(int chapter, int level) {
            return (ulong)chapter << 32 | (uint)level;
        }

    } 

}