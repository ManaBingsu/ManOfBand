using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaGazeManager : MonoBehaviour {

    [SerializeField]
    SystemMain systemMain;

	public void resizeGaze()
    {
        transform.localScale = new Vector3(systemMain.Stamina / 100f, 1f, 1f);
    }
}
