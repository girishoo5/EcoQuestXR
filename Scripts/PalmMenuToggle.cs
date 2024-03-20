using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;


public class PalmMenuToggle : MonoBehaviour
{

        [SerializeField]
        private AudioSource _showMenuAudio;

        [SerializeField]
        private AudioSource _hideMenuAudio;

        [SerializeField]
        private GameObject _menuParent;

        public GameObject gamemangaer;

        void Start()
        {
            _menuParent.SetActive(false);
       // gamemangaer.GetComponent<Print>().settext("----menu active false");
        }

        void Update()
        {

        }

        public void ToggleMenu()
        {
            if (_menuParent.activeSelf)
            {
                _hideMenuAudio.Play();
                _menuParent.SetActive(false);
          //  gamemangaer.GetComponent<Print>().settext("----menu active false");
        }
            else
            {
                _showMenuAudio.Play();
                _menuParent.SetActive(true);
            //gamemangaer.GetComponent<Print>().settext("----menu active true");
        }
        }
}
