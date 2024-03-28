using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChroimumFullScreenNETFramework.Models
{
    public class Options
    {
        public string Url { get; set; }
        public int RefreshInterval { get; set; }
        public int PingTimeout { get; set; }
        public int RetryCount { get; set; }

        public static event EventHandler<OptionsErrorEventArgs> OnError;
        public static event EventHandler<EventArgs> OnChange;

        public static void Save(Options options)
        {
            try
            {
                string json = JsonConvert.SerializeObject(options, Formatting.Indented);
                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "options.json"), json);

                OnChange?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(null, new OptionsErrorEventArgs(ex));
            }
        }

        public static Options Load()
        {
            try
            {
                if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "options.json")))
                    Save(new Options());

                string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "options.json"));
                var options = JsonConvert.DeserializeObject<Options>(json);

                if (options.RefreshInterval == 0)
                    OnError?.Invoke(null, new OptionsErrorEventArgs(new Exception("Refresh interval cannot be set to 0.")));

                if (String.IsNullOrEmpty(options.Url))
                    OnError?.Invoke(null, new OptionsErrorEventArgs(new Exception("Url cannot be null.")));

                return options;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(null, new OptionsErrorEventArgs(ex));
                return new Options();
            }
        }
    }

    public class OptionsErrorEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public OptionsErrorEventArgs(Exception ex)
        {
            Exception = ex;
        }
    }
}
