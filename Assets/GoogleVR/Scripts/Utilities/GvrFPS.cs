
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GvrFPS : MonoBehaviour {
  private const string DISPLAY_TEXT_FORMAT = "{0} msf\n({1} FPS)";
  private const string MSF_FORMAT = "#.#";
  private const float MS_PER_SEC = 1000f;

  private Text textField;
  private float fps = 60;

  public Camera cam;

  void Awake() {
    textField = GetComponent<Text>();
  }

  void Start() {
    if (cam == null) {
       cam = Camera.main;
    }

    if (cam != null) {
      // Tie this to the camera, and do not keep the local orientation.
      transform.SetParent(cam.GetComponent<Transform>(), true);
    }
  }

  void LateUpdate() {
    float interp = Time.deltaTime / (0.5f + Time.deltaTime);
    float currentFPS = 1.0f / Time.deltaTime;
    fps = Mathf.Lerp(fps, currentFPS, interp);
    float msf = MS_PER_SEC / fps;
    textField.text = string.Format(DISPLAY_TEXT_FORMAT,
        msf.ToString(MSF_FORMAT), Mathf.RoundToInt(fps));
  }
}
