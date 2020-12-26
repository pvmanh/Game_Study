using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FreeDraw
{
    // Helper methods used to set drawing settings
    public class DrawingSettings : MonoBehaviour
    {
        public static bool isCursorOverUI = false;
        public float Transparency = 1f;
        public Color total;

        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width
        public void SetMarkerColour(Color new_color)
        {
            Drawable.Pen_Colour = new_color;
        }
        // new_width is radius in pixels
        public void SetMarkerWidth(int new_width)
        {
            Drawable.Pen_Width = new_width;
        }
        public void SetMarkerWidth(float new_width)
        {
            SetMarkerWidth((int)new_width);
        }

        public void SetTransparency(float amount)
        {
            Transparency = amount;
            Color c = Drawable.Pen_Colour;
            c.a = amount;
            Drawable.Pen_Colour = c;
        }


        // Call these these to change the pen settings
        public void SetMarkerRed()
        {
            Color c = Color.red;
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerGreen()
        {
            Color c = Color.green;
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerBlue()
        {
            Color c = Color.blue;
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerYellow()
        {
            //Color c = Color.yellow;
            Color c = new Color(0.9058824f, 0.8705883f, 0.09019608f, 1f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerBlack()
        {
            Color c = Color.black;
            //Color c = new Color(0.79f, 0.54f, 0.54f, 0f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerGray()
        {
            Color c = new Color(0.7686275f, 0.7098039f, 0.6039216f, 1f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerPink()
        {
            Color c = Color.magenta;
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerBrown()
        {
            Color c = new Color(0.3764706f, 0.2156863f, 0.08235294f, 1f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }

        public void SetMarkerPurple()
        {
            Color c = new Color(0.4f, 0.1803922f, 0.5686275f, 1f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerOrange()
        {
            Color c = new Color(0.9686275f, 0.5843138f, 0.1098039f, 1f);
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerSkyBlue()
        {
            Color c = Color.cyan;
            total = c;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetEraser()
        {
            
            SetMarkerColour(Color.white);

            
        }

        public void PartialSetEraser()
        {
            SetMarkerColour(total);
        }
    }
}