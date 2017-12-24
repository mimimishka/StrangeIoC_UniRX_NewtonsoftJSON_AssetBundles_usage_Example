using UnityEngine;
using strange.extensions.command.impl;

namespace Example
{
    public class CreateClickDetectorCommand : Command
    {
        public override void Execute()
        {
            GameObject go = new GameObject("Click detector");
            go.AddComponent<ClickDetectorView>();
        }
    }
}