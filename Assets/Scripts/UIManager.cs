using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI questDescriptionText;

    void OnEnable()
    {
        DisplayQuestInfo(questDescriptionText);
    }

    void DisplayQuestInfo(TextMeshProUGUI textToDisplay)
    {
        textToDisplay.text = "";

        foreach (var quest in QuestManager.instance.activeQuests)
        {
            if (quest.questDescription == "")
            {
                quest.CreateDescription();
            }

            textToDisplay.text += quest.questDescription + "\n";
        }

        foreach (var quest in QuestManager.instance.closedQuests)
        {
            textToDisplay.text += "<s>" + quest.questDescription + "</s>" + "\n";
        }
    }
}
