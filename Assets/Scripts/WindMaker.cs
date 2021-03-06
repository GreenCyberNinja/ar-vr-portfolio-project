using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class WindMaker : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    InputAction trigPresd, trigHeld;
    public GameObject playerORGN;
    GameObject wind;
    Vector3 windPOS;
    Transform Handfan;
    LineRenderer CurLine;
    bool woosh;
    // Start is called before the first frame update
    void Start()
    {
        var actionmap = playerControls.FindActionMap("XRI RightHand");
        trigPresd = actionmap.FindAction("Activate");
        trigHeld = actionmap.FindAction("ActivateHeld");
        trigPresd.performed += MakeWindOBJ;
        trigPresd.canceled += MakeWindMV;
        Handfan = this.transform;
    }
    private void Update()
    {
        if (trigHeld.ReadValue<float>() > 0)
        {
            if (CurLine.positionCount < 50)
            {
                CurLine.positionCount += 1;
                CurLine.SetPosition(CurLine.positionCount - 1, Handfan.position);
            }
        }
    }
    /// createss gameObject to use
    void MakeWindOBJ(InputAction.CallbackContext context)
    {
        wind = new GameObject();
        CurLine = wind.AddComponent<LineRenderer>();
        CurLine.startWidth = .1f;
        CurLine.endWidth = .1f;
        CurLine.positionCount = 0;
    }
    /// launches wind object from player
    void MakeWindMV(InputAction.CallbackContext context)
    {
        windPOS = CurLine.GetPosition(CurLine.positionCount / 2);
        CurLine.useWorldSpace = false;
        wind.AddComponent<WindMove>();
        wind.GetComponent<WindMove>().windPos = windPOS;
        wind.GetComponent<WindMove>().playerORGN = playerORGN.transform.position;
        MeshCollider meshcol = wind.AddComponent<MeshCollider>();
        Mesh mesh = new Mesh();
        CurLine.BakeMesh(mesh, true);
        meshcol.sharedMesh = mesh;
        meshcol.convex = true;
        meshcol.isTrigger = true;
        wind.GetComponent<WindMove>().moveNow = true;
    }
}
