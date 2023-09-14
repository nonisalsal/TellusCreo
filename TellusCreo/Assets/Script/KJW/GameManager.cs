using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        ArcadeConsole,
        Wire,
        Lock,//5
        LightSwitch,//6
        SignatureCard, // 7
        ShadowLight, // 8
        Mirror,
        ChangeView,
        Curtain
    }

    public UI Ui;
    public List<GameObject> Puzzles;
    public bool onPuzzle;
    public int NUMBER_OF_PUZZLES { get => 10; }
    public GameObject Curtain { get => curtain; }
    public bool SwitchStatus { get => switchStatus; }
    public int SetPlanet = 0;

    [SerializeField] Item sun;
    [SerializeField]
    Sprite defaultCurtainSprtie;
    [SerializeField]
    GameObject curtain;
    [SerializeField]
    GameObject curtain_open;
    List<Func<bool>> ShadowPuzzleDelegate;
    Action Room;
    bool[] ClearPuzzles;
    bool isCurtainOpen;
    bool switchStatus;

    public bool this[int idx] // 인덱서 사용
    {
        get => ClearPuzzles[idx];
        set
        {
            ClearPuzzles[idx] = value;
            if (value == true)  // 클리어 시
            {
                if (idx+NUMBER_OF_PUZZLES == (int)GameManager.Puzzle.ArcadeConsole) // 아케이드 완료시에
                {
                    SoundManager.Instance.Play("puzzle_Arcade_clear");
                }
                else
                {
                    SoundManager.Instance.Play("puzzle_clear");
                }
            }
            Room?.Invoke(); // Room이 null이 아닐때만
        }
    }

    [SerializeField]
    GameObject light2D;
    [SerializeField]
    GameObject globalLight;
    Light2D globalLight2D;
    const int CLEAR_PUZZLE = 7;
    const float DimIntensity = 0.5f;
    const float BrightIntensity = 1f;
    Func<bool> _allClear;


    void Start()
    {
        SoundManager.Instance.Play("Attic_bgm", Sound.Bgm);
        Room += CheckRoomClear;
        ClearPuzzles = new bool[CLEAR_PUZZLE];
        isCurtainOpen = false;
        s_instance = this;
        onPuzzle = false;
        switchStatus = false;
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
        ShadowPuzzleDelegate.Add(() => globalLight2D != null && globalLight2D.intensity == DimIntensity); // 어둡게 되어있는건지
        ShadowPuzzleDelegate.Add(() => isCurtainOpen == false); // 커튼 열렸는지
        ShadowPuzzleDelegate.Add(() => Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>().IsOnStand); // 커튼 열렸는지
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
                    SoundManager.Instance.Play("light_switch");
                    if (ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES]) // 전선 연결이 됐는지
                    {
                        globalLight2D.intensity = globalLight2D.intensity == DimIntensity ? BrightIntensity : DimIntensity; // 조명 밝기 조절
                        if (globalLight2D.intensity == DimIntensity)
                        {
                            switchStatus = false;
                        }
                        else
                        {
                            switchStatus = true;
                        }
                        ShadowPuzzle puzzleObject = Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();
                        SpriteRenderer curtainSprRend = curtain.GetComponent<SpriteRenderer>();
                        if (curtainSprRend != null)
                        {
                            if (ShadowPuzzleChaeck())
                            {
                                curtainSprRend.sprite = puzzleObject.ChangeShadow(false);
                            }
                            else
                            {
                                curtainSprRend.sprite = defaultCurtainSprtie;
                            }
                        }
                    }
                    else
                    {

#if UNITY_EDITOR
                        Debug.Log("전선 연결 필요");
#endif
                    }
                    break;

                case Puzzle.ChangeView: // 창 밖
                    Puzzles[(int)Puzzle.Star - NUMBER_OF_PUZZLES]?.GetComponent<BackgroundManager>()?.ChangeBackgroundSprite(); // 창 밖 변환
#if UNITY_EDITOR
                    Debug.Log("창밖 변환");
#endif
                    break;

                case Puzzle.Curtain: // 커튼

                    isCurtainOpen = !isCurtainOpen;
#if UNITY_EDITOR
                    Debug.Log($"커튼 상태 {(isCurtainOpen == true ? "열림" : "닫힘")}");

