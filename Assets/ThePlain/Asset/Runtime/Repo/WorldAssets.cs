using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace ThePlain.Asset {

    internal class WorldAssets {

        Dictionary<string, GameObject> all;

        internal WorldAssets() {
            all = new Dictionary<string, GameObject>();
        }

        internal async Task LoadAll() {
            AssetLabelReference label = new AssetLabelReference();
            label.labelString = "World";
            var list = await Addressables.LoadAssetsAsync<GameObject>(label, null).Task;
            foreach (var item in list) {
                all.Add(item.name, item);
            }
        }

        public bool TryGet(string name, out GameObject prefab) {
            return all.TryGetValue(name, out prefab);
        }

        public async Task<SceneInstance> LoadField(int chapter, int level) {
            SceneInstance sceneInstance = await Addressables.LoadSceneAsync($"scene_field_c{chapter}l{level}", LoadSceneMode.Additive).Task;
            return sceneInstance;
        }

        public async Task UnloadField(SceneInstance sceneInstance) {
            await Addressables.UnloadSceneAsync(sceneInstance).Task;
        }

    }
}