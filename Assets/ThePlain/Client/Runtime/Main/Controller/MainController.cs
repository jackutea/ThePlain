using System.Threading.Tasks;
using UnityEngine;
using ThePlain.Main.Facades;

namespace ThePlain.Main.Controller {

    public class MainController {

        public MainController() { }

        public void Init(MainContext mainContext, InfraContext infraContext) {

            var ui = infraContext.UI;
            var setter = ui.Setter;
            setter.LoginPage_Open();
            setter.LoginPage_Binding_StartGame(() => {
                setter.LoginPage_Close();
            });

            infraContext.AssetCore.Getter.TryGetWorldAsset("entity_role", out var go);
            var entity = Object.Instantiate(go);

        }

        public void Tick() {

        }

    }

}