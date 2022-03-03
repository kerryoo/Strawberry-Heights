using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] GameObject highlight;

    public void onHighlight()
    {
        highlight.SetActive(true);
    }

    public void onStopHighlight()
    {
        highlight.SetActive(false);
    }

    public void onPlace()
    {
        highlight.SetActive(false);
    }

    public void onRemove()
    {
        highlight.SetActive(false);
    }
}
