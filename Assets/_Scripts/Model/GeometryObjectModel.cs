using UnityEngine;
using UniRx;

namespace Example
{
    public class GeometryObjectModel
    {
        public ReactiveProperty<int> ClickCount { get; set; }
        public ReactiveProperty<Color> Color { get; set; }
        public GeometryObjectModel()
        {
            ClickCount = new ReactiveProperty<int>(0);
            Color = new ReactiveProperty<Color>();
        }
    }
}