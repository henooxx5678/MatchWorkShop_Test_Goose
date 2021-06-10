using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class InventoryItemSlot : MonoBehaviour {

        [SerializeField] Item _item;
        [SerializeField] int _amount;

        [Header("REFS")]
        [SerializeField] Image _iconImage;
        [SerializeField] Text _amountText;

        public void Set (Inventory.Slot slot) {
            Set(slot.item, slot.amount);
        }

        public void Set (Item item, int amount) {
            _item = item;
            _amount = amount;

            UpdateDisplay();
        }

        void UpdateDisplay () {
            if (_item != null) {
                _iconImage.sprite = _item.icon;
            }
            _amountText.text = _amount.ToString();
        }


    }
}
