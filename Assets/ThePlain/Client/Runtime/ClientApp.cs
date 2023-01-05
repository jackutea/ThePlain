using System;
using UnityEngine;
using GameArki.TripodCamera;
using GameArki.FreeInput;
using ThePlain.Main.Controller;
using ThePlain.Main.Facades;
using ThePlain.Infra.Controller;

namespace ThePlain.Main.Entry {

    public class ClientApp : MonoBehaviour {

        InfraContext infraContext;
        InfraController infraController;

        MainContext mainContext;
        MainController mainController;

        bool isInit;

        void Awake() {

            infraContext = new InfraContext();
            infraController = new InfraController();

            mainController = new MainController();
            mainContext = new MainContext();

            Action action = async () => {

                var canvas = GetComponentInChildren<Canvas>();
                await infraController.Init(canvas, infraContext);

                mainController.Init(mainContext, infraContext);

                isInit = true;

            };

            action.Invoke();

        }

        void Update() {
            if (!isInit) {
                return;
            }
            mainController.Tick();
        }

    }

}