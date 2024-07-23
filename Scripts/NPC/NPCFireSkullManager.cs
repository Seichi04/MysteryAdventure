using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFireSkullManager : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject InteracButton;
    public DialogueManager DialogueManager;

    private bool IsInteracted;

    private bool IsActive;

    private Vector2 PlayerPos;

    public GameObject FireSkull;

    private void Start() {
        IsInteracted = false;
        IsActive = false;
        InteracButton.SetActive(false);
        FireSkull.SetActive(false);
    }

    private void Update() {
        if(!IsActive)
        {
            if(IsInteracted && Input.GetKey(KeyCode.I))
            {
                DialogueManager.StartDialogue(dialogue);
                if(PlayerPos.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }

        if(DialogueManager.IsEndDialog)
        {
            FireSkull.SetActive(true);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IsInteracted = true;
            InteracButton.SetActive(true);
            PlayerPos = other.gameObject.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IsInteracted = false;
            InteracButton.SetActive(false);
        }
    }
}
