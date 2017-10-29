using ConnectDataBase;
namespace ChainOfResponsibility
{
    internal class TranslateAny : Translate
    {
     

        public override string GetTranslate(Request request)
        {
            // szukam dowonlengo tłumaczenia w bazie
            string translateAny = DB.FindAnyTranslate(request.Code);

            if(string.IsNullOrEmpty(translateAny))
            {
                return null;
            }
            else
            {
                return translateAny;
            }
        }
    }
}