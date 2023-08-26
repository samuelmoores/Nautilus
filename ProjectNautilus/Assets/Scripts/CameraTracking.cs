using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y;
        transform.position = pos;
    }
}
