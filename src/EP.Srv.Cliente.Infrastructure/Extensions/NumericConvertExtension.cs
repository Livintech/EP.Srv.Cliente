using System;
namespace EP.Srv.Cliente.Infrastructure.Extensions
{
    public static class NumericConvertExtension
    {
        private static IList<string> fileSizeUnits;

        static NumericConvertExtension()
        {
            fileSizeUnits =
                new List<string>() { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        }

        /// <summary>
        /// Retorna o valor formatado como tamanho de arquivo (KB, MB, GB...).
        /// </summary>
        /// <param name="totalBytes">Total de bytes do arquivo.</param>
        /// <param name="precision">Número de casas decimais para exibir.</param>
        /// <returns>Tamanho do arquivo formatado.</returns>
        public static string ToFileSize(this double totalBytes, int precision = 2)
        {
            if (totalBytes <= 0)
                return String.Format("0 {0}", fileSizeUnits[0]);

            double bytes = Math.Abs(totalBytes);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            if (place > fileSizeUnits.Count - 1)
                place = fileSizeUnits.Count - 1;

            double num = Math.Round(bytes / Math.Pow(1024, place), precision);
            return String.Format("{0} {1}", Math.Sign(totalBytes) * num, fileSizeUnits[place]);
        }
    }
}
