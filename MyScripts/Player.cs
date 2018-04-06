using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {

	public float moveSpeed = 10.0f ;

	public int power = 1;

    public GameObject m_particle;

	public bool isAttack = false;
	public bool isSkill= false;

	public GameObject attack_particle_1;

	public GameObject attack_particle_2;

    public GameObject hit_particle;

	public float y = 0;

	public bool shift = false;

	public bool ctrl = false;

	public bool q_judge = false;

	public bool e_judge = false;


	public float rotSpeed =0;

	public float rot = 0;

	protected Transform m_transform;

	Transform m_camTransform;

	Vector3 m_camRot;

	float m_camHeight = 4.4f;

	float m_camDist = 4.4f;


	public Animator actor;

	AudioSource girlAudio;

   public AnimatorStateInfo stateInfo;


    public bool jump = false;

	
	public float hp=100;
	private float  initHp;
	public Image imgHpbar;

	public float mp=100;
	private float initMp;
	public Image imgMpbar;

	public float energy=0;
	private float initEnergy;
	public Image imgEnergybar;

	//private GameMgr gameMgr;

	

	
	// Use this for initialization
	void Start () {

        hit_particle.SetActive(false);

		attack_particle_1.SetActive (false);

		attack_particle_2.SetActive (false);

        m_particle.SetActive(false);

		m_transform = this.transform;

		m_camTransform = Camera.main.transform;
		Vector3 pos = m_transform.position;
		pos.y += m_camHeight;
		pos.z -= m_camDist;
		m_camTransform.position = pos;

		m_camTransform.rotation = m_transform.rotation;
		m_camRot = m_camTransform.eulerAngles;


		actor = this.GetComponent<Animator>();

		girlAudio = this.GetComponent<AudioSource>();
	
		initHp = hp;
		initMp = mp;
		initEnergy =100;

		imgEnergybar.fillAmount =0/(float)initEnergy;

		//gameMgr = GameObject.Find("GameManager").GetComponent<GameMgr>();
	}

	// Update is called once per frame
	void Update () {

		Move();
		RotateTo();
		FollowTo();
		Action();
		Audio();
		if(hp<=0)
		{

			PlayerDie();
            Destroy(gameObject);
		}

        if (hp > 1000)
            hp = 1000;
        else if (hp < 0)
            hp = 0;

        if (mp > 100)
            mp = 100;
        else if (mp < 0)
            mp = 0;

        if (energy > 100)
            energy = 100;
        else if (energy < 0)
            energy = 0;

		Attack();
		imgHpbar.fillAmount = (float)hp/(float)initHp;
		imgMpbar.fillAmount = (float)mp/(float)initMp;
        imgEnergybar.fillAmount = (float)energy / (float)initEnergy;
        
        stateInfo = actor.GetCurrentAnimatorStateInfo(0);
	}


	void AnimationEvent()
	{
		Destroy(this.gameObject);
	}

	void Move()
	{


		if(Input.GetAxis("Mouse ScrollWheel")<0)
		{
			if(Camera.main.fieldOfView<=100)
				Camera.main.fieldOfView+=2;
			if(Camera.main.orthographicSize<=20)
				Camera.main.orthographicSize +=0.5f;
		}

		if(Input.GetAxis("Mouse ScrollWheel")>0)
		{
			if(Camera.main.fieldOfView>2)
				Camera.main.fieldOfView -=2;
			if(Camera.main.orthographicSize>=1)
				Camera.main.orthographicSize -=0.5f;
		}

		float move_v = 0;
		float move_h = 0;

		if(Input.GetKey(KeyCode.LeftShift))
		{
			shift = true;
		}
		else
			shift = false;

		if(shift==true&&ctrl==false)
			moveSpeed = 15.0f;

		if(shift==false&&ctrl==false)
			moveSpeed =10.0f;

		if(Input.GetKey(KeyCode.LeftControl))
		{
			ctrl = true;
		}

		else
			ctrl = false;

		if(ctrl==true&&shift==false)
			moveSpeed =5.0f;
		if(ctrl==false&&shift==false)
			moveSpeed = 10.0f;

		if(Input.GetKey(KeyCode.W))
		{
			move_v += moveSpeed*Time.deltaTime;

		}


		if(Input.GetKey(KeyCode.S))
		{
			move_v -= moveSpeed*Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.D))
		{
			move_h += moveSpeed*Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.A))
		{
			move_h -= moveSpeed*Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.Space)&&shift==false)
		{
			y=0.2f;
		}
		else if(Input.GetKey(KeyCode.Space)&&shift==true)
		{
			y=0.4f;
		}
		else
			y=0;


		this.m_transform.Translate(new Vector3(move_h,y,move_v));
  
	}
	void RotateTo()
		{

		if(Input.GetKey(KeyCode.Q))
			q_judge = true;
		else
			q_judge = false;
		
		if(Input.GetKey(KeyCode.E))
			e_judge = true;

		else
			e_judge = false;

		if(q_judge)
		{
			rotSpeed = 150.0f;

			rot =-1.0f;
		}

		else if(e_judge)
		{
			rotSpeed = 150.0f;
			rot = 1.0f;
		}

		else
			rotSpeed = 0;
		
		m_transform.Rotate(Vector3.up*Time.deltaTime*rotSpeed*rot,Space.World);

		//The fuction of LookAt whose target maybe the camera;*/



		}
	void FollowTo()
	{
		float rh = Input.GetAxis("Mouse X");
		float rv = Input.GetAxis("Mouse Y");

		if(Input.GetMouseButton(2))
		{
			m_camRot.x -= rv;
			m_camRot.y += rh;
			m_camTransform.eulerAngles = m_camRot;


		}

		/*Vector3 pos = m_transform.position;
		pos.y += m_camHeight;
		pos.z -= m_camDist;
		m_camTransform.position = pos;
         */
		//m_camTransform.LookAt(m_transform.position);


	}
	void Action()
	{
		
	
		if(Input.GetKey(KeyCode.W))
			{
			actor.SetInteger("move",1);
			}

			
		else if(Input.GetKey(KeyCode.A))
		{
			actor.SetInteger("move",2);
		}


		else if(Input.GetKey(KeyCode.D))
		{
			actor.SetInteger("move",3);
		}


		else if(Input.GetKey(KeyCode.S))
		{
			actor.SetInteger("move",4);
		}

		else
			actor.SetInteger("move",0);

		if(Input.GetKey(KeyCode.Space)&&shift==false)
		{
			actor.SetInteger("jump",1);
		}
		else if(Input.GetKey(KeyCode.Space)&&shift==true&&Input.GetKey(KeyCode.W))
		{
			
				actor.SetInteger("jump",2);

		}
		else
			actor.SetInteger("jump",0);



		//Maybe use the BlendTree;
		if(Input.GetKey(KeyCode.W)&&shift==true)
		 {
				actor.SetInteger("shift",1);
		 }

			else
			actor.SetInteger("shift",0);
		

		if(Input.GetKey(KeyCode.W)&&ctrl==true)
		{
			actor.SetInteger("ctrl",1);
		}
		else if(Input.GetKey(KeyCode.A)&&ctrl==true)
		{
			actor.SetInteger("ctrl",2);
		}
		else if(Input.GetKey(KeyCode.D)&&ctrl==true)
		{
			actor.SetInteger("ctrl",3);
		}
		else
			actor.SetInteger("ctrl",0);




  }
	void Audio()
	{

		/*AnimatorStateInfo stateInfo = actor.GetCurrentAnimatorStateInfo(0);

		if(stateInfo.IsName("WAIT00"))
		{
			//girlAudio.clip = clips[0];
			girlAudio.clip = (AudioClip)Resources.Load("laugh",typeof(AudioClip));
			girlAudio.Play();
		}



		if(stateInfo.IsName("WAIT00 0"))
		{
			
			girlAudio.clip = (AudioClip)Resources.Load("yawn",typeof(AudioClip));
			girlAudio.Play();
		}

*/

		/*if(Input.GetKey(KeyCode.W)&&shift==true)
		{
			girlAudio.clip = (AudioClip)Resources.Load("hey",typeof(AudioClip));
			girlAudio.Play();
		}


		if(Input.GetKey(KeyCode.Space)&&shift==true&&Input.GetKey(KeyCode.W))
		{
			girlAudio.clip = (AudioClip)Resources.Load("ha",typeof(AudioClip));
			girlAudio.Play();
		}


		/*if(shift==false&&(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)))
		{
			girlAudio.clip = (AudioClip)Resources.Load("run",typeof(AudioClip));
			girlAudio.Play();
		}*/

	
	
	}

	public void OnDamage(float damage)
	{
		hp-=damage;

	}

	


	 void PlayerDie()
	{
		

			actor.SetTrigger("die");

		//gameMgr.isGameOver = true;

		//GameMgr.instance.isGameOver = true;
	}

	void Attack()
	{
         

        if (stateInfo.IsName("Kick_1"))
        {
            attack_particle_1.SetActive(true);
            
        }

        else
            attack_particle_1.SetActive(false);

        if (stateInfo.IsName("Kick_2"))
        {
            attack_particle_2.SetActive(true);

            
        }

        else
            attack_particle_2.SetActive(false);

        if (stateInfo.IsName("Hit_1"))
        {
            hit_particle.SetActive(true);

            
        }

        else
            hit_particle.SetActive(false);


           if (Input.GetMouseButton(1))
            {

                actor.SetInteger("hit_1", 1);
                actor.SetInteger("attack", 1);
            }

            else
            {
            actor.SetInteger("hit_1", 0);
            actor.SetInteger("attack", 0);

            }

            if (stateInfo.IsName("Hit_1") && Input.GetMouseButton(1))
            {
            actor.SetInteger("kick_1", 1);
            actor.SetInteger("attack", 1);
			//attack_particle_1.SetActive(true);
            }

            else
            {
            actor.SetInteger("attack", 0);
            actor.SetInteger("kick_1", 0);
			//attack_particle_1.SetActive(false);
        }

            if (stateInfo.IsName("Kick_1") && Input.GetMouseButton(1))
            {

            actor.SetInteger("hit_2", 1);
            actor.SetInteger("attack", 1);
            }

            else
            {
            actor.SetInteger("attack", 0);
            actor.SetInteger("hit_2", 0);
        }

            if (stateInfo.IsName("Hit_2") && Input.GetMouseButton(1))
            {
            actor.SetInteger("kick_2", 1);
            actor.SetInteger("attack", 1);
			//attack_particle_2.SetActive(true);
            }

            else
            {
            actor.SetInteger("attack", 0);
            actor.SetInteger("kick_2", 0);
			//attack_particle_2.SetActive(false);
        }
        }

    void KickEvent()
       {
        attack_particle_1.SetActive(true);
       }

    
}



