using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Main.Facades;
using ThePlain.Infra.Facades;

namespace ThePlain.Main.Controller {

    public class MainController {

        public MainController() { }

        public void Init(MainContext mainContext, InfraContext infraContext) {

            var ui = infraContext.UI;
            var setter = ui.Setter;
            setter.LoginPage_Open();
            setter.LoginPage_Binding_StartGame(() => {
                infraContext.EventCenter.InvokeStartGame();
                setter.LoginPage_Close();
            });

        }

        public void Tick() {

        }

    }

}