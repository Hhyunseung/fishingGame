using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Trigger : MonoBehaviour
{
    public static bool TriggerBool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerBool = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerBool = false;
    }
}
