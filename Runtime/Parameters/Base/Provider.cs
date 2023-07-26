namespace AffiseAttributionLib.AffiseParameters.Base
{
    public abstract class Provider
    {
        public virtual float Order => 0.0f;
        public virtual string Key => null;
    }
}