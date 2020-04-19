using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    
    
    public class Interaction
    {
        public enum RESPONSIBLE_ENTITY { PLAYER, PRINCESS, STORYTELLER, ENDSHIELD, START_GAME }
        public RESPONSIBLE_ENTITY responsibility = RESPONSIBLE_ENTITY.PLAYER;
        public string text = "";

        public Interaction(RESPONSIBLE_ENTITY responsibility, string text)
        {
            this.responsibility = responsibility;
            this.text = text;
        }
    }
}
