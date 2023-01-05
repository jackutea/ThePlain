using System.Threading.Tasks;
using ThePlain.Asset.Facades;

namespace ThePlain.Asset {

    public class AssetCore {

        AssetGetterAPI getterAPI;
        public IAssetGetterAPI Getter => getterAPI;

        AssetSetterAPI setterAPI;
        public IAssetSetterAPI Setter => setterAPI;

        AssetContext assetContext;

        public AssetCore() {

            assetContext = new AssetContext();
            getterAPI = new AssetGetterAPI();
            setterAPI = new AssetSetterAPI();

            getterAPI.Inject(assetContext);
            setterAPI.Inject(assetContext);

        }

        public async Task Init() {
            await assetContext.WorldAssets.LoadAll();
        }

    }

}