using UnityEngine;

namespace ThePlain.World.Entities {

    public class RoleLogicEntity : MonoBehaviour {

        int id;
        public int ID => id;
        public void SetID(int id) => this.id = id;

        Rigidbody rb;
        public Rigidbody RB => rb;

        public void Ctor() {
            rb = GetComponent<Rigidbody>();
        }

    }

}