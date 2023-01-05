using System.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ThePlain.Asset {

    public interface IAssetSetterAPI {

        Task<SceneInstance> LoadWorldScene(int chapter, int level);
        Task UnloadWorldScene(SceneInstance sceneInstance);

    }

}