using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // for Mouse and Keyboard
using Ink.Runtime; // for Story
using TMPro;
using UnityEngine.UI;
using System; // for TextMeshProUGUI

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject namePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextAsset currentTextAsset;
    [SerializeField] GameObject spriteTomoruTalking;
    [SerializeField] GameObject spriteTomoruSmile;
    [SerializeField] GameObject spriteTomoruNeutral;
    [SerializeField] GameObject spriteTomoruHappy;


    Story currentStory;
    public Button[] choiceButtons;

    void Start()
    {
        if (currentStory == null)
        {
            currentStory = new Story(currentTextAsset.text);
            dialoguePanel.SetActive(true);
        }

        AdvanceDialogue();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
    Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Spacebar pressed!");
            AdvanceDialogue();
        }
    }

    void AdvanceDialogue()
    {
        // Debug print the tags:
        Debug.Log($"Number of tags this dialogue: {currentStory.currentTags.Count}");
        foreach (string selectedTag in currentStory.currentTags)
        {
            Debug.Log($"Tag = {selectedTag}");
        }

        foreach (string selectedTag in currentStory.currentTags)
        {
            if (String.Compare("tomoru_neutral", selectedTag) == 0)
            {
                Debug.Log("NEUTRAL TOMORU SPOTTED!!!!");
                spriteTomoruTalking.SetActive(false);
                spriteTomoruSmile.SetActive(false);
                spriteTomoruNeutral.SetActive(true);
                spriteTomoruHappy.SetActive(false);

            }
            if (String.Compare("tomoru_happy", selectedTag) == 0)
            {
                Debug.Log("HAPPY TOMORU SPOTTED!!!!");
                spriteTomoruTalking.SetActive(false);
                spriteTomoruSmile.SetActive(false);
                spriteTomoruNeutral.SetActive(false);
                spriteTomoruHappy.SetActive(true);
            }
            if (String.Compare("tomoru_smile", selectedTag) == 0)
            {
                Debug.Log("HAPPY TOMORU SPOTTED!!!!");
                spriteTomoruTalking.SetActive(false);
                spriteTomoruSmile.SetActive(true);
                spriteTomoruNeutral.SetActive(false);
                spriteTomoruHappy.SetActive(false);
            }
            if (String.Compare("tomoru_talking", selectedTag) == 0)
            {
                Debug.Log("HAPPY TOMORU SPOTTED!!!!");
                spriteTomoruTalking.SetActive(true);
                spriteTomoruSmile.SetActive(false);
                spriteTomoruNeutral.SetActive(false);
                spriteTomoruHappy.SetActive(false);
            }
        }

        if (currentStory.canContinue)
        {
            foreach (Button selectedButton in choiceButtons)
            {
                selectedButton.gameObject.SetActive(false);
            }
            Debug.Log("Current story can continue!");
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            Debug.Log($"currentStory.currentChoices.Count = {currentStory.currentChoices.Count}");
            for (int i = 0; i < currentStory.currentChoices.Count; i++)
            {
                Button selectedButton = choiceButtons[i];
                Choice currentChoice = currentStory.currentChoices[i];

                selectedButton.gameObject.SetActive(true);
                selectedButton.GetComponentInChildren<TextMeshProUGUI>().text = currentChoice.text;

                Debug.Log($"i = {i}");
            }

            Debug.Log("Current story cannot continue!");
            // TODO: reached end of story so end game?
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
            nameText.SetText("");
            namePanel.SetActive(false);
        }

        foreach (string selectedTag in currentStory.currentTags)
        {
            if (String.Compare("tomoru", selectedTag) == 0)
            {
                Debug.Log("Tomoru is speaking.");
                nameText.SetText("Tomoru");
                namePanel.SetActive(true);
            }
        }

        foreach (string selectedTag in currentStory.currentTags)
        {
            if (String.Compare("player", selectedTag) == 0)
            {
                Debug.Log("Player is speaking.");
                nameText.SetText("");
                namePanel.SetActive(false);
            }
        }

    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialoguePanel.gameObject.SetActive(true);
            dialogueText.text = currentStory.Continue();
            ShowChoices();
        }
    }

    void ShowChoices()
    {
        List<Choice> choices = currentStory.currentChoices;
        int index = 0;
        foreach (Choice c in choices)
        {
            choiceButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = c.text;
            choiceButtons[index].gameObject.SetActive(true);
            index++;
        }
        for (int i = index; i < 4; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }

        dialoguePanel.SetActive(false);
        namePanel.SetActive(false);
        nameText.SetText("");
    }

    public void SetDecision(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
        dialoguePanel.SetActive(true);
        // GetComponentInChildren
        // CHOICE
    }
}
