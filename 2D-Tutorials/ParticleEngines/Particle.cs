using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleEngines {
    internal class Particle {
        public Texture2D Texture { get; set; }      // texture that will be drawn to represent particle
        public Vector2 Position { get; set; }       // current position of particle
        public Vector2 Velocity { get; set; }       // speed of particle at current instance
        public float Angle { get; set; }            // current angle of rotation of particle
        public float AngularVelocity { get; set; }  // speed that angle is changing
        public Color Color { get; set; }            // color of particle
        public float Size { get; set; }             // size of particle
        public int TTL {  get; set; }               // "time to live" of particle

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
                float angle, float angularVelocity, Color color, float size, int ttl) {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            TTL = ttl;
        }

        public void Update() {
            TTL--;  // moves particle one step closer to expiring
            Position += Velocity;   // updates position of particle by velocity
            Angle += AngularVelocity;   // updates angle by angularvelocity
        }

        public void Draw(SpriteBatch spriteBatch) {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            // begin() and end() are not called here
            // draws texture at position, scaled, rotated, colored, and placed
            spriteBatch.Draw(Texture, Position, sourceRectangle, Color, Angle, origin, Size, SpriteEffects.None, 0f);
        }
    }
}
