using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Monkey : MonoBehaviour
{

    Mover mover;
    public bool isXPressed = false;
    
    [SerializeField]
    public Transform destination;
    private GameObject key;
    public GameObject monkey;
    
    bool[] mYellow = new bool[3];
    bool[] mGreen = new bool[3];
    int[] mgreenkeycount = new int[3];
    int[] myellowkeycount = new int[3];
    bool[] mWinKey = new bool[3];
    int[] mwinkeycount = new int[3];
    // int[] redKeyCount = new int[3];
    int redKeyCount = 0;
    bool[] mRed = new bool[3];

    public bool[] teleportMonkey = new bool[3] { false, false, false };

    [SerializeField]
    GameObject yellowKey;
    [SerializeField]
    GameObject greenKey;
    [SerializeField]
    GameObject blueKey;
    [SerializeField]
    GameObject redKey;

    [SerializeField]
    AudioSource keySound;
    [SerializeField]
    AudioSource monkeyHitSound;

    float timer = 5f;
    void Start()
    {
        mover = GetComponent<Mover>();
        mover.GetPlayerIndex();
    }
    private void OnPickUp(InputValue x)
    {
        isXPressed = x.isPressed;
        //print(mover.GetPlayerIndex());
        for(int i = 0; i < 3; i++)
        {
            if(isXPressed && mYellow[i] && mover.GetPlayerIndex() == i && key.tag == "YellowKey")
            {
                myellowkeycount[i]++;
                print(myellowkeycount[i]);
                Destroy(key);
                keySound.Play();
                mYellow[i] = false;
                yellowKey.SetActive(true);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (isXPressed && mGreen[i] && mover.GetPlayerIndex() == i && key.tag == "GreenKey")
            {
                mgreenkeycount[i]++;
                Destroy(key);
                keySound.Play();
                mGreen[i] = false;
                greenKey.SetActive(true);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (isXPressed && mWinKey[i] && mover.GetPlayerIndex() == i && key.tag == "WinKey")
            {
                mwinkeycount[i]++;
                Destroy(key);
                keySound.Play();
                mWinKey[i] = false;
                blueKey.SetActive(true);
            }
        }
        for(int i = 0; i < 3; i++)
        {
            if(isXPressed && mRed[i] && mover.GetPlayerIndex() == i && key.tag == "RedKey")
            {
                redKeyCount++;
                Destroy(key);
                keySound.Play();
                mRed[i] = false;
                print(redKeyCount);
                redKey.SetActive(true);
            }
        }
    }

    public bool GetIsXPressed()
    {
        return isXPressed;
    }
    public int GetTotalRedKey()
    {
        return redKeyCount;
    }

    public int GetM1ReDKeyCount()
    {
        return 1;
    }
    public int GetM2ReDKeyCount()
    {
        return 1;
    }
    public int GetM3ReDKeyCount()
    {
        return 1;
    }
    public int GetM1YellowKeyCount()
    {
        return myellowkeycount[0];
    }
    public int GetM2YellowKeyCount()
    {
        return myellowkeycount[1];
    }

    public int GetM3YellowKeyCount()
    {
        return myellowkeycount[2];
    }
    public int GetM1GreenKeyCount()
    {
        return mgreenkeycount[0];
    }
    public int GetM2GreenKeyCount()
    {
        return mgreenkeycount[1];
    }
    public int GetM3GreenKeyCount()
    {
        return mgreenkeycount[2];
    }
    public int GetM1WinKeyCount()
    {
        return mwinkeycount[0];
    }
    public int GetM2WinKeyCount()
    {
        return mwinkeycount[1];

    }
    public int GetM3WinKeyCount()
    {
        return mwinkeycount[2];

    }
    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < 3; i++)
        {
            if(mover.GetPlayerIndex() == i && other.tag == "YellowKey")
            {
                mYellow[i] = true;
                key = other.gameObject;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if(mover.GetPlayerIndex() == i && other.tag == "GreenKey")
            {
                mGreen[i] = true;
                key = other.gameObject;
            }
        }
        for(int i = 0; i < 3; i++)
        {
            if(mover.GetPlayerIndex() == i && other.tag == "WinKey")
            {
                mWinKey[i] = true;
                key = other.gameObject;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (mover.GetPlayerIndex() == i && other.tag == "RedKey")
            {
                mRed[i] = true;
                key = other.gameObject;
            }
        }
        
        if(other.tag == "Bullet")
        {
            mover.MoveSpeed = 3f;
            monkeyHitSound.Play();
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (mover.MoveSpeed == 3f)
        {
            timer -= Time.deltaTime;
            print(timer);
            if (timer <= 0)
            {
                mover.MoveSpeed = 10;
                timer = 5f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for(int i = 0; i < 3; i++)
        {
            if(mover.GetPlayerIndex() == i && other.tag == "YellowKey")
            {
                mYellow[i] = false;
            }
        }

        for(int i = 0; i < 3; i++)
        {
            if(mover.GetPlayerIndex() == i && other.tag == "GreenKey")
            {
                mGreen[i] = false;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (mover.GetPlayerIndex() == i && other.tag == "WinKey")
            {
                mWinKey[i] = false;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (mover.GetPlayerIndex() == i && other.tag == "RedKey")
            {
                mRed[i] = false;
            }
        }
       
    }
    public void DisablingPortal(int mIndex)
    {
       
        if (!teleportMonkey[mIndex])
        {
            StartCoroutine(MTeleportCD(mIndex));
            teleportMonkey[mIndex] = true;
        }
 }

    IEnumerator MTeleportCD(int index)
    {
        yield return new WaitForSeconds(2);
        teleportMonkey[index] = false;
    }
}

