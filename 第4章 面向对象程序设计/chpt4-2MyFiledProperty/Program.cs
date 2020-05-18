using System;
using System.Collections.Generic;
using System.Text;

namespace chpt4_2MyFiledProperty
{
    class Ball
    {
        public const double pi = System.Math.PI;        //定义常量
        private double r;                               //定义私有非静态字段
        public double R //定义属性R
        {
            //get
            //{
            //    return r;
            //}
            set //set具有一个隐式参数value，不要问value哪里来的啦！value等于R传进来的参数
            {
                if (value < 0) { r = 0; }
                else { r = value; }
            }
        }

        public double BallVolume            //定义只读属性BallVolume；因为没有set所以是只读？
        {
            get
            {
                return 4.0 / 3.0 * pi * r * r * r;  //计算球体体积
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "chpt4-2";

            double v;   //声明球体体积v
            Ball ball = new Ball();             //声明并实例化对象ball

            Console.WriteLine("请输入球的半径");
            ball.R = Convert.ToDouble(Console.ReadLine());  //读入球体半径，将半径值传给R
            v = ball.BallVolume;    //调用BallVolume函数，计算球体体积,BallVoluem会利用get将值返回给v

            Console.WriteLine("球的体积为：{0:F4}", v);
            Console.ReadLine();

        }
    }
}
