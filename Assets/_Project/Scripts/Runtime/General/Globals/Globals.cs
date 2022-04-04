namespace Rogue.General
{
    public static class Globals
    {
        #region VARIABLES

        /// <summary>
        /// Current Game Speed.
        /// </summary>
        public static int GameSpeed = 0;

        #endregion

        #region METHODS

        public static int ResumeGameSpeed()
        {
            GameSpeed = 1;
            return GameSpeed;
        }

        public static int PauseGameSpeed()
        {
            GameSpeed = 0;
            return GameSpeed;
        }

        #endregion
    }
}