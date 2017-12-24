using UnityEngine;

namespace Example
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game data")]
    public class GameData : ScriptableObject
    {
        [SerializeField]
        int observableTime;
        public int ObservableTime { get { return observableTime; } }
    }
}