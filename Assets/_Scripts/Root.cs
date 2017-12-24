using strange.extensions.context.impl;

namespace Example
{
    public class Root : ContextView
    {
        void Awake()
        {
            context = new MainContext(this);
        }
    }
}