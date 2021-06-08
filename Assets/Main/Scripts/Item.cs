using Math = System.Math;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectTestGoose {

    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
    public class Item : ScriptableObject {

        public enum Type {
            None,
            WhiteChoco,
            BlackChoco,
            WhitePotion,
            RedPotion,
            OrangePotion,
            YellowPotion,
            GreenPotion,
            BluePotion,
            Key
        }


        public Type type = Type.None;
        public string itemName;
        public string description;
        public Sprite icon;

    }
}
