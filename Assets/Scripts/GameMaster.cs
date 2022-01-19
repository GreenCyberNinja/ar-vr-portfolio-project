using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public List<GameObject> Structures;
    public GameObject Detectplane;
    public int Score;

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
    }

    public void GameWin()
    {
        Score += 1;
    }
    public void GameLose()
    {
        Score += 2;
        
    }
    public void Gamefinish()
    {}
    public void ReturnStructure(GameObject Structure)
    {
        foreach (Transform child in Structure.transform)
        {
            child.localPosition = child.GetComponent<Brick>().origin;
            child.GetComponent<Rigidbody>().isKinematic = true;
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
