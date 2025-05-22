using UnityEngine;

public class GerakanPlayer : MonoBehaviour
{
    public float kecepatan;
    public float kekuatanLompat = 1000f;
    Rigidbody rb;
    Animator anim;
    public Transform playerPutaran;

    private bool sedangDiTanah = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
   
    void FixedUpdate()
    {
        Bergerak();   
    }

    void Update()
    {
        // Lompat();
    }

    void Bergerak()
    {
        float gerak = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(gerak * kecepatan, rb.velocity.y, 0);
        anim.SetFloat("Kecepatan", Mathf.Abs(gerak));
        if (gerak != 0)
            playerPutaran.localEulerAngles = new Vector3(0, gerak > 0 ? 90 : -90, 0);
    }

    // void Lompat()
    // {
    //   if (Input.GetKeyDown(KeyCode.Space) && sedangDiTanah)
    //     {
    //         Debug.Log("Lompat!");
    //         rb.AddForce(Vector3.up * kekuatanLompat, ForceMode.Impulse);
    //         sedangDiTanah = false;
    //     }


    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("virus"))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        // Deteksi saat menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            sedangDiTanah = true;
        }
    }
}
