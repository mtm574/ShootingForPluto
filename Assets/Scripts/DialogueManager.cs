using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{

    [Header("Cutscene Settings")]
    public string sceneToLoadAfterCutscene; 

    [Header("UI")]
    public TextMeshProUGUI dialogueText;      

    [Header("Characters")]
    public GameObject playerSprite;           
    public GameObject npcSprite;             

    [Header("Dialogue Lines")]
    public string[] dialogueLines;             
    public GameObject[] speakersPerLine;       

    [Header("Settings")]
    public float typingSpeed = 0.05f;          

    private int currentLine = 0;               
    private Coroutine typingCoroutine;         

    void Start()
    {
        playerSprite.SetActive(false);
        npcSprite.SetActive(false);

        ShowLine();
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                NextLine();
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextLine();
            }
        }
    }

    void ShowLine()
    {
        if (speakersPerLine.Length > currentLine && speakersPerLine[currentLine] != null)
        {
            speakersPerLine[currentLine].SetActive(true);
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(dialogueLines[currentLine]));
    }

    IEnumerator TypeText(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void NextLine()
    {
        if (typingCoroutine != null && dialogueText.text != dialogueLines[currentLine])
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogueLines[currentLine];
            return;
        }

        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueText.transform.parent.gameObject.SetActive(false);

        Debug.Log("Dialogue finished. Start gameplay here.");


        if (!string.IsNullOrEmpty(sceneToLoadAfterCutscene))
        {
            Debug.Log("Dialogue finished. Loading scene: " + sceneToLoadAfterCutscene);
            SceneManager.LoadScene(sceneToLoadAfterCutscene);
        }
        else
        {
            Debug.Log("Dialogue finished. No scene change.");
        }

    }
}