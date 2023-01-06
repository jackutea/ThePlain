using System;
using UnityEngine;

namespace ThePlain.World.Entities {

    public class RoleLogicEntity : MonoBehaviour {

        int id;
        public int ID => id;
        public void SetID(int id) => this.id = id;

        Rigidbody rb;
        public Rigidbody RB => rb;

        bool isGround;
        bool isJump;

        RoleInputRecordComponent inputCom;
        public RoleInputRecordComponent InputCom => inputCom;

        public event Action<RoleLogicEntity, Collision> OnCollisionEnterHandle;

        public void Ctor() {

            rb = GetComponent<Rigidbody>();

            inputCom = new RoleInputRecordComponent();

        }

        public void MoveByInput(Vector3 cameraForward, Vector3 cameraRight) {

            var inputCom = this.inputCom;
            var rb = this.rb;
            var speed = 5.5f;
            var dir = inputCom.moveAxis;

            var velo = rb.velocity;
            float oldY = velo.y;

            var forward = cameraForward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraRight;
            right.y = 0;
            right.Normalize();

            var moveDir = forward * dir.y + right * dir.x;
            velo = moveDir * speed;
            velo.y = oldY;

            rb.velocity = velo;

        }

        public void Jump() {
            if (inputCom.isJumping && isGround && !isJump) {
                isJump = true;
                isGround = false;
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }

        public void EnterGround() {
            isGround = true;
            isJump = false;
        }

        void OnCollisionEnter(Collision other) {
            OnCollisionEnterHandle.Invoke(this, other);
        }

    }

}