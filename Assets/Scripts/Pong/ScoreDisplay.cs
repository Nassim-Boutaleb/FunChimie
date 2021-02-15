using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.HitBoxTemplate.ScoreManager
{
    public class ScoreDisplay : MonoBehaviour
    {
        public Text scoreText;
        // Update is called once per frame
        void Update()
        {
            scoreText.text = ScoreManager.Instance.redScore + "    -    " + ScoreManager.Instance.blueScore;
        }
    }
}
