using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float speed;
    private Vector2 direction;
    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        InputCharacter();
        transform.Translate(direction * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0) 
        {
            AnimateChar(direction);
        } else
        {
            animate.SetLayerWeight(1, 0);
        }
    }

    void InputCharacter()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
    }

    void AnimateChar(Vector2 dir)
    {
        animate.SetLayerWeight(1,1);

        animate.SetFloat("x", dir.x);
        animate.SetFloat("y", dir.y);
    }
}
