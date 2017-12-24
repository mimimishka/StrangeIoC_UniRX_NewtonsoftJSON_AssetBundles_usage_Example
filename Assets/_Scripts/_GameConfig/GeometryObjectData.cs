using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    [CreateAssetMenu(fileName ="ClicksConfig", menuName = "Clicks config")]
    public class GeometryObjectData : ScriptableObject
    {
        [SerializeField]
        List<ClickColorData> clicksData;
        public List<ClickColorData> ClicksData { get { return clicksData; } }
    }
}