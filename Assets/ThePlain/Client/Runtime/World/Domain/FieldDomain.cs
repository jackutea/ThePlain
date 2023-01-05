using System.Threading.Tasks;
using ThePlain.Asset;
using ThePlain.Infra.Facades;
using ThePlain.World.Facades;

namespace ThePlain.World.Domain {

    internal class FieldDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal FieldDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

        internal async Task Spawn(int chapter, int level) {
            
            var factory = worldContext.Factory;
            var assetCore = infraContext.AssetCore;
            var field = await factory.CreateField(assetCore, chapter, level);

            worldContext.FieldRepo.Add(field);

        }

    }
}