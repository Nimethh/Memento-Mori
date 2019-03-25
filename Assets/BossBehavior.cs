using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    // State info
    public enum BossState { FirstStage, Transformation, SecondStage, Death };
    private BossState _state;
    private bool stateTrigger;
    public BossState state {
        get { return _state; }
        private set { this._state = value; }
    }

    // Objects
    private GameObject orb;
    private BossHealth health;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        state = BossState.FirstStage;
        stateTrigger = false;

        orb = GameObject.Find("ControlRobot/Orb");
        health = GetComponent<BossHealth>();
        animator = GetComponent<Animator>();

        // Wait for an attack
        attackCounter = 0;
        attackTimer = Time.time + 3f;
    }

    private void OnDestroy() {
        // Stop all coroutines cleanly
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        switch(state) {
            case BossState.FirstStage:
                UpdateFirst();
                break;

            case BossState.Transformation:
                // Set the animation and ensure it's running
                if(!stateInfo.IsName("CR_Transformation")) {
                    // TODO: Lock player movement

                    // Start animation
                    animator.StopPlayback();
                    animator.Play("CR_Transformation", 0);

                    // Set orb visual properties (Z-neutral, perfectly spherical)
                    orb.transform.position = new Vector3(orb.transform.position.x, orb.transform.position.y, 0);
                    orb.transform.localScale = new Vector3(orb.transform.localScale.x, orb.transform.localScale.x, orb.transform.localScale.x);
                }
                // Stop animation and go to the next state
                else if(stateInfo.normalizedTime >= 1) {
                    animator.StopPlayback();

                    ClearAttackState();
                    health.EnterSecondStage();
                    orb.GetComponent<HealthProxy>().active = true;
                    state = BossState.SecondStage;

                    // TODO: Unlock player movement
                } 
                break;

            case BossState.SecondStage:
                UpdateSecond();
                break;

            case BossState.Death:
                // Set the animation and ensure it's running
                if(!stateInfo.IsName("CR_Death")) {
                    // TODO: Lock player movement

                    animator.StopPlayback();
                    animator.Play("CR_Death", 0);
                }
                // Destroy boss GameObjet after the animation has finished running
                else if(stateInfo.normalizedTime >= 1) {
                    animator.StopPlayback();
                    Destroy(gameObject);
                }
                break;
        }
    }

    [HeaderAttribute("Attack parameters")]
    public float attackInterval = 10f;
    private float attackTimer = 0;
    private int attackCounter = 0;
    private bool attackActive = false;

    private void ClearAttackState() {
        attackTimer = 0;
        attackCounter = 0;
        attackActive = false;
    }


    /*
     *  STAGE 1:
     *  First (and seemingly the only) stage of the battle.
     *  The boss launches seemingly common attacks, and seems fairly aggressive
     *  Who knows what will happen upon depleting all of the boss' health... will it die...?
     */

    [HeaderAttribute("Attack 2, stage 1")]
    public GameObject a2s1bulletPrefab;
    public GameObject a2s1bulletOrigin;
    public int a2s1numberBullets = 30;
    public float a2s1spawnDuration = 2.5f;
    public float a2s1waitDuration = 5f;
    public float a2s1angleSpread = 45f;

    private void UpdateFirst() {
        // If health is zero, transform
        if(health.health <= 0) {
            state = BossState.Transformation;
            return;
        }

        // If counter is modulo 0, it means it's a transition state
        if(attackCounter % 2 == 0) {
            // If timer is elapsed, switch to next state
            if(attackTimer <= Time.time)
                attackCounter++;
            else
                return;
        } 

        switch(Mathf.RoundToInt(attackCounter / 2) % 3) {
            // Slashes its arms at the player
            case 0:
                if(!attackActive)
                   StartCoroutine(PerformAttack1Stage1());
                break;

            // Spews a lot of small, slow bullets
            case 1:
                // TODO: set the position to that of the mouth
                if(!attackActive)
                    StartCoroutine(PerformAttack2Stage1(a2s1numberBullets, a2s1bulletPrefab, a2s1angleSpread, a2s1spawnDuration, a2s1bulletOrigin.transform.position));
                break;

            // Charges at the player
            case 2:
                if(!attackActive)
                    StartCoroutine(PerformAttack3Stage1());
                break;

            default:
                Debug.LogWarning("Nani the fuck? Boss is in an unknown attack state");
                break;
        }
    }

    private IEnumerator PerformAttack1Stage1() {
        attackActive = true;

        // Set the animation and ensure it's running
        animator.StopPlayback();
        animator.Play("CR_SlashAttack", 0);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait for animation to end
        yield return new WaitForSeconds(stateInfo.length);

        animator.StopPlayback();
        
        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;

        // Give sign for next attack starting
        animator.Play("CR_WiggleLegs", 1);
    }

    private IEnumerator PerformAttack2Stage1(int nBullets, GameObject bullet, float angleSpread, float duration, Vector3 position) {
        attackActive = true;

        animator.StopPlayback();
        animator.Play("CR_WiggleLegs", 1);
        animator.Play("CR_WiggleFangs", 0);

        Quaternion rot;
        
        for(int i = 0; i < nBullets; i++) {
            // Calculate direction
            rot = Quaternion.AngleAxis(180f + angleSpread * Random.Range(-1f, +1f), Vector3.forward);
            Instantiate(bullet, position, rot);

            yield return new WaitForSeconds(duration / nBullets);
        }

        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;

        // Give sign for next attack starting
        animator.Play("CR_WinkBig", 2);
    }

    private IEnumerator PerformAttack3Stage1() {        
        attackActive = true;

        // Set the animation and ensure it's running
        animator.StopPlayback();
        animator.Play("CR_ChargeAttack", 0);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait for animation to end
        yield return new WaitForSeconds(stateInfo.length);

        animator.StopPlayback();
        
        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;

        // Give sign for next attack starting
        animator.Play("CR_WinkSmall", 2);
    }


    /*
     *  STAGE 2:
     *  After having the shell broken, the boss' energy orb is now exposed;
     *  This means that the boss is now more vulnerable, but also capable of more powerful attacks 
     */

    [HeaderAttribute("Attack 1, stage 2")]
    public GameObject a1s2bulletPrefab;
    public int a1s2numberBullets = 32;
    public float a1s2attackLength = 4f;

    [HeaderAttribute("Attack 2, stage 2")]
    public GameObject a2s2minionPrefab;
    public int a2s2numberMinions = 3;
    public float a2s2spawnInterval = 0.5f;

    [HeaderAttribute("Attack 3, stage 2")]
    public GameObject a3s2bulletPrefab;
    public int a3s2numberBullets = 16;
    public float a3s2waveInterval = 2f;
    public int a3s2numberWaves = 3;

    private void UpdateSecond() {
        if(health.health <= 0) {
            state = BossState.Death;
            return;
        }

        // If counter is modulo 0, it means it's a transition state
        if(attackCounter % 2 == 0) {
            // If timer is elapsed, switch to next state
            if(attackTimer <= Time.time)
                attackCounter++;
            else
                return;
        } 

        switch(Mathf.RoundToInt(attackCounter / 2) % 3) {
            // Shoot orbs all around
            case 0:
                if(!attackActive)
                    StartCoroutine(PerformAttack1Stage2(a1s2numberBullets, a1s2attackLength, a1s2bulletPrefab));
                break;

            // Send 2 sine waves of minions
            case 1:
                if(!attackActive)
                    StartCoroutine(PerformAttack2Stage2());
                break;

            // Shoot 3 rings of bullets
            case 2:
                if(!attackActive)
                    StartCoroutine(PerformAttack3Stage2(a3s2numberBullets, a3s2waveInterval, a3s2numberWaves, a3s2bulletPrefab));
                break;

            default:
                Debug.LogWarning("Nani the fuck? Boss is in an unknown attack state");
                break;
        }
    }

    private IEnumerator PerformAttack1Stage2(int nBullets, float totalLength, GameObject bulletPrefab) {
        attackActive = true;

        float timeInterval = totalLength / nBullets;
        float angleInterval = 360f / nBullets;

        float angleAccumulator = 0;
        Quaternion rot = new Quaternion();

        for(int i = 0; i < nBullets; i++) {
            rot = Quaternion.AngleAxis(angleAccumulator, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, rot);

            angleAccumulator += angleInterval;
            yield return new WaitForSeconds(timeInterval);
        }

        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;
    }

    private IEnumerator PerformAttack2Stage2() {
        attackActive = true;

        
        // TODO: Implement this attack
        yield return null;

        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;
    }

    private IEnumerator PerformAttack3Stage2(int nBullets, float waveInterval, int nWaves, GameObject bulletPrefab) {
        attackActive = true;

        
        float angleInterval = 360f / nBullets;

        Quaternion rot = new Quaternion();

        for(int j = 0; j < nWaves; j++) {
            for(int i = 0; i < nBullets; i++) {
                rot = Quaternion.AngleAxis(angleInterval * i, Vector3.forward);
                Instantiate(bulletPrefab, transform.position, rot);
            }
            // Wait for next wave
            yield return new WaitForSeconds(waveInterval);
        }

        attackCounter++;
        attackTimer = Time.time + attackInterval;
        attackActive = false;
    }
}
