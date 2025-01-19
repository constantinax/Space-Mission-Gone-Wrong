using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float speed; // editable from unity
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
     private float verticalInput;
     private Rigidbody2D rb2d;

    private int toolnum = 0;
    public Text txt2;

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

       private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void AddTool()
    {
        toolnum ++;
        txt2.text = "Collect 3 tools ("+toolnum.ToString()+"/3)";
        Debug.Log(toolnum);
        if (toolnum == 3 )
            SceneManager.LoadScene("Cutscene3");
    }
}
