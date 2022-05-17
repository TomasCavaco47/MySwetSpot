using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "Resources", menuName = "Scriptable/Create ShopData")]
    public class ShopSaveScriptable : ScriptableObject
    {
        [SerializeField] int _selectIndex;
        [SerializeField] ShopItem[] shopItems;

        public int SelectIndex { get => _selectIndex; set => _selectIndex = value; }
        public ShopItem[] ShopItems { get => shopItems; set => shopItems = value; }
    }
        [System.Serializable]
        public class ShopItem
        {
            [SerializeField] string _itemName;
            [SerializeField] bool _isUnlocked;
            [SerializeField] int _unlockCost;
            [SerializeField] int _unlockLeve1;
            [SerializeField] CarInfo[] _CarLevel;

        public string ItemName { get => _itemName; set => _itemName = value; }
        public int UnlockLeve1 { get => _unlockLeve1; set => _unlockLeve1 = value; }
        public CarInfo[] CarLevel { get => _CarLevel; set => _CarLevel = value; }
    }

        [System.Serializable]
        public class CarInfo
        {
            [SerializeField] int _unlockCost;
            [SerializeField] int _Maxspeed;
            [SerializeField] int _acceleration;

        public int Maxspeed { get => _Maxspeed; set => _Maxspeed = value; }
        public int Acceleration { get => _acceleration; set => _acceleration = value; }
        // [SerializeField] int _Turn;
    }
}

 