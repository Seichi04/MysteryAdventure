using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI NameText;
    public TMPro.TextMeshProUGUI DialogueText;

    public Animator Animator;

    public bool IsEndDialog;

    private Queue<string> dialogueSentences;

    private void Start() {
        dialogueSentences = new Queue<string>();
        IsEndDialog = false;
    }

    private void Update() {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Animator.SetBool("IsAppear",true);
        IsEndDialog = false;
        NameText.text = dialogue.name;
        dialogueSentences.Clear();
        foreach(string sentences in dialogue.text)
        {
            dialogueSentences.Enqueue(sentences);
        }

        DisplayNextDialogueSentence();
    }

    public void DisplayNextDialogueSentence()
    {
        if(dialogueSentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        AudioManager.Instance.PlayDialogueTextAudio(GetComponent<AudioSource>(),true);
        //Debug.Log("Start");
        string sentence = dialogueSentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeText(sentence));
    }

    private IEnumerator TypeText(string sentence)
    {
        DialogueText.text = "";
        for(int i=0;i< sentence.Length;i++)
        {
            DialogueText.text += sentence[i];
            if(i == sentence.Length -1)
            {
                //Debug.Log("Stop");
                AudioManager.Instance.StopAudio(GetComponent<AudioSource>());
            }
            //yield return null;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        Animator.SetBool("IsAppear",false);
        AudioManager.Instance.StopAudio(GetComponent<AudioSource>());
        IsEndDialog = true;
    }
}
