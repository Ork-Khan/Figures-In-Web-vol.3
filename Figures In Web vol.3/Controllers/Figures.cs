using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Serialized_Shapes_2._0;
using Serialized_Shapes_2._0.Figures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Figures_In_Web_vol._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Figures : ControllerBase
    {
        LinkedList<Figure> figures = new LinkedList<Figure>();
        string Path = @"FigureDataBase.json";
        // GET: api/<Figures>
        [HttpGet]
        public string Get()
        {
            Jason.DeJasonize(Path,ref figures);
            string result = "";
            foreach (Figure f in figures)
                result += f.ToString()+" ";
            return result;
        }

        // GET api/<Figures>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Jason.DeJasonize(Path, ref figures);
            return figures.ElementAt(id).ToString();
        }

        // POST api/<Figures>
        [HttpPost("Post Circle")]
        
        public void PostCirc(double X0, double Y0, double X1, double Y1)
        {
            LinkedList<Point> Ps = new LinkedList<Point>();
            Point P0 = new Point(X0, Y0);
            Ps.AddLast(P0);
            Point P1= new Point(X1, Y1);
            Ps.AddLast(P1);
            Circle circle = new Circle(Ps);
            if(new FileInfo(Path).Length!=0)
                Jason.DeJasonize(Path, ref figures);
            figures.AddLast(circle);
            Jason.Jasonize(Path, figures);
        }
        [HttpPost("Post Triangle")]
        public void PostTri(double X0, double Y0, double X1, double Y1, double X2, double Y2)
        {
            LinkedList<Point> Ps = new LinkedList<Point>();
            Point P0 = new Point(X0, Y0);
            Ps.AddLast(P0);
            Point P1 = new Point(X1, Y1);
            Ps.AddLast(P1);
            Point P2 = new Point(X2, Y2);
            Ps.AddLast(P2);
            Triangle triangle=new Triangle(Ps);
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            figures.AddLast(triangle);
            Jason.Jasonize(Path, figures);
        }
        [HttpPost("Post Rectangle")]
        public void PostRect(double X0, double Y0, double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            LinkedList<Point> Ps = new LinkedList<Point>();
            Point P0 = new Point(X0, Y0);
            Ps.AddLast(P0);
            Point P1 = new Point(X1, Y1);
            Ps.AddLast(P1);
            Point P2 = new Point(X2, Y2);
            Ps.AddLast(P2);
            Point P3 = new Point(X3, Y3);
            Ps.AddLast(P3);
            Rectangle rectangle = new Rectangle(Ps);
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            figures.AddLast(rectangle);
            Jason.Jasonize(Path, figures);
        }

        // PUT api/<Figures>/5
        [HttpPut("Scale")]
        public void PutScale(int id, double ScaleParam)
        {
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            Figure f = figures.ElementAt(id);
            f.Scale(ScaleParam);
            Jason.Jasonize(Path, figures);
        }
        [HttpPut("Rotate")]
        public void PutRotate(int id, double RotationParam)
        {
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            Figure f = figures.ElementAt(id);
            f.Rotate(RotationParam);
            Jason.Jasonize(Path, figures);
        }
        [HttpPut("Move")]
        public void PutMove(int id,double x,double y)
        {
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            Figure f = figures.ElementAt(id);
            f.MoveBy(x,y);
            Jason.Jasonize(Path, figures);
        }
        // DELETE api/<Figures>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (new FileInfo(Path).Length != 0)
                Jason.DeJasonize(Path, ref figures);
            figures.Remove(figures.ElementAt(id));
            Jason.Jasonize(Path, figures);
        }
    }
}
