using static VisitorPatternDependencies.Classes;

namespace VisitorPatternDependencies
{
    public class Interfaces
    {
        public interface IVisitor
        {
            public void VisitMenuItem(MenuItem item);

            public void VisitMenu(Menu menu);
        }
    }
}
