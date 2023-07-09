using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{

    static GameManager s_instance = null;

    public static GameManager Instance { get { if (s_instance == null) return null; return s_instance; } }


    public enum Puzzle
    {
        Poster = 10,
        WetTissue,
        Star,
        SignatureCard, // 13
        Wire,
        ShadowLight, // 15
        ArcadeConsole,
        Lock,
        LightSwitch,
        ChangeView,
        Curtain,
    }

    public UI Ui;
    public GameObject[] Puzzles;
    public bool onPuzzle;
    public int NUMBER_OF_PUZZLES { get => number_of_puzzles;}
    public GameObject Curtain { get => curtain; }

    
    [SerializeField]
    GameObject curtain;
    List<Func<bool>> ShadowPuzzleDelegate;
    Action Room;
    bool[] ClearPuzzles;
    bool isCurtainOpen;

    public bool this[int idx] // 인덱서 사용
    {
        get => ClearPuzzles[idx];
        set
        {
            ClearPuzzles[idx] = value;
            Room?.Invoke(); // Room이 null이 아닐때만
        }
    }

    [SerializeField]
    GameObject light2D;
    [SerializeField]
    GameObject globalLight;
    Light2D globalLight2D;
    const int number_of_puzzles = 10;

    void Start()
    {
        Room += CheckRoomClear;
        ClearPuzzles = new bool[NUMBER_OF_PUZZLES];
        isCurtainOpen = false;
        s_instance = this;
        onPuzzle = false;
        globalLight2D = globalLight?.GetComponent<Light2D>();
        ShadowPuzzleSetup();
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            HandlePuzzleClick();
        }
    }

    void ShadowPuzzleSetup()
    {
        ShadowPuzzleDelegate = new List<Func<bool>>();
        ShadowPuzzleDelegate.Add(() => ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES]); // 전선 연결이 됐는지
        ShadowPuzzleDelegate.Add(()=> globalLight2D != null && globalLight2D.intensity == 0.5f); // 어둡게 되어있는건지
        ShadowPuzzleDelegate.Add(()=> isCurtainOpen == false); // 커튼 열렸는지
    }

    void HandlePuzzleClick()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
        RaycastHit2D rayHit = Physics2D.Raycast(mousePos, transform.forward, 10f); // 레이캐스트
        if (rayHit.collider == null)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hitGameObject = rayHit.collider.gameObject;

            switch ((Puzzle)((int)hitGameObject.layer))
            {
                case Puzzle.LightSwitch: // 스위치 
                    if (ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES])
                        globalLight2D.intensity = globalLight2D.intensity == 0.5f ? 1f : 0.5f; // 조명 밝기 조절
                    else 
#if UNITY_EDITOR
                        Debug.Log("전선 연결 필요");
#endif
                    break;

                case Puzzle.ChangeView: // 창 밖
                    Puzzles[(int)Puzzle.Star - NUMBER_OF_PUZZLES]?.GetComponent<BackgroundManager>()?.ChangeBackgroundSprite(); // 창 밖 변환
#if UNITY_EDITOR
                    Debug.Log("창밖 변환");
#endif
                    break;

                case Puzzle.Curtain: // 커튼
#if UNITY_EDITOR
                    Debug.Log("커튼 상태 " + (isCurtainOpen = !isCurtainOpen));

#endif
                    // 추후 수정 부분( 그림자 퍼즐 켜진 상태에서 커튼 누를 시 뒤에 그림자 스프라이트를 더러운 거울 또는 깨끗한 거울로 바뀌게 만들기)
                    if (!isCurtainOpen) // 커든을 닫았을 때
                    {
                        ShadowPuzzle shadowPuzzle1 = Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();

                        if (shadowPuzzle1.IsOnStand) // 스탠드가 켜져있다면
                        {
                            if (ShadowPuzzleChaeck() && !isCurtainOpen) // 스탠드 켜짐, 어두움, 커튼이 닫힘 
                            {
                                curtain.SetActive(false); // 기존 커튼 오브젝트는 비활성화 후 그림자 스프라이트 
                                GameObject.FindGameObjectWithTag("Background2").GetComponent<SpriteRenderer>().sprite = shadowPuzzle1?.ChangeShadow();
                            }
                        }
                    }

                    if(hitGameObject.transform.childCount!=0)
                    {
                        hitGameObject.transform.GetChild(0).gameObject?.SetActive(true); // 전선 타일 
                    }
                    break;
                case Puzzle.Lock: // 자물쇠 
#if UNITY_EDITOR
                    Debug.Log("LockPuzzle");
#endif
                    Puzzles[(int)Puzzle.Lock - NUMBER_OF_PUZZLES].SetActive(true);
                    ChangeBackground();
                    break;
                case Puzzle.ArcadeConsole: // 오락기 
                    if (ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES])
                    {
                        Puzzles[(int)Puzzle.ArcadeConsole - NUMBER_OF_PUZZLES].SetActive(true);
                        ChangeBackground();
                    }
                    else
                    {
#if UNITY_EDITOR
                        Debug.Log("전선 연결 필요");
#endif
                        break;
                    }
#if UNITY_EDITOR
                    Debug.Log("ArcadeConsole");
