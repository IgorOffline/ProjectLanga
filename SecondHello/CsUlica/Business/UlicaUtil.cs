namespace CsUlica.Business;

public static class UlicaUtil
{
    public const string UlicaVariableDefaultName = "__default__";
    
    public static UlicaVariable UlicaVariableDefault()
    {
        return new UlicaVariable(UlicaType.Object, UlicaVariableDefaultName, null);
    }
}