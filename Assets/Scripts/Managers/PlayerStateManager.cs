using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour{
    public static PlayerStateManager Instance;

    public PlayerState State;
    
    public static event Action<PlayerState> OnGameStateChanged;


   private ThirdPersonController Player;

    void Awake(){
        Instance = this;
    }
    
    void Start(){
        Player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        UpdateState(PlayerState.FreeLook);
    }

    public void UpdateState(PlayerState newState){
        State = newState;

        switch (newState) {
            case PlayerState.UI:
                ChangeToUI();
                break;
                
            case PlayerState.FreeLook:
                ChangeToFL();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void ChangeToUI(){
        Player.can_move = false;
        Player.can_move_camera = false;
        ThirdPersonController.isVisibleCursor = true;
    }

    private void ChangeToFL(){
        Player.can_move = true;
        Player.can_move_camera = true;
        ThirdPersonController.isVisibleCursor = false;
    }
}

public enum PlayerState{
    UI,
    FreeLook,
}