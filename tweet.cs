using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using SocialConnector;

public class tweet : MonoBehaviour {

    public void Share()
    {
        StartCoroutine(ShareScreenShot());
    }

    IEnumerator ShareScreenShot()
    {
        //スクリーンショット画像の保存先を設定。ファイル名が重複しないように実行時間を付与
        string fileName = String.Format("image_{0:yyyyMMdd_Hmmss}.png", DateTime.Now);
        string imagePath = Application.persistentDataPath + "/" + fileName;

        //スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot(fileName);
        yield return new WaitForEndOfFrame();

        // Shareするメッセージを設定
        string text = "試し\n#志希 ";
        string URL = "url";
        yield return new WaitForSeconds(1);

        //Shareする
        SocialConnector.SocialConnector.Share(text, URL, imagePath);
    }
}

