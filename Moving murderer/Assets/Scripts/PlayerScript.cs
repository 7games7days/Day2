using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public GameObject aim;
    public LineRenderer line;
    public float coolDown;
    public float baseCD;
	public GameOver GC;
	public TextMeshProUGUI text;
	int bullets;
    // Use this for initialization
    void Start()
    {
        bullets = 8;
		text = GameObject.FindGameObjectWithTag("text").GetComponent<TextMeshProUGUI>();
		baseCD = 1.5f;
        coolDown = 0.5f;
		GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOver>();
        aim = GameObject.FindGameObjectWithTag("Aim");
        line = gameObject.GetComponent<LineRenderer>();
    }
    void Update()
    {
        text.text = "Bullets: "+bullets;
		Vector3 dir = aim.transform.position - transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            bullets--;
			RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)dir);
            if (hit.collider.CompareTag("Walls"))
            {
                transform.position = hit.point + hit.normal.normalized;
                coolDown = baseCD;
            }
			if(hit.collider.CompareTag("Enemy")){
				transform.position = hit.collider.transform.position;
				coolDown = baseCD;
				GameObject.Destroy(hit.collider.gameObject);
			}
			if(hit.collider.CompareTag("HighValue")){
				GameObject.Destroy(hit.collider.gameObject);
				GC.GameOverWin();
			}
        }




    }
    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3[] points = new Vector3[2];
        if (coolDown <= 0)
        {
            Vector3 dir = aim.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)dir);
            
            if (hit.collider != null)
            {
                points[0] = (Vector2)transform.position;
                points[1] = (Vector2)hit.point;
                line.SetPositions(points);
            }
        }else{
			points[0]=Vector2.zero;
			points[1]=Vector2.zero;
			coolDown-= 1*Time.fixedDeltaTime;
			line.SetPositions(points);
		}
		if(bullets <=0){
			GC.GameOverLose();
		}
		foreach(GameObject element in EnemyControl.enemies){
			if(Vector2.Distance(transform.position,element.transform.position)<3){
				GC.GameOverLose();
			}
		}
    }
}
