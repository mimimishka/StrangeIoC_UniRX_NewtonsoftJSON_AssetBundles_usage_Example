using UnityEngine;
using strange.extensions.command.impl;

namespace Example
{
    public class CreatePrimitiveCommand : Command
    {
        [Inject]
        public Vector3Box ClickPosition { get; private set; }
        [Inject]
        public PrimitiveGenerator Generator { get; private set; }
        public override void Execute()
        {
            Primitive prim = Generator.GenPrimitive();
            PrimitiveView view = GameObject.Instantiate(prim.Prefab).GetComponent<PrimitiveView>();
            Vector3 pos = ClickPosition.Vector;
            pos.z = Camera.main.nearClipPlane + 1;
            Vector3 newPos = Camera.main.ScreenToWorldPoint(pos);
            view.transform.position = newPos;
            view.Name = prim.Name;
        }
    }
}