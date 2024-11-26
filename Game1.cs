using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _playerTexture;
        private Vector2 _playerPosition;
        private float _playerSpeed = 100f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set the window size
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            // Set initial player position
            _playerPosition = new Vector2(400, 300);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a simple texture for the player (a white square)
            _playerTexture = new Texture2D(GraphicsDevice, 50, 50);

            // Fill the texture with a color (e.g., white)
            Color[] data = new Color[50 * 50];
            for (int i = 0; i < data.Length; i++) data[i] = Color.White;
            _playerTexture.SetData(data);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get the keyboard state
            var keyboardState = Keyboard.GetState();

            // Handle player movement
            if (keyboardState.IsKeyDown(Keys.Up))
                _playerPosition.Y -= _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Down))
                _playerPosition.Y += _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Left))
                _playerPosition.X -= _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Right))
                _playerPosition.X += _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Begin drawing
            _spriteBatch.Begin();

            // Draw the player (a white square)
            _spriteBatch.Draw(_playerTexture, _playerPosition, Color.Red);

            // End drawing
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