#endif
                    break;

                case Puzzle.Poster: // 포스터 퍼즐
                    if (hitGameObject.CompareTag("PosterCorners")) // 포스터의 모서리라면
                    {
#if UNITY_EDITOR
                        Debug.Log("PosterCorners");
#endif
                        BackgroundManager background = hitGameObject.transform.parent.parent.GetComponent<BackgroundManager>();
                        background?.transform.GetChild(1).gameObject.SetActive(true); // AfterPoster
                        background?.transform.GetChild(0).gameObject.SetActive(false); // BeforePoster
                    }
                    else if(hitGameObject.CompareTag("AfterPoster"))
                    {
                        BackgroundManager background = hitGameObject.transform.parent.GetComponent<BackgroundManager>();
                        hitGameObject.transform.gameObject.SetActive(false); // AfterPoster
                        background?.transform.GetChild(0).gameObject.SetActive(true); // BeforePoster
                    }
                    else
                    {
#if UNITY_EDITOR
                        Debug.Log("Poster");
#endif
                        Puzzles[(int)Puzzle.Poster - NUMBER_OF_PUZZLES].SetActive(true);
                        ChangeBackground();
                    }
                    break;

                case Puzzle.WetTissue: // 물티슈
                    Puzzles[(int)Puzzle.WetTissue - NUMBER_OF_PUZZLES].SetActive(true);
#if UNITY_EDITOR
                    Debug.Log("WetTissue");
#endif
                    ChangeBackground();
                    break;

                case Puzzle.SignatureCard: // 명함
                    Puzzles[(int)Puzzle.SignatureCard - NUMBER_OF_PUZZLES].SetActive(true);
#if UNITY_EDITOR
                    Debug.Log("SignatureCard");
#endif
                    ChangeBackground();
                    break;

                case Puzzle.Star: // 별자리
                    Puzzles[(int)Puzzle.Star - NUMBER_OF_PUZZLES].SetActive(true);
                    ToggleLights();
#if UNITY_EDITOR
                    Debug.Log("Star");
#endif
                    ChangeBackground();
                    break;

                case Puzzle.Wire: // 전선
                    Puzzles[(int)Puzzle.Wire - NUMBER_OF_PUZZLES].SetActive(true);
#if UNITY_EDITOR
                    Debug.Log("Wire");
#endif
                    ChangeBackground();
                    break;

                case Puzzle.ShadowLight: // 그림자 조명
                    if (!ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES])
                    {
#if UNITY_EDITOR
                        Debug.LogError("전선 연결 필요");
#endif
                        break;
                    }
                    ShadowPuzzle shadowPuzzle = Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();
#if UNITY_EDITOR
                    Debug.Log("ShadowLight");
#endif    
                    BackgroundManager backGround2 = GameObject.FindGameObjectWithTag("Background2")?.GetComponent<BackgroundManager>();
                    SpriteRenderer backGround4 = GameObject.FindGameObjectWithTag("Background4")?.GetComponent<SpriteRenderer>(); // 조명 상태 변경을 위한 스프라이트

                    if(shadowPuzzle != null) 
                    {
                        shadowPuzzle.IsOnStand = !shadowPuzzle.IsOnStand; // 스탠드 boolean 켜고 끄고 변경
                        backGround4.sprite = shadowPuzzle.Retunr2StandSprite(); // 조명 ON/OFF 스프라이트

                        if(!shadowPuzzle.IsOnStand && !isCurtainOpen)
                        {
                            curtain.SetActive(true);
                        }

                        // 코드 재사용성 늘리기
                        if (shadowPuzzle.IsOnStand && ShadowPuzzleChaeck() && !isCurtainOpen) // 스탠드 켜짐, 어두움, 커튼이 닫힘 
                        { 
                            
                            curtain.SetActive(false);
                            backGround2.GetComponent<SpriteRenderer>().sprite = shadowPuzzle.ChangeShadow();
                        }
                    }
                    break;
            }
        }
    }

    public void ToggleLights()
    {
        // 라이트가 켜져있으면 끄고, 꺼져있으면 켠다
        light2D.gameObject.SetActive(!light2D.gameObject.activeSelf);
        globalLight.gameObject.SetActive(!globalLight.gameObject.activeSelf);

        if (light2D.gameObject.activeSelf)
        {
            float lightY = -25f; // light2D의 y 좌표 값
            light2D.transform.position = new Vector2(0, lightY);
        }
    }

    void ChangeBackground()// 뒷 배경 퍼즐 배경으로 변경
    {
        if (!onPuzzle)
        {
            Ui.prevCameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(0, -25f, -100f);
            ActiveBackArrow();
            onPuzzle = true;
        }
    } 

    void ActiveBackArrow()
    {
        Ui.backArrow.SetActive(true);
        Ui.DisableArrow();
    }

    void CheckRoomClear()
    {
        foreach (var puzzle in ClearPuzzles)
        {
            if (!puzzle)
            {
                Debug.Log("풀 퍼즐이 남았음");
                return;
            }
        }
    }

   public bool ShadowPuzzleChaeck()
    {
        foreach(Func<bool> condition in ShadowPuzzleDelegate)
        {
            if(!condition())
            {
                return false;
            }    
        }
        return true;
    }

    public bool GetCurtainState() // 커튼이 열려있는지 
    {
        return isCurtainOpen;
    }

    public void SetActiveCurtainObjects() 
    { 
        if(isCurtainOpen)
        {
            return;
        }
        // 스탠드가 켜지면 기존 커텐 오브젝트들을 모두 false (그림자 퍼즐을 위해서)
        // 만약 전부 꺼져 있다면 전부 활성화
    }

}
