namespace NQuery.Generator.Sample
{
    public partial class SampleView : BaseView
    {
        [Query("path")]
        public VisualElement Element { get; private set; } = null!;

        public ChildView ChildView1;

        protected SampleView(UIDocument uiDocument)
            : base(uiDocument)
        {
            ChildView1 = AddAsChild(
                new ChildView(uiDocument, WithSubPathRelativeParent("hello"))
            );
        }
    }
}
