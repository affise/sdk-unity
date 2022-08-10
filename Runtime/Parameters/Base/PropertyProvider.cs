namespace AffiseAttributionLib.AffiseParameters.Base
{
    public abstract class PropertyProvider<T>
    {
        abstract public T DefaultValue { get; }

        abstract public T Provide();

        public T ProvideWithDefault()
        {
            return Provide() ?? DefaultValue;
        }
    }

    public abstract class StringPropertyProvider : PropertyProvider<string>
    {
        public override string DefaultValue => "";
    }
    
    public abstract class BooleanPropertyProvider : PropertyProvider<bool>
    {
        public override bool DefaultValue => false;
    }
    
    public abstract class LongPropertyProvider : PropertyProvider<long?>
    {
        public override long? DefaultValue => 0L;
    }

    public abstract class StringWithParamPropertyProvider
    {
        private string DefaultValue = "";

        abstract public string ProvideWithParam(string param);

        public string ProvideWithParamAndDefault(string param) => ProvideWithParam(param) ?? DefaultValue;
    }
}