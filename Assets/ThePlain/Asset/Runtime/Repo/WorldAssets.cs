using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

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

    }
}