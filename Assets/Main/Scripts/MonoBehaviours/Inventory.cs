using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [DisallowMultipleComponent]
    public class Inventory : MonoBehaviour {

        [SerializeField] List<Slot> _currentItems;

        public void AddItem (Item item, int amount = 1) {

            bool isItemAlreadyExist = false;

            foreach (Slot slot in _currentItems) {
                if (slot.item == item) {
                    slot.amount += amount;
                    isItemAlreadyExist = true;
                    break;
                }
            }

            if (!isItemAlreadyExist) {
                _currentItems.Add(new Slot(item, amount));
            }
        }

        public void ConsumeItem (Item item, int amount = 1) {

            foreach (Slot slot in _currentItems) {
                if (slot.item == item) {
                    slot.amount -= amount;

                    if (slot.amount <= 0) {
                        _currentItems.Remove(slot);
                    }

                    break;
                }
            }
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
