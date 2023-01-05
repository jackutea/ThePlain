using System.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;
using ThePlain.Asset.Facades;

namespace ThePlain.Asset {

    public class AssetSetterAPI : IAssetSetterAPI {

        AssetContext assetContext;

        internal AssetSetterAPI() {}

        internal void Inject(AssetContext assetContext) {
            this.assetContext = assetContext;
        }

        async Task<SceneInstance> IAssetSetterAPI.LoadWorldScene(int chapter, int level) {
            var worldAssets = assetContext.WorldAssets;
            var sceneInstance = await worldAssets.LoadField(chapter, level);
            return sceneInstance;
        }

        async Task IAssetSetterAPI.UnloadWorldScene(SceneInstance sceneInstance) {
            var worldAssets = assetContext.WorldAssets;
            await worldAssets.UnloadField(sceneInstance);
        }

    }

}