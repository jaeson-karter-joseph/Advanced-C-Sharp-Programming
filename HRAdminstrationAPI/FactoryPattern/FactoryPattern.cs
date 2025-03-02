﻿namespace HRAdminstrationAPI.FactoryPattern
{
    public static class FactoryPattern<K, T> where T : class, K, new()
    {
        public static K GetInstance()
        {
            K objk;
            objk = new T();
            return objk;
        }
    }
}
