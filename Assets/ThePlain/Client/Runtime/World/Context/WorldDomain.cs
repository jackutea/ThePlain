using ThePlain.World.Domain;

namespace ThePlain.World.Facades {

    public class WorldDomain {

        WorldStateDomain worldStateDomain;
        internal WorldStateDomain WorldStateDomain => worldStateDomain;

        FieldDomain fieldDomain;
        internal FieldDomain FieldDomain => fieldDomain;

        RoleLogicDomain roleLogicDomain;
        internal RoleLogicDomain RoleLogicDomain => roleLogicDomain;

        RoleRendererDomain roleRendererDomain;
        internal RoleRendererDomain RoleRendererDomain => roleRendererDomain;

        public WorldDomain() {
            worldStateDomain = new WorldStateDomain();
            fieldDomain = new FieldDomain();
            roleLogicDomain = new RoleLogicDomain();
            roleRendererDomain = new RoleRendererDomain();
        }

    }

}