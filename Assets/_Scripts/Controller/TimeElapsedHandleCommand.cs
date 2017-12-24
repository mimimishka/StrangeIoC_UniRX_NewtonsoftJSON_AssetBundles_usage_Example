using UnityEngine;
using strange.extensions.command.impl;

namespace Example
{
    public class TimeElapsedHandleCommand : Command
    {
        [Inject]
        public PrimitiveView View { get; private set; }

        public override void Execute()
        {
            Color newColor = new Color();
            newColor.r = Random.Range(0f, 1f);
            newColor.g = Random.Range(0f, 1f);
            newColor.b = Random.Range(0f, 1f);
            View.Model.Color.Value = newColor;
        }
    }
}