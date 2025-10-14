using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsManage
{
    private static PlayerPrefsManage _instance = new PlayerPrefsManage();

    public static PlayerPrefsManage instance
    {
        get
        {
            return _instance;
        }
    }

    // 私有化构造函数
    private PlayerPrefsManage() { }


    private void _SaveValue(object value, string key)
    {
        // 根据值的类型存储不同的数据, PlayerPrefs支持三种数据类型 int float string
        Type valueType = value.GetType();
        if (valueType == typeof(int))
        {
            PlayerPrefs.SetInt(key, (int)value);
        }
        else if (valueType == typeof(float))
        {
            PlayerPrefs.SetFloat(key, (float)value);
        }
        else if (valueType == typeof(string))
        {
            PlayerPrefs.SetString(key, (string)value);
        }
        else if (valueType == typeof(bool))
        {
            // bool类型转换为int存储
            int boolValue = (bool)value ? 1 : 0;
            PlayerPrefs.SetInt(key, boolValue);
        }
        else if (typeof(IList).IsAssignableFrom(valueType))
        {
            //List类型 因为有泛型无法确定类型,所以这里判断是不是IList接口的子类
            IList list = (IList)value;
            // 存储List的长度
            PlayerPrefs.SetInt($"{key}_Count", list.Count);
            // Debug.Log($"存储List长度: {key}_Count = {list.Count}");
            for (int i = 0; i < list.Count; i++) 
            {
                object item = list[i];
                string itemKey = $"{key}_{i}";
                this._SaveValue(item, itemKey);
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(valueType))
        {
            // Dictionary类型
            IDictionary dict = (IDictionary)value;
            // 存储Dictionary的长度
            PlayerPrefs.SetInt($"{key}_Count", dict.Count);
            // Debug.Log($"存储Dictionary长度: {key}_Count = {dict.Count}");
            int index = 0;
            foreach (DictionaryEntry entry in dict)
            {
                object dictKey = entry.Key;
                object dictValue = entry.Value;
                string itemKey = $"{key}_Key_{index}";
                string itemValue = $"{key}_Value_{index}";
                this._SaveValue(dictKey, itemKey);
                this._SaveValue(dictValue, itemValue);
                index++;
            }
        }
        else
        {
            // 自定义类型
            this.SaveData(value, key);
        }
        // Debug.Log($"存储数据: {key} = {value}");
    }

    /// <summary>
    /// 存储数据 
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="key">数据对象的唯一key</param> 
    public void SaveData(object data, string key)
    {
        // 1. 获取对象的所有字段
        Type type = data.GetType();
        FieldInfo[] fields = type.GetFields();

        // 2. 将字段存储到PlayerPrefs中
        // 自定义key保证唯一性: key_数据类型_字段类型_字段名称
        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            string customKey = $"{key}_{type.Name}_{field.FieldType.Name}_{field.Name}";
            object fieldValue = field.GetValue(data);
            this._SaveValue(fieldValue, customKey);
        }

        // 3. 保存到磁盘
        PlayerPrefs.Save();
    }

    private object _LoadValue(Type valueType, string key)
    {
        if (valueType == typeof(int))
        {
            return PlayerPrefs.GetInt(key, 0);
        }
        else if (valueType == typeof(float))
        {
            return PlayerPrefs.GetFloat(key, 0f);
        }
        else if (valueType == typeof(string))
        {
            return PlayerPrefs.GetString(key, "");
        }
        else if (valueType == typeof(bool))
        {
            int intValue = PlayerPrefs.GetInt(key, 0);
            return intValue == 1;
        }
        else if (typeof(IList).IsAssignableFrom(valueType))
        {
            // List类型
            int count = PlayerPrefs.GetInt($"{key}_Count", 0);
            // Debug.Log($"读取List长度: {key}_Count = {count}");
            IList list = (IList)Activator.CreateInstance(valueType);
            Type itemType = valueType.GetGenericArguments()[0];
            for (int i = 0; i < count; i++)
            {
                string itemKey = $"{key}_{i}";
                object itemValue = this._LoadValue(itemType, itemKey);
                list.Add(itemValue);
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(valueType))
        {
            // Dictionary类型
            int count = PlayerPrefs.GetInt($"{key}_Count", 0);
            // Debug.Log($"读取Dictionary长度: {key}_Count = {count}");
            IDictionary dict = (IDictionary)Activator.CreateInstance(valueType);
            Type[] genericArgs = valueType.GetGenericArguments();
            Type keyType = genericArgs[0];
            Type valueTypeArg = genericArgs[1];
            for (int i = 0; i < count; i++)
            {
                string itemKey = $"{key}_Key_{i}";
                string itemValue = $"{key}_Value_{i}";
                object dictKey = this._LoadValue(keyType, itemKey);
                object dictValue = this._LoadValue(valueTypeArg, itemValue);
                dict.Add(dictKey, dictValue);
            }
            return dict;
        }
        else
        {
            // 自定义类型
            return this.LoadData(valueType, key);
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="objectType">读取数据的类型</param>
    /// <param name="key">数据对象的唯一key</param>
    /// <returns></returns>
    public object LoadData(Type objectType, string key)
    {
        // 1. 创建对象实例
        object obj = Activator.CreateInstance(objectType);

        // 2. 获取对象的所有字段
        FieldInfo[] fields = objectType.GetFields();

        // 3. 读取每个字段的值
        foreach (FieldInfo field in fields)
        {
            string customKey = $"{key}_{objectType.Name}_{field.FieldType.Name}_{field.Name}";
            object fieldValue = this._LoadValue(field.FieldType, customKey);
            field.SetValue(obj, fieldValue);
        }

        return obj;
    }
}
