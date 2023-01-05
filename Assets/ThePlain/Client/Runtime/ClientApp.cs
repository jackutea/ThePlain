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
            mainContext = new MainContext();

            worldController = new WorldController();

            Action action = async () => {

                var canvas = GetComponentInChildren<Canvas>();
                await infraController.Init(canvas, infraContext);

                mainController.Init(mainContext, infraContext);
                worldController.Init(infraContext);

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
            mainController.Tick();
            worldController.Tick(infraContext);
        }

    }

}