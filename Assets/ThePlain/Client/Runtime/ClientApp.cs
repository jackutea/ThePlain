using System;
using UnityEngine;
using ThePlain.Main.Controller;
using ThePlain.Main.Facades;
using ThePlain.Infra.Controller;
using ThePlain.Infra.Facades;
using ThePlain.World.Controller;

namespace ThePlain.Main.Entry {

    public class ClientApp : MonoBehaviour {

        InfraContext infraContext;
        InfraController infraController;

        MainContext mainContext;
        MainController mainController;

        WorldController worldController;

        bool isInit;

        void Awake() {

            infraContext = new InfraContext();
            infraController = new InfraController();

            mainController = new MainController();
            worldController = new WorldController();

            mainController.Inject(infraContext);
            infraController.Inject(infraContext);
            worldController.Inject(infraContext);

            Action action = async () => {

                var canvas = GetComponentInChildren<Canvas>();
                await infraController.Init(canvas);

                mainController.Init();
                worldController.Init();

                isInit = true;

            };

            action.Invoke();

        }

        void FixedUpdate() {

            if (!isInit) {
                return;
            }

            worldController.FixedTick();

        }

        void Update() {

            if (!isInit) {
                return;
            }

            float dt = Time.deltaTime;
            worldController.Tick();

        }

        void LateUpdate() {

            if (!isInit) {
                return;
            }

            float dt = Time.deltaTime;
            infraController.LateTick(dt);

        }

    }

}