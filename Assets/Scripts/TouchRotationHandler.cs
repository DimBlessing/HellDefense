using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchRotationHandler : MonoBehaviour, IDragHandler
{
    public PlayerController playerRotationScript;

#if UNITY_IOS || PLATFORM_IOS
    public void OnDrag(PointerEventData eventData)
    {
        //플레이어 캐릭터 회전
        float rotationInputX = eventData.delta.x;
        float rotationInputY = eventData.delta.y;
        playerRotationScript.RotatePlayer(rotationInputX, rotationInputY);

        //플레이어 카메라 회전
        if(rotationInputY != 0f){
            playerRotationScript.RotateCamera(rotationInputX, rotationInputY);
        }

    }
#endif

}
