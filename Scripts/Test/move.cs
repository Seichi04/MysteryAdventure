using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private void Update() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(50,50);
    }
}
