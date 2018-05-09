using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;

namespace CommandLine
{
    class Program
    {
        //打包成可执行exe文件命令：dotnet publish -c release -r win10-x64，可以使用cat -h
        //正常发布会生成dll文件，使用命令dotnet cat.dll -h
        //不想使用dotnet命令运行，可以新建一个bat文件
        static void Main(string[] args)
        {
            //初始化一个命令行应用程序，设置命令名称
            var app = new CommandLineApplication(true)
            {
                Name = "CommandLine",
                Description = "output text file"
            };

            //注册帮助命令，也可以使用其他字符
            app.HelpOption("-h|--help");

            //注册参数
            app.Argument("path", "file path will be output", false);

            //注册选项1
            app.Option("-c|--count", "the file's line count wille be output", CommandOptionType.SingleValue);

            //注册选项2
            app.Option("-s|--sameline", "ouptut all content in the same line", CommandOptionType.SingleValue);

            //运行命令需要执行的代码
            app.OnExecute(() =>
            {
                return CommandExecuter(app);
            });

            app.Execute(args);
            Console.Read();
        }

        static int CommandExecuter(CommandLineApplication app)
        {
            var count_option = app.Options.Find(x => x.ShortName == "c");
            var sameline_option = app.Options.Find(x => x.ShortName == "s");
            int? count = null;
            bool? sameLine = null;
            if (count_option.HasValue())
            {
                int.TryParse(count_option.Value(), out int count_);
                count = count_;
            }
            if (sameline_option.HasValue())
            {
                bool.TryParse(sameline_option.Value(), out bool sameLine_);
                sameLine = sameLine_;
            }

            var path = app.Arguments.Find(x => x.Name == "path").Value;
            if (string.IsNullOrWhiteSpace(path))
                return 0;

            var fullPath = Path.IsPathRooted(path) ? path : Path.Combine(AppContext.BaseDirectory, path);

            if (!File.Exists(fullPath))
            {
                app.Out.WriteLine($"cat:[{path}] is a invalid path");
                return 0;
            }

            var file = new FileInfo(fullPath);
            using (var reader=new StreamReader(file.OpenRead()))
            {
                int curLineIndex = 0;
                while (!count.HasValue || curLineIndex < count.Value)
                {
                    var content = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        break;
                    }
                    if (sameLine.HasValue && sameLine.Value)
                    {
                        app.Out.Write(content);
                    }
                    else
                    {
                        app.Out.WriteLine(content);
                    }
                    curLineIndex++;
                }
            }

            return 0;
        }
    }
}
