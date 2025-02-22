using UnityEngine;

public class Kamera : MonoBehaviour
{

    public GameObject targetObject;//kameranın takip edeceği hedef nesne
    public Vector3 cameraOffset;//kameranın hedef nesneye göre konumunu ayarlamak için kullanılacak ofset değeri
    public Vector3 targetedPosition;//kameranın hareket edeceği hedef pozisyon
    public Vector3 velocity=Vector3.zero;
    public float smoothTime = 0.3f;//kameranın hedefe ulaşmaya çalışırken geçireceği süre
    // Update is called once per frame
    void LateUpdate()
    {
        targetedPosition=targetObject.transform.position + cameraOffset;
        // kameranın takip edeceği hedef pozisyonunu belirler.
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
        //Vector3.SmoothDamp = kameranın yumuşak bir şekilde hedef pozisyonuna doğru hareket etmesini sağlar
        
    }
    
}
