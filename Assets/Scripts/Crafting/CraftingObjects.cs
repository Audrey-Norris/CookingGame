using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class ItemList {
        public Item item;
        public int total;

        public ItemList() {
            this.total = 1;
        }

        //General Version
        public ItemList(Item item, int total) {
            this.item = item;
            this.total = total;
        }

        public Item GetItem() {
            return item;
        }

        public int GetTotal() {
            return total;
        }

        public void SetTotal(int total) {
            this.total = total;
        }

}

[System.Serializable]
public struct Flavor {
    public string name;
    public int total;

    public Flavor(string Name) {
        this.name = Name;
        this.total = 0;
    }
}
