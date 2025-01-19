using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool nero {get; private set;}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           nero = true;
        }
    }

}
