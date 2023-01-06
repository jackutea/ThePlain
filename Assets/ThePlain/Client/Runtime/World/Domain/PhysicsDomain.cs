using UnityEngine;
using ThePlain.World.Facades;
using ThePlain.World.Entities;
using ThePlain.Infra.Facades;

namespace ThePlain.World.Domain {

    internal class PhysicsDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal PhysicsDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

    }
}