using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageUtils
{
    public struct Point
    {
        public short x;
        public short y;
        public Point(short _x, short _y) { x = _x; y = _y; }
        public Point(int _x, int _y) : this((short)_x, (short)_y) { }
    }

    public static void FloodFillArea(Texture2D _Texture, int _x, int _y, Color ColorToFill)
    {   
        int Width = _Texture.width;
        int Height = _Texture.height;
        Color[] colors = _Texture.GetPixels();
        Color ClickedColor = colors[_x + _y * Width];
        Queue<Point> Points = new Queue<Point>();
        Points.Enqueue(new Point(_x, _y));
        while (Points.Count > 0)
        {
            Point current = Points.Dequeue();
            for (int i = current.x; i < Width; i++)
            {
                Color currentColor = colors[i + current.y * Width];
                if (currentColor != ClickedColor || currentColor == ColorToFill)
                    break;
                colors[i + current.y * Width] = ColorToFill;
                if (current.y + 1 < Height)
                {
                    currentColor = colors[i + current.y * Width + Width];
                    if (currentColor == ClickedColor && currentColor != ColorToFill)
                        Points.Enqueue(new Point(i, current.y + 1));
                }
                if (current.y - 1 >= 0)
                {
                    currentColor = colors[i + current.y * Width - Width];
                    if (currentColor == ClickedColor && currentColor != ColorToFill)
                        Points.Enqueue(new Point(i, current.y - 1));
                }
            }
            for (int i = current.x - 1; i >= 0; i--)
            {
                Color C = colors[i + current.y * Width];
                if (C != ClickedColor || C == ColorToFill)
                    break;
                colors[i + current.y * Width] = ColorToFill;
                if (current.y + 1 < Height)
                {
                    C = colors[i + current.y * Width + Width];
                    if (C == ClickedColor && C != ColorToFill)
                        Points.Enqueue(new Point(i, current.y + 1));
                }
                if (current.y - 1 >= 0)
                {
                    C = colors[i + current.y * Width - Width];
                    if (C == ClickedColor && C != ColorToFill)
                        Points.Enqueue(new Point(i, current.y - 1));
                }
            }
        }
        _Texture.SetPixels(colors);
    }
}
