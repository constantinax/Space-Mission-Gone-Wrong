using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecttools : MonoBehaviour
{
  [SerializeField]private AudioClip CollectTool;

    private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      SoundManager.instance.PlaySound(CollectTool);
        collision.GetComponent<PlayerMovement1>().AddTool();
        gameObject.SetActive(false);
    }
  }
}
