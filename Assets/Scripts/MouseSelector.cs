using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;

    public ColorButton [] buttons;
    public ColorButton [] backgrounds;

    private ClickColors controls;
    private Camera mainCamera;

    int CaminoActual;
    int PasoActual;

    private void Awake() {
        controls = new ClickColors();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void Refresh() {
        foreach (var button in buttons) {
            button.Deactivate();
        }
        if (CaminoActual == 0) {
            foreach (var button in buttons) {
                if (button.Paso == 1) {
                    button.Activate();
                }
            }
        } else
        {
            foreach (var button in buttons) {
                if (button.Paso == (PasoActual+1) && button.Camino == CaminoActual) {
                    button.Activate();
                }
            }
        }
        foreach (var background in backgrounds) {
            background.Deactivate();
        }
        foreach (var background in backgrounds) {
            if (background.Paso == PasoActual && background.Camino == CaminoActual) {
                background.Activate();
            }
        }
    } 

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        Refresh();
    }

    private void StartedClick() {
        ChangeCursor(cursorClicked);
        DetectObject();
    }

    private void EndedClick() {
        ChangeCursor(cursor);
    }

    private void DetectObject() {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        

        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null) {
            var button = hits2D.collider.GetComponent<ColorButton>();
            if (button != null) {
                CaminoActual = button.Camino;
                PasoActual = button.Paso;
                Refresh();
            }
            
        }
    }

    private void ChangeCursor(Texture2D cursorType){
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
    
}