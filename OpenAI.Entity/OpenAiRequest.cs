using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Entity
{
    public class OpenAiRequest
    {
        public string Prompt { get; set; }
        public string Model { get; set; }
        public int MaxTokens { get; set; }
        public double Temperature { get; set; }
    }
}
