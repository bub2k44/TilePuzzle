//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.Networking;

//public class HighScoreInserter : SingletonComponent<HighScoreInserter>
//{
//    public HighScoresUploadedEvent OnHighScoreUploaded = new HighScoresUploadedEvent();
//    [Serializable]
//    public class HighScoresUploadedEvent : UnityEvent { }

//    IEnumerator PostHighScore(string init, int score)
//    {
//        WWWForm form = new WWWForm();
//        form.AddField("Init", init);
//        form.AddField("Score", score);
//        form.AddField("Secret", DatabaseHelper.SECRET_KEY);
//        string url = DatabaseHelper.BASE_URL + "/propelnspell/docs/scripts/InsertHighScore.php?Init=" + init.ToUpper() + "&Score=" + score.ToString() + "&Secret=" + DatabaseHelper.SECRET_KEY;
//        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
//        {
//            yield return www.SendWebRequest();

//            if (www.isNetworkError)// || www.isHttpError)
//            {
//                Debug.Log(www.error);
//            }
//            else
//            {
//                Debug.Log(www.downloadHandler.text);

//                OnHighScoreUploaded?.Invoke();
//            }
//        }
//    }

//    public void UploadHighScore(string init, int score)
//    {
//        StartCoroutine(PostHighScore(init, score));
//    }
//}