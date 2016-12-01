using UnityEngine;
using System.Collections;

public class LukeMenuTest : MonoBehaviour {

    public string destination;
	// Use this for initialization
	void Start ()
    {



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene ()
    {
        Application.LoadLevel(destination);
    }
}
