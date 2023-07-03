using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogGUI;
    public TextMeshProUGUI textDisplay;
    private int index;
    public float typingSpeed = 0.05f;
    public string name;
    public Color color;

    private bool isWriting = false;
    private bool isInteracting = false;

    [TextArea(3, 10)]
    public string[] sentences;

    private void Start()
    {
        //textDisplay.color = color;
        index = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInteracting)
        {
            if (isWriting)
            {
                print("Complete sentence");
                StopAllCoroutines();
                textDisplay.text = string.Empty;
                textDisplay.text += name + ": " + sentences[index];
                isWriting = false;
                index++;
            }
            else
            {
                print("Next sentence");
                isWriting = true;
                dialogGUI.SetActive(true);
                NextSentence();
            }
        }
    }

    public void StartConversation()
    {
        isInteracting = true;
    }

    private void NextSentence()
    {
        if (index < sentences.Length)
        {
            textDisplay.text = string.Empty;
            StartCoroutine(Type(sentences[index]));
        }
        else
        {
            index = 0;
            isWriting = false;
            StopAllCoroutines();
            dialogGUI.SetActive(false);
        }
    }


    IEnumerator Type(string sentence)
    {
        textDisplay.text += name + ": ";
        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isWriting = false;
        index++;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartConversation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = false;
            isWriting = false;
            index = 0;
            StopAllCoroutines();
            dialogGUI.SetActive(false);
        }
    }

}
