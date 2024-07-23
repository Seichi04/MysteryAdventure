using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTextManager : MonoBehaviour
{
    public AreaTextUI AreaTextUI;
    public string NameArea;
    public float TimeStart;
    public bool IsStart;
    

    private void Start() {
        IsStart = false;
    }



    private void Update() {
        if(Time.time - TimeStart > 3f && IsStart)
        {
            AreaTextUI.Animator.SetBool("IsAppear",false);
            IsStart = false;
        }
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AreaTextUI.NameText.text = NameArea;
            AreaTextUI.Animator.SetBool("IsAppear",true);
            TimeStart = Time.time;
            IsStart = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(AreaTextUI.Animator == null) return;
            AreaTextUI.Animator.SetBool("IsAppear",false);
            IsStart = false;
        }
    }
}
