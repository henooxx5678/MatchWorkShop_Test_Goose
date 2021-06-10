using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class ItemDescriptionDisplay : MonoBehaviour {

        [Header("REFS")]
        [SerializeField] Text _itemNameText;
        [SerializeField] Text _itemDescriptionText;
        [SerializeField] InventoryItemSlot _itemSlotDisplay;
        [SerializeField] ConsumeButtonBehaveHandler _consumeButtonBehaveHandler;

        public Item CurrentItem {get; private set;} = null;
        public int CurrentAmount {get; private set;} = 0;

        public bool IsShowing => gameObject.activeSelf;

        public event EventHandler<ItemConsumeEventArgs> ItemConsumed;


        void Start () {
            _consumeButtonBehaveHandler.Consumed += OnConsumed;
        }

        public void Hide ()  {
            gameObject.SetActive(false);
        }

        public void Show (Inventory.Slot slot) {
            gameObject.SetActive(true);

            CurrentItem = slot.item;
            CurrentAmount = slot.amount;

            UpdateDisplay();
        }

        void UpdateDisplay () {
            if (CurrentItem != null) {
                _itemNameText.text = CurrentItem.itemName;
                _itemDescriptionText.text = CurrentItem.description;
                _itemSlotDisplay.Set(CurrentItem, CurrentAmount);
            }
        }

        void OnConsumed (object sender, EventArgs args) {

            if (ItemConsumed != null) {
                ItemConsumed(this, new ItemConsumeEventArgs(CurrentItem));
            }
        }


        public class ItemConsumeEventArgs : EventArgs {
            public Item item;

            public ItemConsumeEventArgs(Item item) {
                this.item = item;
            }
        }

    }
}
