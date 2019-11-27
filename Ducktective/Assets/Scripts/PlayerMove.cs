using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    public Animator animate;
    private Rigidbody2D rb;
    public static GameObject canvas;
    public static GameObject textarea;
    [SerializeField]
    private Flowchart fc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        direction = Vector2.zero;
        if(canvas == null){
            canvas = GameObject.FindGameObjectsWithTag("Inventory")[0];
        }
        if(textarea == null){
            textarea = GameObject.FindGameObjectsWithTag("TextArea")[0];
        }
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if(!fc.GetBooleanVariable("Var"))
        {
            InputCharacter();
            if (direction.x != 0 || direction.y != 0) 
            {
                AnimateChar(direction);
            } else
            {
                animate.SetLayerWeight(1, 0);
            }
        }
        else
        {
            animate.SetFloat("x", direction.x);
            animate.SetFloat("y", direction.y);
            animate.SetLayerWeight(1, 0);
        }   
    }

    private void FixedUpdate() 
    {
        if(!fc.GetBooleanVariable("Var"))
        {
            rb.MovePosition(rb.position+(direction * speed * Time.deltaTime));
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
