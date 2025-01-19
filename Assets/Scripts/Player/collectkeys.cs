using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectkeys : MonoBehaviour
{

  [SerializeField]private AudioClip CollectKeys;

    private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
        SoundManager.instance.PlaySound(CollectKeys);
        collision.GetComponent<PlayerMovement>().AddKey();
        gameObject.SetActive(false);
    }
  }
}
