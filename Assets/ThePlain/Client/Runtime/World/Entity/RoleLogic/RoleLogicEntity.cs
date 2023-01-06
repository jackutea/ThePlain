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

        public void MoveByInput(Vector3 cameraForward, Vector3 cameraRight) {

            var inputCom = this.inputCom;
            var rb = this.rb;
            var speed = 5.5f;
            var dir = inputCom.moveAxis;

            var forward = cameraForward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraRight;
            right.y = 0;
            right.Normalize();

            var moveDir = forward * dir.y + right * dir.x;
            rb.velocity = moveDir * speed;

        }

    }

}