namespace AffiseAttributionLib.Converter
{
    public interface IConverter<in T, out TR>
    {
        TR Convert(T from);
    }
}