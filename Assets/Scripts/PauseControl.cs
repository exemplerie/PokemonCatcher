using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject Settings;
    public GameObject [] onDisableObjects;
    private FirstPersonController personController;
    private PlayerCharacter playerCharacter;

    public GameObject endScene;

    private void Start()
    {
        personController = gameObject.GetComponent<FirstPersonController>();
        playerCharacter = gameObject.GetComponent<PlayerCharacter>();
        Messenger.AddListener(GameEvent.QUEST_COMPLETE, OpenEndScene);
        PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
        Settings.SetActive(true);
        for (int i = 0; i < onDisableObjects.Length; i++)
        {
            GameObject obj = onDisableObjects[i];
            obj.SetActive(false);
        }
        
        personController.enabled = !personController.enabled;
        playerCharacter.enabled = !playerCharacter.enabled;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
        Settings.SetActive(false);
        for (int i = 0; i < onDisableObjects.Length; i++)
        {
            GameObject obj = onDisableObjects[i];
            obj.SetActive(true);
        }
        personController.enabled = !personController.enabled;
        playerCharacter.enabled = !playerCharacter.enabled;
    }

    public void OpenEndScene()
    {
        PauseGame();
        endScene.SetActive(true);
    }
}
