using ThePlain.World.Entities;
using ThePlain.World.Service;

namespace ThePlain.World.Facades {

    internal class WorldContext {

        // ==== State ====
        WorldStateEntity stateEntity;
        internal WorldStateEntity StateEntity => stateEntity;

        // ==== Factory ====
        WorldFactory factory;
        internal WorldFactory Factory => factory;

        // ==== Repo ====
        FieldRepo fieldRepo;
        internal FieldRepo FieldRepo => fieldRepo;

        RoleLogicRepo roleLogicRepo;
        internal RoleLogicRepo RoleLogicRepo => roleLogicRepo;

        RoleRendererRepo roleRendererRepo;
        internal RoleRendererRepo RoleRendererRepo => roleRendererRepo;

        // ==== Service ====
        IDService idService;
        internal IDService IDService => idService;

        internal WorldContext() {

            stateEntity = new WorldStateEntity();

            factory = new WorldFactory();

            fieldRepo = new FieldRepo();
            roleLogicRepo = new RoleLogicRepo();
            roleRendererRepo = new RoleRendererRepo();

            idService = new IDService();

        }

    }

}