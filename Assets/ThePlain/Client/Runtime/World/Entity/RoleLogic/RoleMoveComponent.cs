using UnityEngine;
using GameArki.FPEasing;

namespace ThePlain.World.Entities {

    public class RoleMoveComponent {

        Rigidbody rb;

        float forwardSpeedMax = 25f;
        float forwardTouchMaxTime = 5f;
        float forwardMaintainTime;

        float backwardSpeedMax = 25f;
        float backwardTouchMaxTime = 5f;

        float horizontalSpeedMax = 25f;
        float horizontalTouchMaxTime = 5f;
        float horizontalMaintainTime;

        float fallingAccelerate = 25f;
        float fallingSpeedMax = 60f;

        float jumpSpeed = 10f;

        bool isJump;
        bool isGround;

        public RoleMoveComponent() {}

        public void Inject(Rigidbody rb) {
            this.rb = rb;
        }

        public void Move(Vector2 moveAxis, float dt, Vector3 cameraForward, Vector3 cameraRight) {

            // Forward
            if (moveAxis.y > 0) {
                if (forwardMaintainTime < 0) {
                    forwardMaintainTime += dt * 5f;
                } else {
                    forwardMaintainTime += dt;
                }
                if (forwardMaintainTime > forwardTouchMaxTime) {
                    forwardMaintainTime = forwardTouchMaxTime;
                }
            } else if (moveAxis.y < 0) {
                if (forwardMaintainTime > 0) {
                    forwardMaintainTime -= dt * 5f;
                } else {
                    forwardMaintainTime -= dt;
                }
                if (forwardMaintainTime < -backwardTouchMaxTime) {
                    forwardMaintainTime = -backwardTouchMaxTime;
                }
            } else {
                if (forwardMaintainTime > 0) {
                    forwardMaintainTime -= dt * 1.5f;
                    if (forwardMaintainTime <= 0) {
                        forwardMaintainTime = 0;
                    }
                } else if (forwardMaintainTime < 0) {
                    forwardMaintainTime += dt * 1.5f;
                    if (forwardMaintainTime >= 0) {
                        forwardMaintainTime = 0;
                    }
                }
            }

            float forwardSpeed;
            if (forwardMaintainTime > 0) {
                forwardSpeed = CaculateSpeed(forwardSpeedMax, forwardTouchMaxTime, forwardMaintainTime);
            } else if (forwardMaintainTime < 0) {
                forwardSpeed = -CaculateSpeed(backwardSpeedMax, backwardTouchMaxTime, -forwardMaintainTime);
            } else {
                forwardSpeed = 0;
            }

            // Horizontal
            if (moveAxis.x > 0) {
                horizontalMaintainTime += dt;
                if (horizontalMaintainTime > horizontalTouchMaxTime) {
                    horizontalMaintainTime = horizontalTouchMaxTime;
                }
            } else if (moveAxis.x < 0) {
                horizontalMaintainTime -= dt;
                if (horizontalMaintainTime < -horizontalTouchMaxTime) {
                    horizontalMaintainTime = -horizontalTouchMaxTime;
                }
            } else {
                horizontalMaintainTime -= dt;
                if (horizontalMaintainTime < 0) {
                    horizontalMaintainTime = 0;
                }
            }

            float horizontalSpeed;
            if (horizontalMaintainTime > 0) {
                horizontalSpeed = CaculateSpeed(horizontalSpeedMax, horizontalTouchMaxTime, horizontalMaintainTime);
            } else if (horizontalMaintainTime < 0) {
                horizontalSpeed = -CaculateSpeed(horizontalSpeedMax, horizontalTouchMaxTime, -horizontalMaintainTime);
            } else {
                horizontalSpeed = 0;
            }

            // Move
            var velo = rb.velocity;
            float oldY = velo.y;

            var forward = cameraForward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraRight;
            right.y = 0;
            right.Normalize();

            var moveDir = forward * forwardSpeed + right * horizontalSpeed;
            velo = moveDir;
            velo.y = oldY;

            rb.velocity = velo;

        }

        float CaculateSpeed(float speedMax, float touchMaxTime, float maintainTime) {
            return EasingHelper.Ease1D(EasingType.OutCubic, maintainTime, touchMaxTime, 0, speedMax);
        }

        public void Jump(bool isPressJumping) {
            if (isPressJumping && isGround && !isJump) {
                isJump = true;
                isGround = false;
                var velo = rb.velocity;
                velo.y = jumpSpeed;
                rb.velocity = velo;
            }
        }

        public void Falling(float dt) {
            var velo = rb.velocity;
            velo.y -= fallingAccelerate * dt;
            if (velo.y < -fallingSpeedMax) {
                velo.y = -fallingSpeedMax;
            }
            rb.velocity = velo;
        }

        public void EnterGround() {
            isGround = true;
            isJump = false;
        }

    }
}