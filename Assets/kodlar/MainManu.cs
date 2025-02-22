using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void PlayGame()//Bu fonksiyon, "Oyunu Başlat" butonuna tıklandığında çağrılır. 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        //SceneManager.LoadScene() = belirtilen sahneyi yükler. 
        //SceneManager.GetActiveScene().buildIndex ifadesi, aktif sahnenin index numarasını verir. 
          //Bu index numarasına 1 eklenerek bir sonraki sahne yüklenir. 
          //Yani, oyun sahnesinden bir sonraki sahneye geçiş yapılır.
    }
    
    public void QuitGame()// "Oyundan Çık" butonuna tıklandığında çağrılır. 
    {
        Debug.Log("Oyundan çıktık");
        Application.Quit();
        //Application.Quit() = uygulamayı kapatır
    }
    public void ReturnToMainManu()//, "Ana Menüye Dön" butonuna tıklandığında çağrılır. 
    {
        SceneManager.LoadScene("MainMenu");
        //SceneManager.LoadScene() = belirtilen sahneyi yükler.
    }
   
}
