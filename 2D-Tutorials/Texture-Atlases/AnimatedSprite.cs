using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Texture_Atlases
{
    public class AnimatedSprite {
        public Texture2D Texture { get; set; }  // stores texture atlas
        public int Rows { get; set; }           // number of rows in texture atlas
        public int Columns { get; set; }        // number of columns in atlas
        private int currentFrame;               // current frame of animation
        private int totalFrames;                // total number of frames

        // constructor
        public AnimatedSprite(Texture2D texture, int rows, int columns) {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = rows * columns;
        }

        // increments frame and starts over if needed
        public void Update() {
            currentFrame++;
            if (currentFrame >= totalFrames) {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            // determines which part of texture needs to be drawn for current frame
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            // creates rectangle within the the texture that we want to draw
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            // rectangle that represents where texture will be drawn
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            // draws only part of the texture used in current frame
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
