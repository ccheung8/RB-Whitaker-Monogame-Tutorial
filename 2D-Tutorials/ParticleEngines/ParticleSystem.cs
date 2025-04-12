using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleEngines {
    internal class ParticleSystem {
        private static Random random;                   // rng for generating particles
        public Vector2 EmitterLocation { get; set; }    // allows user to change location particles are originating at
        private List<Particle> particles;               // contains all particles currently active in particle system
        private List<Texture2D> textures;                // contains all textures available for use in particle system

        public ParticleSystem(List<Texture2D> textures, Vector2 location) {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }

        private Particle GenerateNewParticle() {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                1f * (float)(random.NextDouble() * 2 - 1),
                1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                (float)random.NextDouble(),
                (float)random.NextDouble(),
                (float)random.NextDouble());
            float size = (float)random.NextDouble();
            int ttl = 20 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Update() {
            // adds 10 new particles each time
            int total = 10;

            for (int i = 0; i < total; i++) {
                particles.Add(GenerateNewParticle());
            }

            // goes through list of particles and have them update themselves
            for (int particle = 0; particle < particles.Count; particle++) {
                particles[particle].Update();
                // removes dead particles
                if (particles[particle].TTL <= 0) {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            // additive blending
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            // iterates through particles and has them draw themselves
            for (int i = 0; i < particles.Count; i++) {
                particles[i].Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
