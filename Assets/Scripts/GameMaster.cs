using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public List<GameObject> Structures;
    public GameObject Detectplane;
    public Slider sld;
    public Text scrtext;
    public int Score;
    public float round;

    public void GameStart()
    {
        int gamemode = Random.Range(0, 4);
        int Strucnum = Random.Range(0, 4);

        switch (gamemode)
        {
            case 1:
                Detectplane.GetComponent<Obj1>().enabled = true;
                Detectplane.GetComponent<Obj1>().Strct = Structures[Strucnum];
                break;
            case 2:
                Detectplane.GetComponent<Obj2>().enabled = true;
                Detectplane.GetComponent<Obj2>().Strct = Structures[Strucnum];
                break;
            case 3:
                Detectplane.GetComponent<Obj3>().enabled = true;
                Detectplane.GetComponent<Obj3>().Strct = Structures[Strucnum];
                break;
        }
        round = sld.value;
    }

    public void GameWin()
    {
        Score += 1;
        Debug.Log("youwin");
    }
    public void GameLose()
    {
        Score -= 1;
        Debug.Log("youlose");
        
    }
    public void Gamefinish()
    {}
    public void ReturnStructure(GameObject Structure)
    {
        foreach (Transform child in Structure.transform)
        {
            child.GetComponent<Brick>().RePosition();
            if (!child.GetComponent<MeshRenderer>().enabled)
                child.GetComponent<MeshRenderer>().enabled = true;
            if (!child.GetComponent<Collider>().enabled)
                child.GetComponent<Collider>().enabled = true;
        }
        switch (Structure.name)
        {
            case "Structure1":
                Structure.transform.position = new Vector3(12, -15, 12);
                break;
            case "Structure2":
                Structure.transform.position = new Vector3(12, -15, -12);
                break;
            case "Structure3":
                Structure.transform.position = new Vector3(-12, -15, 12);
                break;
            case "Structure4":
                Structure.transform.position = new Vector3(-12, -15, -12);
                break;
        }
    }
}
