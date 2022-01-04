using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportManager : MonoBehaviour
{
    public GameObject baseControllerGO;
    public GameObject teleControllerGO;

    public InputActionReference teleportActivateRef;

    public UnityEvent onTeleActive;
    public UnityEvent onTeleCancel;

    private void Start()
    {
        teleportActivateRef.action.performed += TeleportmodeActivate;
        teleportActivateRef.action.canceled += TeleportmodeCancel;
    }
    private void TeleportmodeActivate(InputAction.CallbackContext context) => onTeleActive.Invoke();

    void DeactivateTeleport() => onTeleCancel.Invoke();

    private void TeleportmodeCancel(InputAction.CallbackContext context) => Invoke("DeactivateTeleport", .1f);
    
}
