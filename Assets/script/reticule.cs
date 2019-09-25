using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticule : MonoBehaviour
{
        private Vector3 m_direction;
        private Vector3 player_position;
        private Vector3 camera_position;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                player_position=Player.m_instance.transform.position;//自機のポジション
                camera_position=CameraController.m_instance.transform.position;
                var retipos = player_position-camera_position+player_position;
                transform.position = retipos;
        }
}
