//using SimpleJSON;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.Networking;

//public class HighScoreLoader : SingletonComponent<HighScoreLoader>
//{
//    public HighScoresLoadedEvent OnHighScoresLoaded = new HighScoresLoadedEvent();
//    [Serializable]
//    public class HighScoresLoadedEvent : UnityEvent<List<HighScore>> { }

//    IEnumerator GetHighScores()
//    {
//        string url = DatabaseHelper.BASE_URL + "/propelnspell/docs/scripts/GrabHighScores.php";
//        using (UnityWebRequest www = UnityWebRequest.Get(url))
//        {
//            yield return www.SendWebRequest();

//            if (www.isNetworkError)// || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                Debug.Log(www.downloadHandler.text);
//                List<HighScore> scores = new List<HighScore>();
//                var node = JSON.Parse(www.downloadHandler.text);
//                for (int i = 0; i < node.Count; i++)
//                {
//                    HighScore chico = new HighScore();
//                    chico.Name = node[i]["Initials"].Value.ToUpper();
//                    chico.Score = node[i]["Score"].AsInt;
//                    scores.Add(chico);
//                }
//                OnHighScoresLoaded?.Invoke(scores);
//            }
//        }
//    }

//    public void RequestHighScores()
//    {
//        StartCoroutine(GetHighScores());
//    }
//}