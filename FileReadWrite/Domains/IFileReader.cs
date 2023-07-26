using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite.Domains
{
    internal interface IFileReader
    {
        /// <summary>
        /// ファイルを読み取り、C#オブジェクトに変換する
        /// </summary>
        /// <typeparam name="T">C#オブジェクトのクラス</typeparam>
        /// <returns>デシリアライズされたC#オブジェクト</returns>
        public T Read<T>(string filePath);
    }
}
