using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibSVMsharp.Extensions;
using LibSVMsharp.Helpers;
using LibSVMsharp;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            SVMProblem problem = SVMProblemHelper.Load(@"mod.txt");
            SVMProblem testProblem = SVMProblemHelper.Load(@"mod.txt");

            SVMParameter parameter = new SVMParameter();

            SVMModel model = problem.Train(parameter);

            double[] target = testProblem.Predict(model);
            double accuracy = testProblem.EvaluateClassificationProblem(target);

            SVM.SaveModel(model, @"mod_model.txt");

            Console.ReadKey();
        }
    }
}
