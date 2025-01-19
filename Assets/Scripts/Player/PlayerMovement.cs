using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // editable from unity
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
     private float verticalInput;
     private Rigidbody2D rb2d;
      private int keynum = 0;
    private bool keys = false;
    public Door pl;
    public Text txt;
    
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    private void Awake() // is called every time the script is loaded
    {
        anim = GetComponent<Animator>(); // vriskei to animator apo to object
        body = GetComponent<Rigidbody2D>(); // gets reference,, paei sto unity kai vriskei to rigidbody2D
        boxCollider = GetComponent<BoxCollider2D>(); // vriskei to boxcollider
        rb2d = GetComponent<Rigidbody2D> ();
    }

    private void Update() // runs on every frame of the game
    {
        if (pl.nero== false){
        horizontalInput = Input.GetAxis("Horizontal"); // metavliti gia times ston axona x apo to keyboard
        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, 0);

        if(horizontalInput > 0.01f) // an exei thetiki kinisi ston x
            transform.localScale = new Vector3(1, 1, 1); // na vlepei dexia o character
        else if(horizontalInput < -0.01f) // an exei arnitiki kinisi ston x
            transform.localScale = new Vector3(-1, 1, 1); // na vlepei aristera o character
            anim.SetBool("Run", horizontalInput != 0); // set animator parameters
            anim.SetBool("Grounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.Space))
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower); // jump (x stays to idio, to y allazei)
                    anim.SetTrigger("Jump");
            }
                
        }

        if(pl.nero == true){
            horizontalInput = Input.GetAxis("Horizontal"); // metavliti gia times ston axona x apo to keyboard
            verticalInput = Input.GetAxis("Vertical");
            GetComponent<BoxCollider2D>().size = new Vector2(2.6f, 0.9f);
            rb2d.gravityScale = 0.05f;
        transform.Translate(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
        if(horizontalInput > 0.01f) // an exei thetiki kinisi ston x
            transform.localScale = new Vector3(1, 1, 1); // na vlepei dexia o character
        else if(horizontalInput < -0.01f) // an exei arnitiki kinisi ston x
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Swim" , true);
                }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void AddKey()
    {
        keynum ++;
        txt.text = "Collect 4 keys ("+keynum.ToString()+"/4)";
        Debug.Log(keynum);
        if (keynum == 4 )
            keys = true;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "DoorToBase" && keys == true)
        {
           SceneManager.LoadScene("Cutscene2");
        }
    }
}
