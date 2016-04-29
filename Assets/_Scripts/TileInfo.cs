using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour
{

    private bool active = false;

    public void SwitchColor()
    {

        if (active == true)
        {
            this.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 10f / 256f);
        }
        else
        {
            this.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 100f / 256f);
        }

        active = !active;

    }

}
