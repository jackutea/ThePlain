namespace ThePlain.World.Service {

    public class IDService {

        int roleIDRecord;

        public IDService() {
            roleIDRecord = 0;
        }

        public int PickRoleID() {
            roleIDRecord += 1;
            return roleIDRecord;
        }
    }
}