using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public string[] names;
    public string[] lines;
    public float textSpeed = 0.05f;


    private int index;
    private bool dialogueStarted = false;

    void Start()
    {
        textComponent.text = string.Empty;
        nameComponent.text = string.Empty;
        dialogueCanvas.enabled = false;
    }

    void Update()
    {

        if (dialogueStarted && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        dialogueStarted = true;
        dialogueCanvas.enabled = true;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        if (index <= names.Length - 1)
            nameComponent.text = names[index];
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //gameObject.SetActive(false);
            EndDialogue();
            //Debug.Log("Diyalog Bitti");
        }
    }
    void EndDialogue()
    {
        dialogueCanvas.enabled = false;
        dialogueStarted = false;
        Debug.Log("Diyalog Bitti");
        SceneManager.LoadScene(1);
    }
}
