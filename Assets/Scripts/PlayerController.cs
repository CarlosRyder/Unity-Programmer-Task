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
    public GameObject playerWithBow;
    public GameObject playerWithScythe;
    private GameObject activePlayer; // Referencia al GameObject activo actualmente


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject[] playerObjects = { playerWithoutWeapons, playerWithHammer, playerWithBow, playerWithScythe };

        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.activeSelf)
            {
                SetActivePlayer(playerObject);
                break; // Una vez que se encuentre el jugador activo, salimos del bucle
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

    // Método para establecer el jugador activo
    private void SetActivePlayer(GameObject player)
    {
        if (activePlayer != null)
        {
            activePlayer.SetActive(false); // Desactivar el jugador anteriormente activo
        }
        activePlayer = player;
        activePlayer.SetActive(true); // Activar el nuevo jugador
        animator = activePlayer.GetComponent<Animator>(); // Obtener el Animator del nuevo jugador
    }

    // Métodos para cambiar el jugador activo mediante botones
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
        SetActivePlayer(playerWithBow);
    }

    public void SetPlayerWithScytheActive()
    {
        SetActivePlayer(playerWithScythe);
    }
}
