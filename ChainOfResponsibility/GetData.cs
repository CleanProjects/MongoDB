using System;
using ConnectDataBase;

namespace ChainOfResponsibility
{
    public class GetData
    {
        public string GetItems(string code, string lg)
        {
            string k = code;
            string l = lg;
            DB dB = new DB();
            SpecificTranslate st = new SpecificTranslate();

            string result = st.GetTranslate(new Request(code, lg));

            if(string.IsNullOrEmpty(result))
            {
                return "Translate isn't find";
            }
            else
            {
                return result;
            }

            //string t=      dB.FindTranslateEN(k);
        }
    }
 
}
