using System;
using System.Collections.Generic;
using System.Text;


namespace ChainOfResponsibility
{
   abstract class Translate
    {
        public abstract string GetTranslate(Request request);
    }
}
