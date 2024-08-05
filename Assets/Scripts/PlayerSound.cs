using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Player player;
    private float footstepsTimer;
    private float footstepsTimerMax=0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepsTimer -= Time.deltaTime;
        if (footstepsTimer < 0)
        {
            footstepsTimer = footstepsTimerMax;
            if(player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);


            }

        }
    }


}
