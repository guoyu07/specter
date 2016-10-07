using NBehave.Narrator.Framework;
using System;

namespace Specter.Main
{
    internal class Actor
    {
        public string Run(string features)
        {
            try
            {
                features.ExecuteText();
                return "success";
            }
            catch(Exception e)
            {
                return e.Message;
            }            
        }
    }
}
