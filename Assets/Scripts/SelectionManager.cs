using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    Transform selectionTransform;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemDescription();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }
        }
    }

    public void UseInteractableItem(Item item)
    {
        if (item && selectionTransform.GetComponent<InteractableObject>())
        {
            selectionTransform.GetComponent<InteractableObject>().Interact(item);
        }
    }
}