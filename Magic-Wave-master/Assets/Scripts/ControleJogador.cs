using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Rigidbody fisica;
    RaycastHit hit;
    Vector3 movimento;





    //ector3 posicaoDoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    void Start()
    {
        fisica = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newRot = Quaternion.LookRotation(playerToMouse);
            fisica.MoveRotation(newRot);



        }

        movimento = new Vector3((Input.GetAxisRaw("Horizontal")), 0f, (Input.GetAxisRaw("Vertical")));
        movimento = movimento.normalized * speed * Time.deltaTime;
        fisica.MovePosition(transform.position + movimento);

    }
}
