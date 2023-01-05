using System.Threading.Tasks;
using ThePlain.Asset.Facades;

namespace ThePlain.Asset {

    public class AssetCore {

        AssetGetterAPI getterAPI;
        public IAssetGetterAPI Getter => getterAPI;

        AssetContext assetContext;

        public AssetCore() {

            assetContext = new AssetContext();
            getterAPI = new AssetGetterAPI();

            getterAPI.Inject(assetContext);
            
        }

        public async Task Init() {
            await assetContext.WorldAssets.LoadAll();
        }

    }

}