using strange.extensions.signal.impl;

namespace Example
{
    public class StartAppSignal : Signal { }
    public class ClickSignal : Signal<Vector3Box> { }
    public class ViewClickSignal : Signal<PrimitiveView> { }
    public class TimeElapsedSignal : Signal<PrimitiveView> { }
    public class OnViewCreatedSignal : Signal<PrimitiveView> { }
}