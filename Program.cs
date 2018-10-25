using System;
using System.Collections.Generic;
using ConsoleApp1.Model;
using System.Xml;
using XMLFunction;
using System.Linq;
using ConsoleApp1.Repository;
using ConsoleApp1.Service;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Variable
            XmlDocument doc = new XmlDocument();
            List<XmlElement> allElement = new List<XmlElement>();
            List<StockInfo> stockInfoList = new List<StockInfo>();
            List<string> attribute = new List<string>();
            XMLProcessingcs xmlProcess = new XMLProcessingcs();
            StockInfoRepository stockInfoRepository;
            #endregion
            XMLFunction.XMLFunction.LoadData(doc, @"https://quality.data.gov.tw/dq_download_xml.php?nid=11371&md5_url=0c464d1eb14d4fb0045eebc1052d5f24");
            allElement = XMLFunction.XMLFunction.getAllElement(doc);
            stockInfoList = xmlProcess.processValue(allElement);
            attribute  = xmlProcess.processAttribute(allElement[0]);
            showStockInfo(attribute, stockInfoList);
            showDateCount(stockInfoList);
            stockInfoRepository = new StockInfoRepository();
            stockInfoRepository.Insert(stockInfoList[0]);
            stockInfoList.ForEach(StockInfo =>
            {
                stockInfoRepository.Insert(StockInfo);
            });
            Console.WriteLine("儲存完畢!");
            Console.ReadKey();

        }

        static void showStockInfo(List<string> attributList, List<StockInfo> infoList)
        {
            Console.WriteLine("Total Amount of Data = {0}", infoList.Count);
            infoList.ForEach(stockInfo =>
            {
                Console.WriteLine("{0}: {1}", attributList[0], stockInfo.Date);
                Console.WriteLine("{0}: {1}", attributList[1], stockInfo.ID);
                Console.WriteLine("{0}: {1}", attributList[2], stockInfo.Name);
                Console.WriteLine("{0}: {1}", attributList[3], stockInfo.Close);
                Console.WriteLine("{0}: {1}", attributList[4], stockInfo.AdvanceDeclin);
                Console.WriteLine("{0}: {1}", attributList[5], stockInfo.Open);
                Console.WriteLine("{0}: {1}", attributList[6], stockInfo.Dayhigh);
                Console.WriteLine("{0}: {1}", attributList[7], stockInfo.Daylow);
                Console.WriteLine("{0}: {1}", attributList[8], stockInfo.TotalStockVolume);
                Console.WriteLine("{0}: {1}", attributList[9], stockInfo.TotalDollarCount);
                Console.WriteLine("{0}: {1}", attributList[10], stockInfo.TotalCount);
                Console.WriteLine("{0}: {1}", attributList[11], stockInfo.LastBuying);
                Console.WriteLine("{0}: {1}", attributList[12], stockInfo.LastSelling);
                Console.WriteLine("{0}: {1}", attributList[13], stockInfo.PulishStockCount);
                Console.WriteLine("{0}: {1}", attributList[14], stockInfo.LimitUpPrice);
                Console.WriteLine("{0}: {1}", attributList[15], stockInfo.LimitDownPrice);
                Console.WriteLine("\n\n");
            });
        }

        static void showDateCount(List<StockInfo> infoList)
        {
            infoList.GroupBy(data => data.Date).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupData = group.ToList();
                    var message = $"日期: {key}, 共有{group.Count()}筆資料";
                    Console.WriteLine(message);
                });
        }
    
    }
}
//ass 