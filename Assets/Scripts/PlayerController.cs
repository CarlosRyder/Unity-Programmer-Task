using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        playerRB.velocity = new Vector2(inputX, playerRB.velocity.y);
        //float inputY = Input.GetAxis("Vertical") * moveSpeed;
        //playerRB.velocity = new Vector2(inputY, playerRB.velocity.x);
    }
}
