using System;

namespace ThePlain.Infra {

    public class InfraEventCenter {

        public event Action OnStartGameHandle;
        public void InvokeStartGame() => OnStartGameHandle?.Invoke();

        public InfraEventCenter() {}

    }

}