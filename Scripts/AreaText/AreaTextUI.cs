using UnityEngine;

public class AreaTextUI : MonoBehaviour
{
    public Animator Animator;
    public TMPro.TextMeshProUGUI NameText;

    private void Start() {
        Animator = GetComponent<Animator>();
    }
}