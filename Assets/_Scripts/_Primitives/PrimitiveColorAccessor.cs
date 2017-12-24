using UnityEngine;

namespace Example
{
    public class PrimitiveColorAccessor
    {
        [Inject]
        public GeometryObjectData GOData { get; private set; }

        public bool GetColor(PrimitiveView view, out Color color)
        {
            color = Color.black;
            foreach (ClickColorData data in GOData.ClicksData)
            {
                if (data.ObjectType == view.Name &&
                      view.Model.ClickCount.Value >= data.MinClicksCount &&
                      view.Model.ClickCount.Value <= data.MaxClicksCount)
                {
                    color = data.Color;
                    return true;
                }
            }
            return false;
        }
    }
}