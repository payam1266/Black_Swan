using System.Collections.Generic;

namespace Black_Swan_Application.Responses
{
    public class BaseCommandResponse
    {
        public int id { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
    }
}
