namespace ThePlain.Asset.Facades {

    internal class AssetContext {

        WorldAssets worldAssets;
        internal WorldAssets WorldAssets => worldAssets;

        internal AssetContext() {
            worldAssets = new WorldAssets();
        }

    }
}