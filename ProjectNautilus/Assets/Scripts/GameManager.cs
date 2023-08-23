using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public int numTanks;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
    }

    
}
