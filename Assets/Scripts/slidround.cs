using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class slidround : MonoBehaviour
{
    public Text numround;
    public Slider slid;

    public void sliderVal()
    {
        numround.text = "" + slid.value;
    }
}
