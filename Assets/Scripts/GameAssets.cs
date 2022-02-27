using UnityEngine;


public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            // this opens the "GameAssets" file from the Resources folder the get this class as component then will have access
            // to the vars in this class 
            // the video i followed (https://www.youtube.com/watch?v=7GcEW6uwO8E)
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }

            return _i;
        }
    }


    public GameObject wire;
    public GameObject notGate;
    public GameObject andGate;
    public GameObject orGate;
}

