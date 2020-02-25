﻿using AbsenceHelper.Models;

using CsvHelper;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AbsenceHelper.Helpers
{
    public static class Deserializer
    {
        public static List<AbsenceData> GetCsvList()
        {
            using var reader = new StreamReader($"{GetPath()}{Resource.CSVFile}");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.Delimiter = ";";
            var data = csv.GetRecords<StartData>().ToList();

            return data.Select(Mapper.Mapper.MapStartDataToAbsenceData).ToList();
        }

        public static List<Data> GetXmlLists()
        {
            var xmlList = new List<Data>
            {
                DeserializeXML(Resource.XMLFileA),
                DeserializeXML(Resource.XMLFileB)
            };

            return xmlList.OrderBy(d => Convert.ToDateTime(d.FileDate).Date).ToList();
        }

        private static Data DeserializeXML(string xmlFile)
        {
            var serializer = new XmlSerializer(typeof(Data));
            using var reader = new FileStream($"{GetPath()}{xmlFile}", FileMode.Open);
            var data = (Data)serializer.Deserialize(reader);

            return data;
        }

        private static string GetPath()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
