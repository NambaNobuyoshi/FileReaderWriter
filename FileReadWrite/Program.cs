﻿


using FileReadWrite.Domains;
using System.Runtime.CompilerServices;

// XMLReadWrite_Test
try
{
    // @@TEST : 初期化
    //XmlSampleObjectAccessor.InitSample();

    //ファイルを読み取り、表示。
    Console.WriteLine("---------- 読み取り開始 ----------");
    var xmlSample = XmlSampleObjectAccessor.GetSample();
    if ( xmlSample != null)
    {
        foreach(var sample in xmlSample.books)
        {
            Console.WriteLine("id :" + sample.id + ",title : " + sample.title + ", publisher : " + sample.publisher);
        }
    }
    Console.WriteLine("---------- 読み取り終了 ----------");


    // 中身を編集して、書き込む
    xmlSample.books[0].title = "編集後タイトル";

    Console.WriteLine("---------- 編集後読み取り開始 ----------");
    if (xmlSample != null)
    {
        foreach (var sample in xmlSample.books)
        {
            Console.WriteLine("id :" + sample.id + ",title : " + sample.title + ", publisher : " + sample.publisher);
        }
    }
    Console.WriteLine("---------- 編集後読み取り終了 ----------");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

