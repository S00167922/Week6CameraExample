using CameraNS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week6Lab1
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera cam;
        private Texture2D background;
        MouseState previousMouseState;
        float camSpeed = 10f;
        float maxMouseSpeed = 20f;

        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 780;
            graphics.ApplyChanges();
            
            IsMouseVisible = true;
            Mouse.SetPosition(0, 0);
            previousMouseState = Mouse.GetState();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Background");
            cam = new Camera(Vector2.Zero,
                new Vector2(background.Bounds.Width, background.Height));
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mState = Mouse.GetState();

            if(GraphicsDevice.Viewport.Bounds.Contains(mState.Position))
            {
                // Attempt a mouse move Camera. As long as speed exceeds world size when applied 
                // You can always be more sensitive with the mouse move
                if (mState.Position != previousMouseState.Position)
                    cam.move((mState.Position.ToVector2() - previousMouseState.Position.ToVector2()) * maxMouseSpeed,
                            GraphicsDevice.Viewport);
            }
            previousMouseState = mState;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cam.move(new Vector2(1, 0) * camSpeed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cam.move(new Vector2(-1, 0) * camSpeed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cam.move(new Vector2(0, 1) * camSpeed, GraphicsDevice.Viewport);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cam.move(new Vector2(0,-1) * camSpeed, GraphicsDevice.Viewport);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, cam.CurrentCameraTranslation);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
