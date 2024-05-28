using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField]
    private float moveSpeed;
    private Animator animator;
    private int idSpeedX;
    private int idSpeedY;
    private int idHorizontal;
    private int idVertical;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
        idSpeedX = Animator.StringToHash("speedX");
        idSpeedY = Animator.StringToHash("speedY");
        idHorizontal = Animator.StringToHash("horizontal");
        idVertical = Animator.StringToHash("vertical");

    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float inputY = Input.GetAxisRaw("Vertical") * moveSpeed;
        playerRB.velocity = new Vector2(inputX, inputY);
        animator.SetFloat(idSpeedX, Mathf.Abs(inputX));
        animator.SetFloat(idSpeedY, Mathf.Abs(inputY));
        animator.SetFloat(idHorizontal, inputX);
        animator.SetFloat(idVertical, inputY);

        if (inputX > 0) 
        {
           transform.localScale=new Vector3(-0.5f, 0.5f, 0.5f);
        }

        else if(inputX < 0) 
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

    }

}
