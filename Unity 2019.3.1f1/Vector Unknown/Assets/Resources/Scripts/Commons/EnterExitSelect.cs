﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum SceneNameMod
{
    MainSceneName,
    Puzzle01SceneName,
    Puzzle02SceneName,
    Puzzle03SceneName,
    Puzzle04SceneName,
    CreditSceneName,
    MenuScene
}

public enum PuzzleCompleteMod
{
    NullPuzzle,
    Puzzle01Complete,
    Puzzle02Complete,
    Puzzle03Complete,
    Puzzle04Complete
}

public class EnterExitSelect : WindowRoot
{
    public SceneNameMod sceneName;
    public PuzzleCompleteMod puzzleComplete;

    public GameObject levelSelectUI;


    private string stageTitle;
    private string stageDescip;

    private PlayerController playerController;



    private void OnTriggerEnter(Collider other)
    {
        if(playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        if(other.tag == "Player")
        {
            playerController.isEnterExit = true;

            SetActive(levelSelectUI, true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            levelSelectUI.GetComponent<LevelSelectButtons>().setLevel(0);
            levelSelectUI.GetComponent<LevelSelectButtons>().setSceneName(sceneName);
            levelSelectUI.GetComponent<LevelSelectButtons>().setPuzzleCompleteName(puzzleComplete);
            

            //GameRoot.ShowTips("Press \"E\" to enter", true, false);

            switch (sceneName)
            {
                case SceneNameMod.MenuScene:
                    playerController.sceneName = Constants.menuSceneName;
                    break;

                case SceneNameMod.MainSceneName:
                    playerController.sceneName = Constants.mainSceneName;

                    if (SceneManager.GetActiveScene().name == Constants.puzzle01SceneName)
                        GameRoot.instance.exitPuzzle = 1;
                    else if (SceneManager.GetActiveScene().name == Constants.puzzle02SceneName)
                        GameRoot.instance.exitPuzzle = 2;
                    else if (SceneManager.GetActiveScene().name == Constants.puzzle03SceneName)
                        GameRoot.instance.exitPuzzle = 3;

                    break;

                case SceneNameMod.Puzzle01SceneName:
                    stageTitle = "STAGE 01";
                    stageDescip = "Vector Displacement";
                    levelSelectUI.GetComponent<LevelSelectButtons>().setHeaderInfo(stageTitle, stageDescip);

                    playerController.sceneName = Constants.puzzle01SceneName;
                    break;

                case SceneNameMod.Puzzle02SceneName:
                    stageTitle = "STAGE 02";
                    stageDescip = "Matrix Multiplication";
                    levelSelectUI.GetComponent<LevelSelectButtons>().setHeaderInfo(stageTitle, stageDescip);

                    playerController.sceneName = Constants.puzzle02SceneName;
                    break;

                case SceneNameMod.Puzzle03SceneName:
                    stageTitle = "STAGE 03";
                    stageDescip = "Vector Spans";
                    levelSelectUI.GetComponent<LevelSelectButtons>().setHeaderInfo(stageTitle, stageDescip);

                    playerController.sceneName = Constants.puzzle03SceneName;
                    break;

                case SceneNameMod.Puzzle04SceneName:
                    stageTitle = "STAGE 04";
                    stageDescip = "Scalar Vectors Displacment";
                    levelSelectUI.GetComponent<LevelSelectButtons>().setHeaderInfo(stageTitle,stageDescip);

                    playerController.sceneName = Constants.puzzle04SceneName;
                    break;

                case SceneNameMod.CreditSceneName:
                    playerController.sceneName = Constants.creditSceneName;
                    break;
            }

            switch(puzzleComplete)
            {
                case PuzzleCompleteMod.Puzzle01Complete:
                    GameRoot.instance.puzzleCompleted[0] = true;
                    break;

                case PuzzleCompleteMod.Puzzle02Complete:
                    GameRoot.instance.puzzleCompleted[1] = true;
                    break;

                case PuzzleCompleteMod.Puzzle03Complete:
                    GameRoot.instance.puzzleCompleted[2] = true;
                    break;

                case PuzzleCompleteMod.Puzzle04Complete:
                    GameRoot.instance.puzzleCompleted[3] = true;
                    break;


                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController.isEnterExit = false;

            levelSelectUI.GetComponent<LevelSelectButtons>().setLevel(0);

            SetActive(levelSelectUI, false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            GameRoot.ShowTips("", false, false);
        }
    }
}