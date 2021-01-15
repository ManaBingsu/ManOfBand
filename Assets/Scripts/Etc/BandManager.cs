using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandManager : MonoBehaviour {

    [SerializeField]
    GameObject band;
    [SerializeField]
    GameObject player;
  
    public void resizeBand() // 고무고무 밴드
    {
        band.transform.localScale = new Vector3((player.transform.position.x - 0.25f)/(384f/32f), 1f, 1f);
    }
	
}
