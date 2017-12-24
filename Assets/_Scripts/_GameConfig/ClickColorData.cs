using UnityEngine;

namespace Example
{
    [System.Serializable]
    public class ClickColorData
    {
        [SerializeField]
        string objectType;
        [SerializeField]
        int minClicksCount;
        [SerializeField]
        int maxClicksCount;
        [SerializeField]
        Color color;
        public string ObjectType { get { return objectType; } }
        public int MinClicksCount { get { return minClicksCount; } }
        public int MaxClicksCount { get { return maxClicksCount; } }
        public Color Color { get { return color; } }
    }
}