#endif
                    if (isCurtainOpen)
                    {
                        curtain_open?.SetActive(true);
                        curtain?.SetActive(false);
                        hitGameObject.transform.parent.Find("Mirror").gameObject.SetActive(true);
                        SoundManager.Instance.Play("curtain_open"); // 열림 사운드
                    }
                    else
                    {
                        SoundManager.Instance.Play("curtain_close"); // 닫힘 사운드
                        if (ShadowPuzzleChaeck())
                        {    
                            ShadowPuzzle puzzleObject = Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();
                            if (puzzleObject != null)
                            {
                                SpriteRenderer curtainSprRend = curtain.GetComponent<SpriteRenderer>();
                                if (curtainSprRend != null)
                                {
                                    curtainSprRend.sprite = puzzleObject.ChangeShadow(false);
                                }
                            }
                        }
                        curtain?.SetActive(true);
                        curtain_open?.SetActive(false);
                        hitGameObject.transform.parent.Find("Mirror").gameObject.SetActive(false);
                    }

                    ClueManager clue = curtain.transform.parent.GetComponent<ClueManager>();
                    if (clue != null)
                    {
                        clue.ShowClue();
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
                        SoundManager.Instance.Play("puzzle_Arcade_cant_use");
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
                        background?.transform.Find("AfterPoster")?.gameObject.SetActive(true); // AfterPoster
                        background?.transform.Find("BeforePoster")?.gameObject.SetActive(false); // BeforePoster       
                    }
                    else if (hitGameObject.CompareTag("AfterPoster"))
                    {
                        BackgroundManager background = hitGameObject.transform.parent.GetComponent<BackgroundManager>();

                        background?.transform.Find("AfterPoster")?.gameObject.SetActive(false); // AfterPoster
                        background?.transform.Find("BeforePoster")?.gameObject.SetActive(true); // BeforePoster
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

                case Puzzle.ShadowLight: // 스탠드(그림자 퍼즐)
                    SoundManager.Instance.Play("light_switch");
                    if (!ClearPuzzles[(int)Puzzle.LightSwitch - NUMBER_OF_PUZZLES])
                    {
#if UNITY_EDITOR
                        Debug.LogError("전선 연결 필요");
#endif
                        break;
                    }

#if UNITY_EDITOR
                    Debug.Log("ShadowLight");
#endif    
                    SpriteRenderer backGround4 = GameObject.FindGameObjectWithTag("Background4")?.GetComponent<SpriteRenderer>(); // 조명 상태 변경을 위한 스프라이트
                    ShadowPuzzle shadowPuzzle = Puzzles[(int)Puzzle.ShadowLight - NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();

                    if (shadowPuzzle != null)
                    {
                        shadowPuzzle.IsOnStand = !shadowPuzzle.IsOnStand; // 스탠드 boolean 켜고 끄고 변경
                        backGround4.sprite = shadowPuzzle.Return2StandSprite(); // 조명 ON/OFF 스프라이트

                        if (!shadowPuzzle.IsOnStand) // 스탠드 켜져있고 커튼은 닫혀있을 때 
                        {
                            ChangCurtainSprite2Default();
                        }

                        if (ShadowPuzzleChaeck()) // 스탠드 켜짐, 어두움, 커튼이 닫힘 , 전선 연결
                        {
                            Item ball = InventoryManager.Instance.Items.FirstOrDefault(item => item.name == "Ball");
                            if (ball != null && shadowPuzzle.CurrentShadow == ShadowPuzzle.Shadow.Dog) // 테스트 용 코드
                            {
                                StartCoroutine(shadowPuzzle.DogShadowCatchBall()); // 공 물어오기
                            }
                            SpriteRenderer curtainSprRen = curtain.GetComponent<SpriteRenderer>();
                            if (curtainSprRen != null)
                            {
                                curtainSprRen.sprite = shadowPuzzle.ChangeShadow(false);
                            }
                        }
                    }
                    break;
                case Puzzle.Mirror:
                    if (isCurtainOpen)
                    {
                        BackgroundManager mirrorBM = Puzzles[(int)Puzzle.Mirror - NUMBER_OF_PUZZLES].GetComponent<BackgroundManager>();
                        Puzzles[(int)Puzzle.Mirror - NUMBER_OF_PUZZLES]?.SetActive(true);
                        ChangeBackground();
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

    void ChangeBackground()// 카메라 이동
    {
        if (!onPuzzle)
        {
            Ui.prevCameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(0, -25f, -100f);
            Ui.ActiveBackArrow();
            onPuzzle = true;
        }
    }

    void CheckRoomClear()
    {
        if (ClearPuzzles.Any(puzzle => puzzle == false))
        {
#if UNITY_EDITOR
            Debug.Log("풀 퍼즐이 남았음");
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("다락방 완료");
#endif
            if(InventoryManager.Instance!=null)
            {
                InventoryManager.Instance.Add(sun);
            }
        }
    }

    void ChangCurtainSprite2Default()
    {
        SpriteRenderer curtainSprRend = curtain.GetComponent<SpriteRenderer>();
        if (curtainSprRend != null)
        {
            if (defaultCurtainSprtie != null)
            {
                curtainSprRend.sprite = defaultCurtainSprtie;
            }
        }
    }

    public bool ShadowPuzzleChaeck()
    {
        foreach (Func<bool> condition in ShadowPuzzleDelegate)
        {
            if (!condition())
            {
                return false;
            }
        }
        return true;
    }

    public bool GetCurtainStatus() // 커튼이 열려있는지 
    {
        return isCurtainOpen;
    }

    public T FindPuzzleObject<T>() where T : Component
    {
        // T 컴포넌트 찾아서 반환 (Select에서 시퀀스 반환 후 FirstOrDefault에서 순회하면서 그 중 컴포넌트를 찾아서 반환)
        return Puzzles.Select(obj => obj.GetComponent<T>()).FirstOrDefault(component => component != null);
    }
}
