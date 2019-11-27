using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(CircleCollider2D))]
public class CharDialog : MonoBehaviour
{
    public float radius = 0.5f;
    public MyCharacter character;
    public CircleCollider2D collider;

    private void Start() {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = this.radius;
        collider.isTrigger = true;
        gameObject.tag = "Character";
    }
}
