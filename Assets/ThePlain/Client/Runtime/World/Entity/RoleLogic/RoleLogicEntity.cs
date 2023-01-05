using UnityEngine;

namespace ThePlain.World.Entities {

    public class RoleLogicEntity : MonoBehaviour {

        int id;
        public int ID => id;
        public void SetID(int id) => this.id = id;

        Rigidbody rb;
        public Rigidbody RB => rb;

        RoleInputRecordComponent inputCom;
        public RoleInputRecordComponent InputCom => inputCom;

        public void Ctor() {
            
            rb = GetComponent<Rigidbody>();

            inputCom = new RoleInputRecordComponent();

        }

    }

}