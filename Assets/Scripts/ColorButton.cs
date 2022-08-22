using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{

    public int Camino;
    public int Paso;

    public void Activate () {
        gameObject.SetActive(true);
    }

    public void Deactivate () {
        gameObject.SetActive(false);
    }

}
