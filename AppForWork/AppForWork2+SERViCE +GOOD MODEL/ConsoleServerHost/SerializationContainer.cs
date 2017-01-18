﻿using System;
using System.Collections.Generic;

namespace ConsoleServerHost
{
    [Serializable]
    public class SerializationContainer<T>
    {

        public SerializationContainer()
        {
            //this.Data = default(T);
        }
        public SerializationContainer(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }
}