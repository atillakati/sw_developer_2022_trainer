namespace AbstrakteDatentypen
{
    internal abstract class Shape : IPrintable
    {		
		public abstract string Name { get; }
					
        public abstract string GetInfos();

        public abstract void Draw();

        public abstract void Print();        
    }

    //internal interface IShape
    //{
    //   string Name { get; }

    //   string GetInfos();
       
    //   void Draw();
    //}
}