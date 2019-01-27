using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    //Singleton
    public static DialogueSystem Instance { get; set; }

    [SerializeField]
    private GameObject dialogueUIElement; //So we know what to change

    private List<string> dialogueLines = new List<string>();
    private string dialogueName;


    Button continueButton;
    Text dialogueText;
    Text nameText;
    int dialogueIndex;

    [SerializeField]
    float displayTime;
    [SerializeField]
    float currentTime;


    void Awake () 
    {
        currentTime = 0;
        displayTime = 3;

		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        continueButton = dialogueUIElement.transform.Find("ContinueButton").GetComponent<Button>();
        if (continueButton == null)
        {
            Debug.Log("Could not find continueButton - called from DialogueSystem::Awake()");
        }

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );

        dialogueText = dialogueUIElement.transform.Find("DialogueText").GetComponent<Text>();
        if(dialogueText == null)
        {
            Debug.Log("Could not find dialogueText - called from DialogueSystem::Awake()");
        }

        nameText = dialogueUIElement.transform.Find("Name").GetChild(0).GetComponent<Text>();
        if(nameText == null)
        {
            Debug.Log("Could not find nameText - called from DialogueSystem::Awake()");

        }

        dialogueUIElement.SetActive(false); //Sets the UI to false when we start.
        dialogueIndex = 0;

    }

    public void Update()
    {
        if(dialogueUIElement.activeInHierarchy == true)
        {
            currentTime += Time.deltaTime;

            if(currentTime > displayTime)
            {
                ContinueDialogue();
            }
            
        }
    }

    public void AddNewDialogue(string[] lines, string personTalking)
    {
        dialogueIndex = 0;
        dialogueName = personTalking;

        //Is this creating memory leaks? Check if it is. 
        //dialogueLines = new List<string>(lines.Length); //Makes sure that the dialogue list is empty before adding the new lines

        dialogueLines.Clear();
        dialogueLines.AddRange(lines);

        Debug.Log("This dialogue has " + dialogueLines.Count + " lines.");
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = dialogueName;
        dialogueUIElement.SetActive(true);
        currentTime = 0;
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count - 1)
        {
            currentTime = 0;
            dialogueIndex = dialogueIndex +1;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialogueUIElement.SetActive(false);
            currentTime = 0;
        }
    }


}
