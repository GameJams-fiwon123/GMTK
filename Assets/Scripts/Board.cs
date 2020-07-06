using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Board : MonoBehaviour
{
    AudioSource audio;
    SpriteRenderer sprRenderer;
    BoxCollider2D boxCol;
    int left = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        sprRenderer = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        SearchPieces();
    }

    private void SearchPieces()
    {
        Piece[] pieces = FindObjectsOfType<Piece>();
        foreach(Piece p in pieces){
            if (p.isCorrect)
                left++;
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Piece>().isCorrect){
            left--;
            Debug.Log("Acertou");
            audio.Play();
            Destroy(other.gameObject);

            if (left == 0){
                sprRenderer.enabled = true;
                boxCol.enabled = false;
                GameManager.instance.Won();
            }
        } else {
            // Nothing
        }
    }
}
