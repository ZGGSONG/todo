using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TODO.Helper;

namespace TODO.ViewModel
{
    public class ViewModelHelper : SingletonMode<ViewModelHelper>, IDisposable
    {
        private const string CONST_CACHE_FILE_NAME = "todo_cache.dat";


        /// <summary>
        /// 
        /// </summary>
        public ViewModelHelper()
        {
            try
            {
                using (FileStream fs = new FileStream(@"C:\ProgramData\TODO\" + CONST_CACHE_FILE_NAME, FileMode.Open))
                {
                    ///序列化二进制
                    BinaryFormatter formatter = new BinaryFormatter();
                    var info = formatter.Deserialize(fs) as IMainViewModel;
                    MainViewModel = info;
                    Console.WriteLine("恢复成功");
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"恢复失败: {ex.Message}");
            }
            finally
            {

            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void Dispose()
        {
            var directoryPath = @"C:\ProgramData\TODO\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            FileStream fs = new FileStream(directoryPath + CONST_CACHE_FILE_NAME, FileMode.Create);
            ///序列化二进制
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, MainViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"缓存失败: {ex.Message}");
            }
            finally
            {
                fs.Close();
            }
        }


        public IMainViewModel MainViewModel;
    }

    public interface IMainViewModel
    {
        bool isLogin { get; }
    }
}
