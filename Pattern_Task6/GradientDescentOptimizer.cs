using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Task6
{
    class GradientDescentOptimizer
    {

        Dictionary<double, double> points = new Dictionary<double, double>();  //table of points x, F(x),U(x)
        List<double> fxParamters = new List<double>();
        List<double> uxParamters = new List<double>();
        List<double> ux = new List<double>();
        int num_of_points;
        Random x = new Random();
        double oldError;
        double errorDiff;
        double alpha;
        double epslon = 0.001;
        //Constuctor
        public GradientDescentOptimizer()
        {

        }

        public GradientDescentOptimizer(List<double> para, double alpha, double errorDiff, int pointsNum)
        {
            this.fxParamters.AddRange(para);
            this.num_of_points = pointsNum;
            for (int i = 0; i < fxParamters.Count; i++)
            {
                this.uxParamters.Add(x.Next(-50, 50));
            }

            this.alpha = alpha;
            this.errorDiff = errorDiff;

            for (int i = 0; i < pointsNum; i++)
            {
                ux.Add(0.0);
            }
        }

        public void generatePoints(int num_of_points, double start, double end)
        {
            double X, fx;
            int i = 0;
             FileStream fs = new FileStream("simple case.txt", FileMode.Open, FileAccess.Read);
                var streamReader = new StreamReader(fs);
                string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                //X = x.NextDouble() * (end - start) + start; ;
                string[] lineData = line.Split(' ');
                X = Convert.ToDouble(lineData[0]);
                fx = Convert.ToDouble(lineData[1]);
                if (!points.ContainsKey(X))
                {
                   // //calculate f(x)
                   // fx = 0.0;
                   // for (int j = 0; j < this.fxParamters.Count; j++)
                   // {
                   //     fx += Math.Pow(X, this.fxParamters.Count - (j + 1)) * fxParamters[j];
                   // }
                   
                   //// fx += this.fxParamters[fxParamters.Count - 1]*x.Next(1,num_of_points);
                   //// fx += x.NextDouble();
                   // fx += this.fxParamters[fxParamters.Count - 1]*X;
                    
                    points.Add(X,fx);
                    i++;
                }

            }

            

        }

        public void generateThetas()
        {
            int c = 0;

            double sum = 0.0;
            double Error = 0.0;
            double[] thetas = new double[this.uxParamters.Count];
            double[] dervErrorThetas = new double[this.uxParamters.Count];

            //set initial thetas
            for (int i = 0; i < thetas.Length; i++)
            {
                thetas[i] = uxParamters[i];
            }

            while (this.errorDiff > this.epslon)
            {
                c++;


                for (int i = 0; i < num_of_points; i++)
                {
                    sum = 0.0;
                    for (int j = 0; j < thetas.Length; j++)
                    {
                        sum += Math.Pow(points.Keys.ElementAt(i), thetas.Length - (j + 1)) * thetas[j];
                    }
                    ux[i] = sum;
                }




                // derivative thetas 
                for (int i = 0; i < dervErrorThetas.Length; i++)
                {
                    sum = 0.0;
                    for (int j = 0; j < num_of_points; j++)
                    {
                        sum += (ux[j] - points.Values.ElementAt(j)) * Math.Pow(points.Keys.ElementAt(j), dervErrorThetas.Length - (i + 1));
                    }
                    sum /= num_of_points;
                    dervErrorThetas[i] = sum;
                }

                //set new thetas
                for (int i = 0; i < thetas.Length; i++)
                {
                    thetas[i] = thetas[i] - alpha * dervErrorThetas[i];
                }

                sum = 0.0;
                for (int i = 0; i < num_of_points; i++)
                {
                    sum += Math.Pow(ux[i] - points.Values.ElementAt(i), 2);
                }

                Error = (sum / num_of_points) * 0.5;
                errorDiff = Math.Abs(Error - oldError);
                oldError = Error;


            }



        }
    }
}
