using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyVersionAttribute("1.0.0.1")]
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("keyfile.snk")]
namespace External
{
    public class ext
    {
        public string thing()
        {
            return "External.ext.thing(): [" + Assembly.GetExecutingAssembly().FullName + "]";
        }
    }
}
