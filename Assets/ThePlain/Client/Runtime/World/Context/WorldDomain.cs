using ThePlain.World.Domain;

namespace ThePlain.World.Facades {

    public class WorldDomain {

        FieldDomain fieldDomain;
        internal FieldDomain FieldDomain => fieldDomain;

        RoleLogicDomain roleLogicDomain;
        internal RoleLogicDomain RoleLogicDomain => roleLogicDomain;

        RoleRendererDomain roleRendererDomain;
        internal RoleRendererDomain RoleRendererDomain => roleRendererDomain;

        public WorldDomain() {
            fieldDomain = new FieldDomain();
            roleLogicDomain = new RoleLogicDomain();
            roleRendererDomain = new RoleRendererDomain();
        }

    }

}