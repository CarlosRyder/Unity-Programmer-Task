using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private float moveSpeed;
    private Animator animator;
    private int idSpeedX;
    private int idSpeedY;
    private int idHorizontal;
    private int idVertical;
    public GameObject playerWithoutWeapons;
    public GameObject playerWithHammer;
    public GameObject playerWithSword;
    public GameObject playerWithScythe;
    private GameObject activePlayer;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject[] playerObjects = { playerWithoutWeapons, playerWithHammer, playerWithSword, playerWithScythe };

        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.activeSelf)
            {
                SetActivePlayer(playerObject);
                break;
            }
        }

        idSpeedX = Animator.StringToHash("speedX");
        idSpeedY = Animator.StringToHash("speedY");
        idHorizontal = Animator.StringToHash("horizontal");
        idVertical = Animator.StringToHash("vertical");
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (activePlayer != null)
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
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
            else if (inputX < 0)
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
        }
    }


    private void SetActivePlayer(GameObject player)
    {
        if (activePlayer != null)
        {
            activePlayer.SetActive(false);
        }
        activePlayer = player;
        activePlayer.SetActive(true);
        animator = activePlayer.GetComponent<Animator>();
    }

    public void SetPlayerWithoutWeaponsActive()
    {
        SetActivePlayer(playerWithoutWeapons);
    }

    public void SetPlayerWithHammerActive()
    {
        SetActivePlayer(playerWithHammer);
    }

    public void SetPlayerWithBowActive()
    {
        SetActivePlayer(playerWithSword);
    }

    public void SetPlayerWithScytheActive()
    {
        SetActivePlayer(playerWithScythe);
    }
}
