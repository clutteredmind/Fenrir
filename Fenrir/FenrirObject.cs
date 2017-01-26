//-----------------------------------------------------------------------
// <copyright file = "FenrirObject.cs" company = "Me!">
//     Copyright (c) Me!  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Fenrir
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FenrirObject
    {
        /// <summary>
        /// The position of this object
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The texture of this object
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Creates a new FenrirObject with the specified texture
        /// </summary>
        /// <param name="texture">The texture that the object should use</param>
        public FenrirObject(Texture2D texture)
        {
            Texture = texture;
        }

        /// <summary>
        /// The rectangle that represents this object's bounds
        /// </summary>
        public Rectangle ObjectRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }

        /// <summary>
        /// Indicates whether or not this object has collided with another FenrirObject
        /// </summary>
        /// <param name="otherObject">The other object to check for a collision</param>
        /// <returns>True if the two objects' rectangles overlap, otherwise false</returns>
        public bool HasCollidedWith(FenrirObject otherObject)
        {
            return ObjectRectangle.Intersects(otherObject.ObjectRectangle);
        }
    }
}
