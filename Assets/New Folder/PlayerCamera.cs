using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Player player;
    private Vector3 offset;

    void Start()
    {
        //Ищем игрока
        player = FindObjectOfType<Player>();
        offset = transform.position - player.transform.position;
    }




    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
