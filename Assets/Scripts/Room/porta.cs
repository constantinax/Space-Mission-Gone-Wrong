using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    public Door pr;

    void Update()
    {
        if(pr.nero == true)
            GetComponent<EdgeCollider2D>().enabled= true;
    }
}
