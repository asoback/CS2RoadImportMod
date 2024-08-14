using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System;
using System.Xml.Linq;

class OSMParser
{
    public void ParseOSM(string filePath)
    {
        XDocument osmData = XDocument.Load(filePath);

        foreach (var node in osmData.Descendants("node"))
        {
            double lat = double.Parse(node.Attribute("lat").Value);
            double lon = double.Parse(node.Attribute("lon").Value);

            // Convert lat/lon to game coordinates here
            Console.WriteLine($"Node: Lat {lat}, Lon {lon}");
        }

        foreach (var way in osmData.Descendants("way"))
        {
            Console.WriteLine("Way: ");
            foreach (var nd in way.Elements("nd"))
            {
                string refId = nd.Attribute("ref").Value;
                Console.WriteLine($" - Node ref: {refId}");
            }

            // Convert way nodes to game roads here
        }
    }
}

namespace RealCitiesRoadImport
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(RealCitiesRoadImport)}.{nameof(Mod)}").SetShowsErrorsInUI(false);

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
        }
    }
}
