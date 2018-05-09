using Microsoft.ML;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;

namespace MLCore
{
    /// <summary>
    /// 源码参考自dotNet跨平台公众号之.NET CORE玩转机器学习
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //step2:创建一个管道并且加载你的数据
            var pipeline = new LearningPipeline();
            string dataPath = "SourceData/iris-data.txt";
            var loaderData = new TextLoader<IrisData>(dataPath, separator: ",");
            pipeline.Add(loaderData);

            //step3:转换数据
            //因为在模型训练的时候只能处理数字，所以在Label列中将数值分配给文本
            var dictionarizer = new Dictionarizer("Label");
            pipeline.Add(dictionarizer);
            var concatenator = new ColumnConcatenator("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth");
            pipeline.Add(concatenator);

            //step4:添加学习者
            //添加一个学习算法到管道中，这是一种分类方案（这是什么类型的Iris）
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            //在步骤三转换为数字之后将Label转换回原始文本
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            //step5:根据数据集来训练模型
            var model = pipeline.Train<IrisData, IrisPrediction>();

            var prediction = model.Predict(new IrisData()
            {
                SepalLength = 10.8f,
                SepalWidth = 5.1f,
                PetalLength = 2.55f,
                PetalWidth = 0.3f
            });
            Console.WriteLine($"Predicted flower type is {prediction.PredictedLabels}");
            Console.Read();
        }
    }

    //step1:定义一个数据结构
    //irisData 用来提供样本学习数据（与/sourceData/Iris-data.txt对应），并用作预测操作的输入
    //前四个属性用于预测Label的输入或特征
    //Label是预测的内容，仅在学习的时候设置
    public class IrisData
    {
        [Column("0")]
        public float SepalLength;

        [Column("1")]
        public float SepalWidth;

        [Column("2")]
        public float PetalLength;

        [Column("3")]
        public float PetalWidth;

        [Column("4")]
        public string Label;
    }

    //IrisPrediction 是预测操作返回的结果
    public class IrisPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
