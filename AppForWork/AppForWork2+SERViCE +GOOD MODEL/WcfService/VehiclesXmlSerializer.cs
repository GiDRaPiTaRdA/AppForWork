using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.Versioning;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
using Cars.Vehicles;

namespace WcfService
{
    public class VehiclesXmlSerializer
    {
        readonly XmlSerializer formatter;
        string XML_DATABASE_NAME { get; set; }

        public VehiclesXmlSerializer(string nameOfFile)
        {
             this.XML_DATABASE_NAME = nameOfFile;
             this.formatter = new XmlSerializer(typeof(SerializationContainer<List<Vehicle>>));
        }

        public void Serialize(List<Vehicle> vehicles)
        {
            using (FileStream fs = new FileStream(this.XML_DATABASE_NAME, FileMode.OpenOrCreate))
            {
                var toSerialize = new SerializationContainer<List<Vehicle>>(vehicles);
               
                this.formatter.Serialize(fs, toSerialize);
                //formatter.
            }
        }

        public string GetPath()
        {
            using (FileStream fs = new FileStream(this.XML_DATABASE_NAME, FileMode.OpenOrCreate))
               return fs.Name;
        }

        #region 
        public void Add(Vehicle vehicle)
        {
            List<Vehicle> temp = this.Desirialize();
            temp.Add(vehicle);
            this.Serialize(temp);
        }

        public List<Vehicle> Desirialize()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (FileStream fs = new FileStream(this.XML_DATABASE_NAME, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    try
                    {
                        var temp = (SerializationContainer<List<Vehicle>>)this.formatter.Deserialize(fs);
                        vehicles = temp.Data;
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                        throw e;
                    }
                }
            }
            return vehicles;
        }

        public void Clear()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this.XML_DATABASE_NAME);
            XmlNode xmlNode = doc.DocumentElement;
            xmlNode?.RemoveAll();
            doc.Save(this.XML_DATABASE_NAME);
        }

        private void Remove(string name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this.XML_DATABASE_NAME);
            XmlNode xmlNode = doc.DocumentElement;
            foreach (XmlNode node in xmlNode.FirstChild.ChildNodes)
                try
                {
                    if (node.FirstChild.InnerText == name)
                    {
                        doc.DocumentElement?.FirstChild.RemoveChild(node);
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            doc.Save(this.XML_DATABASE_NAME);
        }
        public void Remove(Vehicle vehicle)
        {
            bool deleted = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(this.XML_DATABASE_NAME);
            XmlNode xmlNode = doc.DocumentElement;
            foreach (XmlNode node in xmlNode.FirstChild.ChildNodes)
                try
                {
                    if (node.FirstChild.InnerText == vehicle.Name)
                    {
                        doc.DocumentElement?.FirstChild.RemoveChild(node);
                        deleted = true;
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            if(!deleted)
                throw new Exception("Vehicle hasn't been found!!!");

            doc.Save(this.XML_DATABASE_NAME);
        }
        public void Replace(string name, Vehicle vehicle)
        {
            this.Remove(name);
            this.Add(vehicle);
        }
        public void Refresh(Vehicle vehicle)
        {
            this.Replace(vehicle.Name,vehicle);
        }
        #endregion
    }

}