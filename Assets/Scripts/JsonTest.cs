using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    [System.Serializable]
    public class Testwektora
    {
        public Vector2 wektor;


        public Testwektora(Vector2 w)
        {
            this.wektor = w;
        }
    }


    //string json = JsonConvert.SerializeObject(new Testwektora(new Vector2(2, 4)));

    public string SaveToString(string st)
    {
        return JsonUtility.ToJson(st);
    }

     void Start()
    {
        Testwektora w1 = new Testwektora(new Vector2(2, 4));

        string str = JsonUtility.ToJson(w1);
        Debug.Log("Test: "+str);
        
    }

}
