using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Cake.Core;
using Cake.Core.IO;

namespace Syncromatics.Cake.GoGitVer.Extensions
{
    public static class ArgumentsBuilderExtensions
    {
        public static void AppendAll<TSettings>(this ProcessArgumentBuilder builder, TSettings settings)
            where TSettings : GlobalGoGitVerSettings
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            AppendArguments(builder, settings);
        }


        private static void AppendArguments<TSettings>(ProcessArgumentBuilder builder, TSettings settings)
            where TSettings : GlobalGoGitVerSettings
        {
            var type = typeof(TSettings);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var property in properties)
            {
                GetArguments(builder, property, settings);
            }
        }

        private static void GetArguments(ProcessArgumentBuilder builder, PropertyInfo propertyInfo, object settings)
        {
            var snakecaseFlag = $"--{Regex.Replace(propertyInfo.Name, @"([a-z])([A-Z])", "$1-$2").ToLower()}";
            var value = propertyInfo.GetValue(settings);
            if (value == null) return;
            switch (value)
            {
                case string[] stringArrayValue:
                    foreach (var stringValue in stringArrayValue)
                    {
                        builder.Append(snakecaseFlag);
                        builder.AppendQuoted(stringValue);
                    }
                    break;
                case bool boolValue:
                    if (boolValue) builder.Append(snakecaseFlag);
                    break;
                default:
                    builder.Append(snakecaseFlag);
                    builder.AppendQuoted(value.ToString());
                    break;
            }
        }
    }
}