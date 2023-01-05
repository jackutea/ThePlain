using ThePlain.Asset.Facades;
using UnityEngine;

namespace ThePlain.Asset {

    internal class AssetGetterAPI : IAssetGetterAPI {

        AssetContext assetContext;

        internal AssetGetterAPI() {}

        internal void Inject(AssetContext assetContext) {
            this.assetContext = assetContext;
        }

        bool IAssetGetterAPI.TryGetWorldAsset(string name, out GameObject prefab) {
            var worldAssets = assetContext.WorldAssets;
            return worldAssets.TryGet(name, out prefab);
        }
    }

}