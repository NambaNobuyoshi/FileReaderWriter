using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite.Domains
{
    internal interface IFileWriter
    {
        /// <summary>
        /// C#オブジェクトをファイルに書き込む
        /// </summary>
        /// <typeparam name="T">シリアライズするC#オブジェクト</typeparam>
        /// <param name="content">シリアライズするC#オブジェクト</param>
        public void Write<T>(string filepath, T content);
    }
}
