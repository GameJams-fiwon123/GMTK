using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Piece : MonoBehaviour
{
    AudioSource audio;
    BoxCollider2D boxCol;
    public bool isCorrect = false;

    bool holding = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (holding){
            Move();
        }
    }

    private void Move()
    {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
       holding = true;
       boxCol.enabled = false;
    }

    void OnMouseUp() {
        holding = false;
        boxCol.enabled = true;
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter()
    {
        Debug.Log("Play Audio");
        audio.Play();
    }

    void OnMouseExit() {
        Debug.Log("Stop Audio");
        audio.Stop();
    }
}
