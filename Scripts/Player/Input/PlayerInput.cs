using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public GameKeymap InputActions { get; private set; }
    public GameKeymap.KeymapActions PlayerActions { get; private set; }
    private void Awake() {
        InputActions = new GameKeymap();
        PlayerActions = InputActions.Keymap;
    }

    public void OnEnable()
    {
        InputActions.Enable();
    }

    public void OnDisable() {
        InputActions.Disable();
    }

    public void DisableActionFor(InputAction action, float seconds)
    {
        StartCoroutine(DisableAction(action,seconds));
    }

    private IEnumerator DisableAction(InputAction action, float seconds)
    {
        action.Disable();
        yield return new WaitForSeconds(seconds);
        action.Enable();
    }
}