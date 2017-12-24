using UnityEngine;
using strange.extensions.command.impl;

namespace Example
{
    public class ViewClickHandleCommand : Command
    {
        [Inject]
        public PrimitiveView View { get; private set; }
        [Inject]
        public PrimitiveGenerator Generator { get; private set; }
        [Inject]
        public PrimitiveColorAccessor ColorAccessor { get; private set; }

        public override void Execute()
        {
            ++View.Model.ClickCount.Value;
            Color newColor;
            if (ColorAccessor.GetColor(View, out newColor))
                View.Model.Color.Value = newColor;
        }
    }
}