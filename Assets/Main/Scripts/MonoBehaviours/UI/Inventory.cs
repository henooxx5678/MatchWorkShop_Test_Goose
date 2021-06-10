using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class Inventory : MonoBehaviour {

        [SerializeField] List<Slot> _currentItemSlots;

        [Header("REFS")]
        [SerializeField] Transform _itemSlotsParent;
        [SerializeField] ItemDescriptionDisplay _itemDescriptionDisplay;

        [Header("Prefabs")]
        [SerializeField] GameObject _inventoryItemSlotClickablePrefab;

        void Start () {
            _itemDescriptionDisplay.ItemConsumed += OnItemConsumed;

            UpdateDisplay();
        }

        public void Hide () {
            gameObject.SetActive(false);
            _itemDescriptionDisplay.Hide();
        }

        public void Show () {
            gameObject.SetActive(true);
        }

        public void AddItem (Item item, int amount = 1) {

            bool isItemAlreadyExist = false;

            foreach (Slot slot in _currentItemSlots) {
                if (slot.item == item) {
                    slot.amount += amount;
                    isItemAlreadyExist = true;
                    break;
                }
            }

            if (!isItemAlreadyExist) {
                _currentItemSlots.Add(new Slot(item, amount));
            }

            UpdateDisplay();
        }

        public void ConsumeItem (Item item, int amount = 1) {

            foreach (Slot slot in _currentItemSlots) {
                if (slot.item == item) {
                    slot.amount -= amount;

                    if (slot.amount <= 0) {
                        _currentItemSlots.Remove(slot);

                        if (_itemDescriptionDisplay.CurrentItem == slot.item) {
                            _itemDescriptionDisplay.Hide();
                        }
                    }

                    break;
                }
            }

            UpdateDisplay();
        }


        void UpdateDisplay () {
            foreach (Transform child in _itemSlotsParent) {
                Destroy(child.gameObject);
            }

            for (int i = 0 ; i < _currentItemSlots.Count ; i++) {

                Slot slot = _currentItemSlots[i];

                GameObject inventoryItemSlotClickable = Instantiate(_inventoryItemSlotClickablePrefab, _itemSlotsParent);
                inventoryItemSlotClickable.GetComponent<InventoryItemSlot>().Set(slot);
                inventoryItemSlotClickable.GetComponent<Button>().onClick.AddListener( () => ItemSlotClicked(inventoryItemSlotClickable) );

                if (_itemDescriptionDisplay.IsShowing) {
                    if (_itemDescriptionDisplay.CurrentItem == slot.item) {
                        _itemDescriptionDisplay.Show(slot);
                    }
                }
            }
        }

        void ItemSlotClicked (GameObject itemSlotClickable) {
            _itemDescriptionDisplay.Show(_currentItemSlots[itemSlotClickable.transform.GetSiblingIndex()]);
        }

        void OnItemConsumed (object sender, ItemDescriptionDisplay.ItemConsumeEventArgs args) {
            ConsumeItem(args.item);
        }


        [System.Serializable]
        public class Slot {
            public Item item;
            public int amount = 0;

            public Slot (Item item, int amount) {
                this.item = item;
                this.amount = amount;
            }
        }

    }
}
