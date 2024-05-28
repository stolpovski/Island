using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoatAttack;

public class Game : MonoBehaviour
{
    public Character player;
    public HumanController boat;
    public Paraglider paraglider;

    bool boarded;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(player.transform.position, boat.transform.position));
    }



    void OnQuit()
    {
        Application.Quit();
    }

    void OnRestart()
    {
        Application.LoadLevel(0);
    }

    void OnBoard()
    {
        if (Vector3.Distance(player.transform.position, boat.transform.position) < 5)
        {
            if (!boarded)
            {
                player.cam.gameObject.SetActive(false);
                player.gameObject.SetActive(false);

                boat.enabled = true;

                player.transform.SetParent(boat.transform);
                player.transform.localPosition = new Vector3(0, 1, 0);
                player.transform.localRotation = Quaternion.identity;
                boarded = true;
            }
            else
            {
                player.cam.gameObject.SetActive(true);
                player.gameObject.SetActive(true);

                boat.enabled = false;

                player.transform.SetParent(null);
                boarded = false;
            }
        }

        if (Vector3.Distance(player.transform.position, paraglider.transform.position) < 2)
        {
            if (!paraglider.boarded)
            {
                player.cam.gameObject.SetActive(false);
                player.gameObject.SetActive(false);

                paraglider.enabled = true;
                paraglider.cam.SetActive(true);

                player.transform.SetParent(paraglider.transform);
                player.transform.localRotation = Quaternion.identity;
                //player.transform.localPosition = new Vector3(0, 1, 0);
                paraglider.boarded = true;
            }
            else
            {
                player.cam.gameObject.SetActive(true);
                player.gameObject.SetActive(true);

                //paraglider.enabled = false;
                paraglider.cam.SetActive(false);

                player.transform.SetParent(null);
                player.transform.position = new Vector3(paraglider.transform.position.x, paraglider.transform.position.y + 2, paraglider.transform.position.z);
                paraglider.boarded = false;
            }
        }


        
        
    }


}
