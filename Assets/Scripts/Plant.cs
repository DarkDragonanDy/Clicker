using UnityEngine;

namespace DefaultNamespace
{
    public enum CostType
    {
        Stone1,
        Stone2,
        Stone3,
        Stone4
    }
    
    public class Plant : MonoBehaviour
    {
        public string name;
        public float timeToGrow;
        public CostType type;
        public int cost;
        public int moneyBrings;
        [TextArea(15, 20)]
        public string description;
        public Sprite icon;
        
    }
}