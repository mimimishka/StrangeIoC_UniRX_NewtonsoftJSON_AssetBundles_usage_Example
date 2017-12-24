using UnityEngine;
using strange.extensions.command.impl;

namespace Example
{
    public class ViewCreatedHandleCommand : Command
    {
        //[Inject]
        //public PrimitiveGenerator Generator { get; private set; }
        [Inject]
        public PrimitiveView View { get; private set; }
        [Inject]
        public PrimitiveColorAccessor ColorAccessor { get; private set; }
        public override void Execute()
        {
            Color newColor;
            if (ColorAccessor.GetColor(View, out newColor))
                View.Model.Color.Value = newColor;
        }
    }
}