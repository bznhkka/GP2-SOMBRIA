using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class testStory : MonoBehaviour
{
    public TextAsset inkFile;
    public TextMeshProUGUI textBox;
    private Story story;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Story story = new Story(inkFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ContinueStory()
    {
        if(story.canContinue)
        {
            textBox.gameObject.SetActive(true);
            textBox.text = story.Continue();
        }
        else
        {
            FinishDialogue();
        }
    }
    private void FinishDialogue()
    {
        textBox.gameObject.SetActive(false);
    }
}
