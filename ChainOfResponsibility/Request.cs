using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class Request
    {
        private string lg;

        public Request(string code, string lg)
        {
            this.Code = code;
            this.Language = lg;
        }

        public string Code { get; set; }
        public string Language { get; set; }
    }
}
