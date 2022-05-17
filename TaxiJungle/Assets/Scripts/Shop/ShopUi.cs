//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//namespace ShopSystem
//{
    
// public class ShopUi : MonoBehaviour
// {
//        [SerializeField] int _totalCoins = 5000;
//        [SerializeField] ShopSaveScriptable _shopData;
//        [SerializeField] GameObject[] _carsModels;
//        [SerializeField] Text _unlockBtnText, _upgradeBtnText, _levelText, _carNameText;
//        [SerializeField] Text _maxSpeedText, _accelarationText, _totalCoinsText;
//        [SerializeField] Button _unlockBtn, _upgradeBtn, _nextBtn, _previousBtn;

//        int _currentIndex = 0;
//        int _selectedIndex = 0;

//        private void Start()
//        {
//            _selectedIndex = _shopData.SelectIndex;
//            _currentIndex = _selectedIndex;
//            _totalCoinsText.text = "" + _totalCoins;
//            SetCarInfo();


//        }

//        void SetCarInfo()
//        {
//            _carNameText.text = _shopData.ShopItems[_currentIndex].ItemName;
//            int currentLevel = _shopData.ShopItems[_currentIndex].UnlockLeve1;
//            _levelText.text = "Level1:" + (currentLevel + 1);
//            _maxSpeedText.text = "Speed:" + _shopData.ShopItems[_currentIndex].CarLevel[currentLevel].Maxspeed;
//            _accelarationText.text = "Acc:" + _shopData.ShopItems[_currentIndex].CarLevel[currentLevel].Acceleration;
//        }

//        public void NextBtnMethod()
//        {

//        }
//        void PreviousBtnMethod()
//        {

//        } 
//        void UnlockSelectBtnMethod()
//        {

//        } 
//        void UpgradeBtnMethod()
//        {

//        }
//    }

//}
