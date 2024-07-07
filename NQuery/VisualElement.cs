using System;

namespace NQuery
{
    public class VisualElement
    {
        public T Q<T>() where T : VisualElement
        {
            throw new NotImplementedException();
        }
    }
}