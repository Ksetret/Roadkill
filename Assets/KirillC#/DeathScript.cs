using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    
    public void Death()
    {
        GetComponent<Animator>().enabled = false;
    }
}
