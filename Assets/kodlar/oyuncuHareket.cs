using UnityEngine;
using TMPro;

public class oyuncuHareket : MonoBehaviour
{
    
    Rigidbody2D rgb; //rigidbody bileşeni
    Vector3 velocity; //hareket hızı vektörü
    public Animator animator; //animasyonları kontrol etmek için

    public int score;//oyuncu paraya değdiğinde puan artıcak onu tutuyor

    public Joystick joystick;
    public TextMeshProUGUI scoretext;
    

    float speedAmount = 5f;
    float jumpAmount = 9f;
    float horizontalMove;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>(); //karakterin rigidbody özelliğine erişmemizi sağlar
        score=0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text="Coins:"+score.ToString();

        if(joystick.Horizontal>0.2f)
        {
            horizontalMove=1;
        }
        else if(joystick.Horizontal<-0.2f)
        {
          horizontalMove=-1;
        }
        else
        {
            horizontalMove=0;
        }

        velocity = new Vector3(horizontalMove, 0f);//klavyeden alınan girişi velocity e aktarır
        transform.position += velocity * speedAmount * Time.deltaTime;
        //Time.deltaTime=her kare arasındaki zaman farkını temsil eder ve zaman tabanlı işlemlerin tutarlı kalmasını sağlar

        animator.SetFloat("hız", Mathf.Abs(joystick.Horizontal));
        //animatöre oyuncunun yatay hızını göndererek animasyonu günceller
        //Mathf.Abs= mutlak değer

        if (joystick.Vertical>0.5f && !animator.GetBool("isJumping")) //klavyeden yukarı yön tuşuna basıldığında ve
                                                                              // oyuncu zıplamıyorsa zıplama kuvveti uygulanır
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            //Vector3.up=nesnenin yukarı doğru hareket etmesini sağlayan vektör
            //ForceMode2D.Impulse=anlık olarak nesnenin yukarı zıplamasını sağlar
            animator.SetBool("isJumping", true);
        }

        if (horizontalMove==1)
        {           
            transform.rotation=Quaternion.Euler(0f,0f,0f); 
            //Quaternion.Euler=nesneyi belirli bir açıda döndürmek için kullanılır
           
        }
        else if (horizontalMove == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    //bir Rigidbody2D bileşenine bağlı olan bir oyuncu veya nesne, bir çarpışma algılandığında çağrılan bir fonksiyondur. 
    //Bu fonksiyon, oyuncu veya nesnenin çarpışma durumunu işlemek için kullanılır.
    //Parametre olarak Collision2D collision alır. Bu parametre, çarpışma hakkında bilgi içeren bir Collision2D nesnesini temsil eder. 
    //Bu nesne, çarpışan nesnelerin bilgisini (çarpışan nesnelerin Rigidbody2D bileşenlerini içeren) ve çarpışmanın ayrıntılarını içerir.
    {
        if (collision.gameObject.name=="Tilemap")
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            animator.SetBool("isJumping", true);
        }
    }
}
  