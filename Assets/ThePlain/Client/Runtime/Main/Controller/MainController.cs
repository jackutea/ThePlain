using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Main.Facades;
using ThePlain.Infra.Facades;

namespace ThePlain.Main.Controller {

    public class MainController {

        MainContext mainContext;
        InfraContext infraContext;

        public MainController() {
            mainContext = new MainContext();
        }

        public void Inject(InfraContext infraContext) {
            this.infraContext = infraContext;
        }

        public void Init() {

            var ui = infraContext.UI;
            var setter = ui.Setter;
            setter.LoginPage_Open();
            setter.LoginPage_Binding_StartGame(() => {
                infraContext.EventCenter.InvokeStartGame();
                setter.LoginPage_Close();
            });

        }

    }

}