using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
   public int score = 0;
   public Text scoreText;
   
   private float _secondSinceStart = 0;
   public Text _TimeDiplay;

   void Start()
   {
      scoreText.text = "égale " + score;
      _TimeDiplay.text = "Temps écoulé = " + _secondSinceStart;
   }

   void Update()
   {
      if (_secondSinceStart + 1 < Time.realtimeSinceStartup)
      {
         _secondSinceStart++;
         _TimeDiplay.text = "Temps écoulé = " + _secondSinceStart;
      }
   }

   public void ScoreChange()
   {
      score++;
      scoreText.text = "égale " + score;
   }
   
}
