using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform player;

    public bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        
        
        if (rotate) transform.rotation = Quaternion.Euler(transform.eulerAngles.x, player.eulerAngles.y, transform.eulerAngles.z);
    }
}
