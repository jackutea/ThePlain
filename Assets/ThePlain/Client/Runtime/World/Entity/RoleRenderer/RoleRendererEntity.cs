using UnityEngine;

namespace ThePlain.World.Entities {

    public class RoleRendererEntity : MonoBehaviour {

        int id;
        public int ID => id;
        public void SetID(int id) => this.id = id;

        MeshRenderer mesh;

        public void Ctor() {
            var body = transform.GetChild(0);
            mesh = body.GetChild(0).GetComponent<MeshRenderer>();
        }

    }

}