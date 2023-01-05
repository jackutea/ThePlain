using UnityEngine;

namespace ThePlain.Asset {

    public interface IAssetGetterAPI {

        bool TryGetWorldAsset(string name, out GameObject prefab);

    }

}