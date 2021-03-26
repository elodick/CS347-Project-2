using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AmmoUI : MonoBehaviour
{
    GameObject Player;

    [SerializeField]
    int Ammo;

    [SerializeField]
    GameObject txt; 
    // Start is called before the first frame update
    void Start()
    {
        //Set Player to the "Player" game object
        Player = gameObject.transform.parent.parent.gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Ammo is constantly update and the text is changed
        Ammo = Player.GetComponent<PlayerMovement>().Ammo;
        txt.GetComponent<UnityEngine.UI.Text>().text = Ammo.ToString();
    
    }
}
