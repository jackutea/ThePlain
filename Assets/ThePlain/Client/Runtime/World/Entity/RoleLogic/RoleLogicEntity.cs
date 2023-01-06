using System;
using UnityEngine;

namespace ThePlain.World.Entities {

    public class RoleLogicEntity : MonoBehaviour {

        int id;
        public int ID => id;
        public void SetID(int id) => this.id = id;

        Rigidbody rb;
        public Vector3 Pos => rb.position;
        public Quaternion Rot => rb.rotation;
        public void SetPos(Vector3 value) => rb.position = value;

        RoleInputRecordComponent inputCom;
        public RoleInputRecordComponent InputCom => inputCom;

        RoleMoveComponent moveCom;
        public RoleMoveComponent MoveCom => moveCom;

        public event Action<RoleLogicEntity, Collision> OnCollisionEnterHandle;

        public void Ctor() {

            rb = GetComponent<Rigidbody>();

            inputCom = new RoleInputRecordComponent();
            
            moveCom = new RoleMoveComponent();
            moveCom.Inject(rb);

        }

        public void MoveByInput(float dt, Vector3 cameraForward, Vector3 cameraRight) {
            moveCom.Move(inputCom.moveAxis, dt, cameraForward, cameraRight);
        }

        public void Jump() {
            moveCom.Jump(inputCom.isJumping);
        }

        public void Falling(float dt) {
            moveCom.Falling(dt);
        }

        public void EnterGround() {
            moveCom.EnterGround();
        }

        void OnCollisionEnter(Collision other) {
            OnCollisionEnterHandle.Invoke(this, other);
        }

    }

}