using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDay : MonoBehaviour
{

    private GameObject saveManager;

    [SerializeField] private int spicesTotal = 6;

    [SerializeField] private int totalQuests = 5;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveManager");
        if (CheckTutorial()) {
            SetupIngredients();
            SetupQuests();
        }
    }

    public bool CheckTutorial() {
        return saveManager.GetComponent<QuestsManager>().isTutorial;
    }

    public void SetupIngredients() {
        InventoryManager inventory = saveManager.GetComponent<InventoryManager>();

        foreach(ItemList item in inventory.GetAllItems()) {
            if (item.item.getItemType() == ItemType.Spice) {
                item.SetTotal(spicesTotal);
            }
        }

    }

    public void SetupQuests() {
        QuestsManager quests = saveManager.GetComponent<QuestsManager>();

        List<Quests> newQuests = quests.allQuests.FindAll(x => x.isCompleted == false);
        quests.currentQuests.Clear();
        
        for(int i = 0; i < totalQuests; i++) {
            int newQuest = Random.Range(0, newQuests.Count);
            quests.currentQuests.Add(newQuests[newQuest]);

            newQuests.RemoveAt(newQuest);
        }
        
    }

    /* THINGS TO DO
     * 1. ADD QUESTS TO THE QUEST BOARD - EVENTUALLY CHECK RENOWN FOR THAT
     * 2. RESET INGREDIENT LEVELS - ADD A BASELINE INGREDIENT LEVEL
     * 3. SET ANYTHING THAT NEEDS TO BE SET
     */


}
