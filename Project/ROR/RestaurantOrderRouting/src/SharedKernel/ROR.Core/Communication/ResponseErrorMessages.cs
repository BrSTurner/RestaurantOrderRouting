using System.Collections.Generic;

namespace ROR.Core.Communication
{
    public class ResponseErrorMessages
    {
        public List<string> Messages { get; set; }
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }
    }
}
