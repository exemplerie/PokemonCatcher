using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> activeQuests;
    public List<Quest> closedQuests;

    void Start()
    {
        instance = this;
    }

    public void UpdateQuestProgress(PokemonType pokemonType)
    {
        List<Quest> questsToRemove = new List<Quest>();

        foreach (var quest in activeQuests)
        {
            if (quest.pokemonType == pokemonType)
            {
                quest.UpdateProgress();
                if (quest.IsCompleted())
                    questsToRemove.Add(quest);
            }
        }

        foreach (var questToRemove in questsToRemove)
        {
            QuestCompletion(questToRemove);
        }

        if (activeQuests.Count == 0)
        {
            Messenger.Broadcast(GameEvent.QUEST_COMPLETE);
        }
    }


    private void QuestCompletion(Quest quest)
    {
        closedQuests.Add(quest);
        activeQuests.Remove(quest);
    }
}
