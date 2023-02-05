using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjection;
using UniRx;
using Photon.Pun;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject WaitingScreen;
        //[SerializeField] private PlayerSpawner PlayerSpawner;

        private ConnectionManager connectionManager;

        private CompositeDisposable disp = new CompositeDisposable();

        private void Awake()
        {
            if(connectionManager == null)
            {
                connectionManager = DI.Get<ConnectionManager>();
            }

            DI.Add(this);

            connectionManager.isSecondPlayerConnected.Subscribe(PlayersConnected).AddTo(disp);
        }

        private void PlayersConnected(bool value)
        {
            if (value)
            {
                WaitingScreen.SetActive(false);

                Vector2 pos = new Vector2
                {
                    x = Random.Range(0, 5),
                    y = Random.Range(0, 5)
                };

                //PlayerSpawner.Spawn(PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }
    }
}