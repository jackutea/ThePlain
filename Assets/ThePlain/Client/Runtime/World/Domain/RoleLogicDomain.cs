using UnityEngine;
using ThePlain.World.Entities;
using ThePlain.World.Facades;
using ThePlain.Infra.Facades;
using ThePlain.World.Service;

namespace ThePlain.World.Domain {

    internal class RoleLogicDomain {

        InfraContext infraContext;
        WorldContext worldContext;

        internal RoleLogicDomain() { }

        internal void Inject(InfraContext infraContext, WorldContext worldContext) {
            this.infraContext = infraContext;
            this.worldContext = worldContext;
        }

        internal RoleLogicEntity Spawn(Vector3 pos) {

            var factory = worldContext.Factory;
            var assetCore = infraContext.AssetCore;
            var role = factory.CreateRoleLogic(assetCore);
            role.OnCollisionEnterHandle += Collision_Role_Other;

            role.SetPos(pos);

            var idService = worldContext.IDService;
            var id = idService.PickRoleID();
            role.SetID(id);

            var repo = worldContext.RoleLogicRepo;
            repo.Add(role);

            return role;

        }

        internal void RecordOwnerInput(RoleLogicEntity ownerRole) {

            var inputCom = ownerRole.InputCom;
            var input = infraContext.InputCore;
            var inputGetter = input.Getter;

            // Move
            Vector2 moveAxis;
            if (inputGetter.GetPressing(InputKeyCollection.MOVE_FWD)) {
                moveAxis.y = 1;
            } else if (inputGetter.GetPressing(InputKeyCollection.MOVE_BWD)) {
                moveAxis.y = -1;
            } else {
                moveAxis.y = 0;
            }

            if (inputGetter.GetPressing(InputKeyCollection.MOVE_LEFT)) {
                moveAxis.x = -1;
            } else if (inputGetter.GetPressing(InputKeyCollection.MOVE_RIGHT)) {
                moveAxis.x = 1;
            } else {
                moveAxis.x = 0;
            }
            inputCom.moveAxis = moveAxis;

            // Jump
            if (inputGetter.GetPressing(InputKeyCollection.JUMP)) {
                inputCom.isJumping = true;
            } else {
                inputCom.isJumping = false;
            }

            // Camera
            Vector2 cameraRotAxis;
            if (Input.GetMouseButton(1)) {
                cameraRotAxis.x = Input.GetAxis("Mouse X");
                cameraRotAxis.y = Input.GetAxis("Mouse Y");
            } else {
                cameraRotAxis.x = 0;
                cameraRotAxis.y = 0;
            }

            inputCom.cameraRotAxis = cameraRotAxis;

        }

        internal void Move(float dt, RoleLogicEntity role) {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;
            role.MoveByInput(dt, cameraForward, cameraRight);
        }

        internal void Jump(RoleLogicEntity role) {
            role.Jump();
        }

        internal void Falling(float dt, RoleLogicEntity role) {
            role.Falling(dt);
        }

        void Collision_Role_Other(RoleLogicEntity role, Collision other) {
            if (other.gameObject.layer == LayerCollection.GROUND) {
                role.EnterGround();
                Debug.Log("Enter Ground");
            }
        }

    }

}