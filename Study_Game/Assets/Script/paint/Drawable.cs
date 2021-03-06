﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace FreeDraw
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]  // REQUIRES A COLLIDER2D to function
    // 1. Attach this to a read/write enabled sprite image
    // 2. Set the drawing_layers  to use in the raycast
    // 3. Attach a 2D collider (like a Box Collider 2D) to this sprite
    // 4. Hold down left mouse to draw on this texture!
    public class Drawable : MonoBehaviour 
    {
        // PEN COLOUR
        public static Color Pen_Colour = Color.black;     // Change these to change the default drawing settings
        // PEN WIDTH (actually, it's a radius, in pixels)
        public static int Pen_Width = 3;


        public delegate void Brush_Function(Vector2 world_position);
        // This is the function called when a left click happens
        // Pass in your own custom one to change the brush type
        // Set the default function in the Awake method
        public Brush_Function current_brush;

        public LayerMask Drawing_Layers;

        public bool Reset_Canvas_On_Play = true;
        // The colour the canvas is reset to each time
        public Color Reset_Colour = new Color(0, 0, 0, 0);  // By default, reset the canvas to be transparent

        // Used to reference THIS specific file without making all methods static
        public static Drawable drawable;
        // MUST HAVE READ/WRITE enabled set in the file editor of Unity
        Sprite drawable_sprite;
        Texture2D drawable_texture;

        Vector2 previous_drag_position;
        Color[] clean_colours_array;
        Color transparent;
        Color32[] cur_colors;
        bool mouse_was_previously_held_down = false;
        public Texture2D icon;
        public Texture2D[] LoadPicture;
        public Texture2D[] LoadPath;
        public GameObject ScrollView;
        public GameObject ScrollViewpath;
        public GameObject SVimage;
        public GameObject SVimagePath;
        public bool is_bool= true;
        int icounter = 1;
        public Texture2D[] Undo;
        public int count_undo = 0;
        public int i_undo = 0;
        public int tam_undo =0;
        public GameObject menu;
        public GameObject iconparentmove;
        public GameObject iconselected;
        Texture2D biendao;
        Texture2D biendao2;
        //public bool is_bucket_point = false;


        public enum Paint_style
        {
            is_brush,
            is_bucket,
            is_paste_icon,
            is_load
        }
        public Paint_style Style_paint;

//////////////////////////////////////////////////////////////////////////////
// BRUSH TYPES. Implement your own here


        // When you want to make your own type of brush effects,
        // Copy, paste and rename this function.
        // Go through each step
        public void BrushTemplate(Vector2 world_position)
        {
            // 1. Change world position to pixel coordinates
            Vector2 pixel_pos = WorldToPixelCoordinates(world_position);

            // 2. Make sure our variable for pixel array is updated in this frame
            cur_colors = drawable_texture.GetPixels32();

            ////////////////////////////////////////////////////////////////
            // FILL IN CODE BELOW HERE

            // Do we care about the user left clicking and dragging?
            // If you don't, simply set the below if statement to be:
            //if (true)

            // If you do care about dragging, use the below if/else structure
            if (previous_drag_position == Vector2.zero)
            {
                // THIS IS THE FIRST CLICK
                // FILL IN WHATEVER YOU WANT TO DO HERE
                // Maybe mark multiple pixels to colour?
                MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
            }
            else
            {
                // THE USER IS DRAGGING
                // Should we do stuff between the previous mouse position and the current one?
                ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
            }
            ////////////////////////////////////////////////////////////////

            // 3. Actually apply the changes we marked earlier
            // Done here to be more efficient
            ApplyMarkedPixelChanges();
            
            // 4. If dragging, update where we were previously
            previous_drag_position = pixel_pos;
        }



        
        // Default brush type. Has width and colour.
        // Pass in a point in WORLD coordinates
        // Changes the surrounding pixels of the world_point to the static pen_colour
        public void PenBrush(Vector2 world_point)
        {
            Vector2 pixel_pos = WorldToPixelCoordinates(world_point);

            cur_colors = drawable_texture.GetPixels32();

            if (previous_drag_position == Vector2.zero)
            {
                // If this is the first time we've ever dragged on this image, simply colour the pixels at our mouse position
                MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
            }
            else
            {
                // Colour in a line from where we were on the last update call
                ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
            }
            ApplyMarkedPixelChanges();

            //Debug.Log("Dimensions: " + pixelWidth + "," + pixelHeight + ". Units to pixels: " + unitsToPixels + ". Pixel pos: " + pixel_pos);
            previous_drag_position = pixel_pos;
        }


        // Helper method used by UI to set what brush the user wants
        // Create a new one for any new brushes you implement
        public void SetPenBrush()
        {
            // PenBrush is the NAME of the method we want to set as our current brush
            current_brush = PenBrush;
        }
//////////////////////////////////////////////////////////////////////////////






        // This is where the magic happens.
        // Detects when user is left clicking, which then call the appropriate function
        void Update()
        {
            // Is the user holding down the left mouse button?
            bool mouse_held_down = Input.GetMouseButton(0);
           
           // bool mouse_held_up = Input.GetMouseButtonUp(0);
            if (mouse_held_down && Style_paint == Paint_style.is_brush)
            {
                // Convert mouse coordinates to world coordinates
                Vector2 mouse_world_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Check if the current mouse position overlaps our image
                Collider2D hit = Physics2D.OverlapPoint(mouse_world_position, Drawing_Layers.value);
                if (hit != null && hit.transform != null)
                {
                    // We're over the texture we're drawing on!
                    // Use whatever function the current brush is
                    current_brush(mouse_world_position);
                    
                }

                else
                {
                    // We're not over our destination texture
                    previous_drag_position = Vector2.zero;
                   
                    if (!mouse_was_previously_held_down)
                    {
                        // This is a new drag where the user is left clicking off the canvas
                        // Ensure no drawing happens until a new drag is started
                        //no_drawing_on_current_drag = true;
                    }
                }
                

            }
            // Mouse is released
            else if (!mouse_held_down)
            {
                previous_drag_position = Vector2.zero;
                //no_drawing_on_current_drag = false;

            }
           mouse_was_previously_held_down = mouse_held_down;

            //Tô màu 
            if(Input.GetMouseButton(0) && Style_paint == Paint_style.is_bucket)
            {
                Vector2 mouse_world_position_bucket = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //RaycastHit2D hit = Physics2D.Raycast(mouse_world_position_bucket, Vector2.zero);
                Collider2D hit = Physics2D.OverlapPoint(mouse_world_position_bucket, Drawing_Layers.value);
                if (!hit)
                {
                    return;
                }

                SpriteRenderer rend = hit.transform.GetComponent<SpriteRenderer>();
                BoxCollider2D meshCollider = hit as BoxCollider2D;

                if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                {
                    return;
                }

                Texture2D tex = rend.material.mainTexture as Texture2D;
                Vector2 pixelUV = WorldToPixelCoordinates(mouse_world_position_bucket);
                //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Pen_Colour);
                int num_X = (int)pixelUV.x;
                int num_Y = (int)pixelUV.y;
                
                ImageUtils.FloodFillArea(tex, num_X, num_Y, Pen_Colour);
                tex.Apply();

               

            }
            if (Style_paint == Paint_style.is_load)
            {
                Color[] icon_list = icon.GetPixels();



                drawable_texture.SetPixels(0, 0, 1000, 750, icon_list);


                drawable_texture.Apply();

                GetComponent<Renderer>().material.mainTexture = drawable_texture;
            }
            if(Input.GetMouseButtonUp(0))
            {
                icounter = 1;
            }
            Vector2 Undopoisition = WorldToPixelCoordinates(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if ( menu.activeSelf == false)
            {
                if (Input.GetMouseButtonUp(0) && Undopoisition.x >= 0 && Undopoisition.x <= drawable_texture.width && Undopoisition.y >= 0 && Undopoisition.y <= drawable_texture.height)
                {
                    if (count_undo < 3)
                    {
                        count_undo++;
                    }
                    Undo[1].SetPixels(0, 0, 1000, 750, drawable_texture.GetPixels());
                    Undo[1].Apply();
                    for (int i = 0; i < Undo.Length; i++)
                    {


                        if (i == 0)
                        {
                            biendao = Undo[i];
                            Undo[i] = Undo[i + 1];
                        }
                        else if (i == Undo.Length - 1)
                        {
                            Undo[i] = biendao;

                        }
                        else
                        {
                            Undo[i] = Undo[i + 1];
                        }

                    }


                }
            }
            
        }

        private void FixedUpdate()
        {
           
            int a = 0;
            foreach (Transform childP in ScrollViewpath.transform)
            {
                if (childP.GetComponent<SelectedPath>().isSelected == true && is_bool == true)
                {
                    a++;
                    Style_paint = Paint_style.is_paste_icon;
                }
            } if (a != 0)
            {
                if (Input.GetMouseButton(0) && Style_paint == Paint_style.is_paste_icon)
                {
                   
                    if (icounter == 1)
                    {
                        Vector2 mouse_world_position_icon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        //RaycastHit2D hit = Physics2D.Raycast(mouse_world_position_bucket, Vector2.zero);
                        Collider2D hit = Physics2D.OverlapPoint(mouse_world_position_icon, Drawing_Layers.value);

                        if (!hit)
                        {
                            return;
                        }

                        SpriteRenderer rend = hit.transform.GetComponent<SpriteRenderer>();
                        BoxCollider2D meshCollider = hit as BoxCollider2D;

                        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                        {
                            return;
                        }

                        Texture2D tex = rend.material.mainTexture as Texture2D;
                        Vector2 pixelUV = WorldToPixelCoordinates(mouse_world_position_icon);
                        //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Pen_Colour);
                        int num_X = (int)pixelUV.x;
                        int num_Y = (int)pixelUV.y;

                        int w_pointer = icon.width;
                        int h_pointer = icon.height;
                        int x_pointer = num_X - (w_pointer / 2);
                        int y_pointer = num_Y - (h_pointer / 2);

                        int default_x_point = x_pointer;

                        int w_counter = 1;

                        Color[] icon_list = icon.GetPixels();

                        for (int i = 0; i < icon_list.Length; i++)
                        {
                            if (icon_list[i].a != 0)
                            {
                                tex.SetPixel(x_pointer, y_pointer, icon_list[i]);
                            }

                            if (w_counter == w_pointer)
                            {
                                x_pointer = default_x_point;
                                y_pointer++;
                                w_counter = 1;
                            }
                            else if (w_counter != w_pointer)
                            {
                                x_pointer++;
                                w_counter++;
                            }

                        }

                        tex.Apply();

                        GetComponent<Renderer>().material.mainTexture = tex;
                        icounter++;
                        
                    }
                }
                if(Style_paint == Paint_style.is_paste_icon)
                {
                    //di chuyen theo chuot
                    iconselected.transform.position = Input.mousePosition;
                }
            }
            if(Style_paint != Paint_style.is_paste_icon)
            {
                //alpha = 0 khi bam nut
                iconselected.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
        }

        public void Bucket_change()
        {

            is_bool = false;
            Style_paint = Paint_style.is_bucket;

        }

        public void Brush_change()
        {
            is_bool = false;

            Style_paint = Paint_style.is_brush;
        }

        // Set the colour of pixels in a straight line from start_point all the way to end_point, to ensure everything inbetween is coloured
        public void ColourBetween(Vector2 start_point, Vector2 end_point, int width, Color color)
        {
            // Get the distance from start to finish
            float distance = Vector2.Distance(start_point, end_point);
            Vector2 direction = (start_point - end_point).normalized;

            Vector2 cur_position = start_point;

            // Calculate how many times we should interpolate between start_point and end_point based on the amount of time that has passed since the last update
            float lerp_steps = 1 / distance;

            for (float lerp = 0; lerp <= 1; lerp += lerp_steps)
            {
                cur_position = Vector2.Lerp(start_point, end_point, lerp);
                MarkPixelsToColour(cur_position, width, color);
            }
        }





        public void MarkPixelsToColour(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
        {
            // Figure out how many pixels we need to colour in each direction (x and y)
            int center_x = (int)center_pixel.x;
            int center_y = (int)center_pixel.y;
            //int extra_radius = Mathf.Min(0, pen_thickness - 2);

            for (int x = center_x - pen_thickness; x <= center_x + pen_thickness; x++)
            {
                // Check if the X wraps around the image, so we don't draw pixels on the other side of the image
                if (x >= (int)drawable_sprite.rect.width || x < 0)
                    continue;

                for (int y = center_y - pen_thickness; y <= center_y + pen_thickness; y++)
                {
                    MarkPixelToChange(x, y, color_of_pen);
                }
            }
        }
        public void MarkPixelToChange(int x, int y, Color color)
        {
            // Need to transform x and y coordinates to flat coordinates of array
            int array_pos = y * (int)drawable_sprite.rect.width + x;

            // Check if this is a valid position
            if (array_pos > cur_colors.Length || array_pos < 0)
                return;

            cur_colors[array_pos] = color;
        }
        public void ApplyMarkedPixelChanges()
        {
            drawable_texture.SetPixels32(cur_colors);
            drawable_texture.Apply();
        }


        // Directly colours pixels. This method is slower than using MarkPixelsToColour then using ApplyMarkedPixelChanges
        // SetPixels32 is far faster than SetPixel
        // Colours both the center pixel, and a number of pixels around the center pixel based on pen_thickness (pen radius)
        public void ColourPixels(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
        {
            // Figure out how many pixels we need to colour in each direction (x and y)
            int center_x = (int)center_pixel.x;
            int center_y = (int)center_pixel.y;
            //int extra_radius = Mathf.Min(0, pen_thickness - 2);

            for (int x = center_x - pen_thickness; x <= center_x + pen_thickness; x++)
            {
                for (int y = center_y - pen_thickness; y <= center_y + pen_thickness; y++)
                {
                    drawable_texture.SetPixel(x, y, color_of_pen);
                }
            }

            drawable_texture.Apply();
        }


        public Vector2 WorldToPixelCoordinates(Vector2 world_position)
        {
            // Change coordinates to local coordinates of this image
            Vector3 local_pos = transform.InverseTransformPoint(world_position);

            // Change these to coordinates of pixels
            float pixelWidth = drawable_sprite.rect.width;
            float pixelHeight = drawable_sprite.rect.height;
            float unitsToPixels = pixelWidth / drawable_sprite.bounds.size.x * transform.localScale.x;

            // Need to center our coordinates
            float centered_x = local_pos.x * unitsToPixels + pixelWidth / 2;
            float centered_y = local_pos.y * unitsToPixels + pixelHeight / 2;

            // Round current mouse position to nearest pixel
            Vector2 pixel_pos = new Vector2(Mathf.RoundToInt(centered_x), Mathf.RoundToInt(centered_y));

            return pixel_pos;
        }


        // Changes every pixel to be the reset colour
        public void ResetCanvas()
        {
            drawable_texture.SetPixels(clean_colours_array);
            drawable_texture.Apply();
        }


        
        void Awake()
        {
            drawable = this;
            // DEFAULT BRUSH SET HERE
            current_brush = PenBrush;
            //load picture
            LoadPicture = Resources.LoadAll<Texture2D>("Paint/");
            for (int i = 0; i < LoadPicture.Length; i++)
            {
                var picture = Instantiate(SVimage,ScrollView.transform);
                picture.GetComponent<Selected>().selectedTxture = LoadPicture[i];
                picture.transform.GetChild(0).GetComponent<RawImage>().texture = LoadPicture[i];
            }
            //load path
            LoadPath= Resources.LoadAll<Texture2D>("PathPaint/");
            for (int j = 0; j < LoadPath.Length; j++)
            {
                var picture1 = Instantiate(SVimagePath, ScrollViewpath.transform);
                picture1.GetComponent<SelectedPath>().selectedTxture = LoadPath[j];
                picture1.transform.GetChild(0).GetComponent<RawImage>().texture = LoadPath[j];
            }
            //
            drawable_sprite = this.GetComponent<SpriteRenderer>().sprite;
            drawable_texture = drawable_sprite.texture;
           // Undo[0] = drawable_texture;

            // Initialize clean pixels to use
            clean_colours_array = new Color[(int)drawable_sprite.rect.width * (int)drawable_sprite.rect.height];
            for (int x = 0; x < clean_colours_array.Length; x++)
                clean_colours_array[x] = Reset_Colour;

            // Should we reset our canvas image when we hit play in the editor?
            if (Reset_Canvas_On_Play)
                ResetCanvas();
            for (int i = 0;i< Undo.Length ; i++)
            {
                Undo[i].SetPixels(0, 0, 1000, 750, drawable_texture.GetPixels());
                Undo[i].Apply();
            }

        }
        public void LoadImage()
        {
            int i =0;
            foreach (Transform child in ScrollView.transform)
            {
                if(child.GetComponent<Selected>().isSelected == true)
                {
                    i++;
                }
            }if(i !=0)
            { //LOad
                Color[] icon_list = icon.GetPixels();

                drawable_texture.SetPixels(0, 0, 1000, 750, icon_list);
                drawable_texture.Apply();

                GetComponent<Renderer>().material.mainTexture = drawable_texture;
                GameObject.Find("Select-menu").SetActive(false);
            }
        }

       
        public void UndoTexture()
        {
            if (count_undo > 0)
            {
                drawable_texture.SetPixels(0, 0, 1000, 750, Undo[Undo.Length - 1].GetPixels());
                drawable_texture.Apply();
                for (int i = 0; i < Undo.Length; i++)
                {


                    if (i == 0)
                    {
                        biendao = Undo[i];
                        Undo[i] = Undo[Undo.Length - 1];
                    }
                    else
                    {
                        biendao2 = Undo[i];
                        Undo[i] = biendao;
                        biendao = biendao2;

                    }

                }
                count_undo--;
            }

           
        }
    }
}