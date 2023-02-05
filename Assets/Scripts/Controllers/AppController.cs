using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjection;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UniRx;

namespace Game
{
    public class AppController : MonoBehaviour
    {
        private ConnectionManager connectionManager;

        [SerializeField] private Logger logger;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private CompositeDisposable disp = new CompositeDisposable();

        private void Awake()
        {
            DI.Add(logger);

            connectionManager = new ConnectionManager();
            PhotonNetwork.AddCallbackTarget(connectionManager);
            connectionManager.InitConnection();
            DI.Add(connectionManager);

            InitButtons();

        }

        private void InitButtons()
        {
            connectionManager.isConnectedToMaster.Subscribe(MakePlayButtonAwailable).AddTo(disp);

            playButton.onClick.AsObservable().Subscribe(_ => Play()).AddTo(disp);
            quitButton.onClick.AsObservable().Subscribe(_ => Quit()).AddTo(disp);
        }

        private void MakePlayButtonAwailable(bool value)
        {
            playButton.interactable = value;
        }

        private void Play()
        {
            connectionManager.JoinOrCreateRoom();
            //connectionManager.isSecondPlayerConnected.Subscribe(val => logger.Log("2PLAYERS " + val)).AddTo(disp);

            SceneManager.LoadScene(1);
        }

        private void Quit()
        {
            Application.Quit();
        }

        public void ChangeScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}