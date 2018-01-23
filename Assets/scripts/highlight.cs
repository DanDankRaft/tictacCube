using UnityEngine;
using System.Collections;

public class highlight : MonoBehaviour
{
    void HighlightLine(Slot a, Slot b, Slot c)
    {
        GameObject aObject = a.gameObject;
        GameObject bObject = b.gameObject;
        GameObject cObject = c.gameObject;

        foreach(Slot s in FindObjectOfType<PlayerManager>().slots)
        {
            if(s.gameObject != a.gameObject && s.gameObject != b.gameObject && s.gameObject != c.gameObject)
                s.gameObject.SetActive(false);
        }


    }
}
